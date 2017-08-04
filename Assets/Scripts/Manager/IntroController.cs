using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    //public Texture[] frames;
    //public float frameTime = 3f;
    //private int frame = 0;
    //private float nextFrameTime = 0.0f;

    void OnGUI() {
        //if (frame < frames.Length) {
        //    if (Time.time >= nextFrameTime) {
        //        frame++;
        //        nextFrameTime += frameTime;
        //    }
        //    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), frames[frame]);
        //} else {
        //    SceneManager.LoadScene("Main");
        //}
    }

}


//public class SlideShow : MonoBehaviour {
//    public Texture2D[] slides = new Texture2D[9];
//    public float changeTime = 10.0f;
//    private int currentSlide = 0;
//    private float timeSinceLast = 1.0f;

//    void Start() {
//        guiTexture.texture = slides[currentSlide];
//        guiTexture.pixelInset = new Rect(-slides[currentSlide].width / 20, -slides[currentSlide].height / 20, slides[currentSlide].width, slides[currentSlide].height);
//        currentSlide++;
//    }

//    void Update() {
//        if (timeSinceLast > changeTime && currentSlide < slides.Length) {
//            guiTexture.texture = slides[currentSlide];
//            guiTexture.pixelInset = new Rect(-slides[currentSlide].width / 20, -slides[currentSlide].height / 20, slides[currentSlide].width, slides[currentSlide].height);
//            timeSinceLast = 0.0f;
//            currentSlide++;
//        }
//        timeSinceLast += Time.deltaTime;
//    }
//}
