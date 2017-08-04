using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Raycaster))]
public class DudeController : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;
    public float walkVelocity = 8;

    public float jumpPressedTimeTolerance = 0.1f;
    public float notGroundedJumpTimeTolerance = 0.1f;

    [NonSerialized]
    public Vector3 respawnPoint = new Vector3(0, 0, 0);

    private Raycaster raycaster;
    private DudeAnimation dudeAnimation;

    private float gravity;
    private float jumpVelocity;
    private Vector3 velocity;

    private bool oldIsGrounded;
    private bool isGrounded;
    private float jumpPressedTime = float.MinValue;
    private float notGroundedJumpTime = float.MinValue;

    private Vector2 moveInput;
    private bool isJumping;
    private float jumpType = 0f;

    [NonSerialized]
    public bool isGettingHit = false;

    private AudioManager audioManager;
    public AudioClip jumpSfx;
    public AudioClip crashSfx;

    private void Awake() {
        raycaster = GetComponent<Raycaster>();
        audioManager = FindObjectOfType<AudioManager>();
        dudeAnimation = GetComponentInChildren<DudeAnimation>();

        UpdateGravity();
        velocity = Vector3.zero;
        respawnPoint = Vector3.zero;
    }

    private void Start() {
        //GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
        //cameraFollow.target = gameObject;
    }

    private void Update() {
        //moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float moveX;
        if (transform.position.x <= 0) {
            moveX = 1f;
        } else {
            moveX = 0f;
        }
        moveInput = new Vector2(moveX, Input.GetAxisRaw("Vertical"));

        if (!isGettingHit) {
            if ((Input.GetButtonDown("Jump") || moveInput.y > 0)) {
                //if (Input.GetKeyDown(KeyCode.Space)) {
                jumpPressedTime = Time.time;
            }
            if ((Time.time - jumpPressedTime) <= jumpPressedTimeTolerance) {
                if (isGrounded || (Time.time - notGroundedJumpTime) <= notGroundedJumpTimeTolerance) {
                    Jump();
                }
            }
        }

        velocity.x = walkVelocity * moveInput.x;
        velocity.y += gravity * Time.deltaTime;
        Vector3 displacement = velocity * Time.deltaTime;

        Move(displacement);

        //if (transform.position.y <= -6) {
        //    Time.timeScale = 0f;
        //}
    }

    private void LateUpdate() {
        if (moveInput.x != 0)
            dudeAnimation.SetIsFacingRight(moveInput.x > 0);

        if (forceIdleAnimation) {
            dudeAnimation.SetIdle();
        } else if (isJumping) {
            dudeAnimation.SetJumping();
        } else if (isGrounded) {
            if (velocity.x == 0) {
                //dudeAnimation.SetIdle();
                dudeAnimation.SetWalking();
            } else {
                dudeAnimation.SetWalking();
            }
        }
    }

    [NonSerialized]
    public bool forceIdleAnimation = false;

    private void OnValidate() {
        UpdateGravity();
        jumpPressedTimeTolerance = Mathf.Clamp(jumpPressedTimeTolerance, 0, float.MaxValue);
        notGroundedJumpTimeTolerance = Mathf.Clamp(notGroundedJumpTimeTolerance, 0, float.MaxValue);
    }

    public void Respawn() {
        transform.position = respawnPoint;
    }

    private void Jump() {
        velocity.y = jumpVelocity;
        isJumping = true;
        jumpPressedTime = float.MinValue;
        notGroundedJumpTime = float.MinValue;

        jumpType = Mathf.Repeat(jumpType + 1, 2f);
        dudeAnimation.SetJumpType(jumpType);
        audioManager.PlaySfx(jumpSfx);
    }

    private void Move(Vector3 displacement) {
        //Vector3 oldDisplacement = displacement;
        Raycaster.CollisionInfo collisions;

        raycaster.UpdateRaycastOrigins();
        raycaster.HandleCollisions(ref displacement, out collisions);

        //if (collisions.above) {
        //    collisions.above = false;
        //    displacement = oldDisplacement;
        //}
        transform.Translate(displacement);

        if (collisions.below || collisions.above) {
            velocity.y = 0;
        }
        oldIsGrounded = isGrounded;
        isGrounded = collisions.below;
        if (isGrounded) {
            isJumping = false;
        }
        if (oldIsGrounded && !isGrounded) {
            notGroundedJumpTime = Time.time;
        }
    }

    private void UpdateGravity() {
        gravity = (2 * -jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = -(gravity * timeToJumpApex);
    }

    public Slider slider;

    public void GetHit(bool isEnding = false) {
        slider.value = Mathf.Clamp(slider.value - 0.05f, 0f, 1f);
        velocity.x = 0f;
        velocity.y = 0f;
        transform.position = new Vector3(transform.position.x, -0.45f, 0f);
        dudeAnimation.SetHit(!isEnding);
        isGettingHit = true;
        audioManager.PlaySfx(crashSfx);
    }
}
