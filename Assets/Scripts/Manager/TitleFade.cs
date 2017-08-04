using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sequence s = DOTween.Sequence();
        s.Append(DOTween
            .To(() => spriteRenderer.color, x => spriteRenderer.color = x, Color.white, 3.0f));
        s.AppendInterval(1.5f);
        s.Append(DOTween
            .To(() => spriteRenderer.color, x => spriteRenderer.color = x, Color.clear, 3.0f));
        s.Play();
        //DOTween
        //    .To(() => spriteRenderer.color, x => spriteRenderer.color = x, Color.white, 3.0f)
        //    //.OnComplete(Destroy)
        //    .Play();
    }

    // Update is called once per frame
    void Destroy() {
        Destroy(gameObject);
    }
}
