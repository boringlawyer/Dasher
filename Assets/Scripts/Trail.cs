using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    // Start is called before the first frame update
    public float opacityDecrementPerFrame = .01f;
    SpriteRenderer renderer;
    public Color spriteColor = Color.white;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteColor == Color.white)
        {
            return;
        }
        spriteColor.a -= opacityDecrementPerFrame;
        renderer.color = spriteColor;
        if (spriteColor.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
