using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float offsetX;
    public float offsetY;

    private Vector3 offset;

    private void Awake() {
        UpdateOffset();
    }

    private void LateUpdate() {
        if (target != null) {
            Vector3 tmp = target.transform.position + offset;
            tmp.x = transform.position.x;
            transform.position = tmp;
        }
    }

    private void OnValidate() {
        UpdateOffset();
    }

    private void UpdateOffset() {
        offset = new Vector3(offsetX, offsetY, -10);
    }

}
