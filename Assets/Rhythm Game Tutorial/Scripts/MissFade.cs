using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissFade : MonoBehaviour {

    public float fadeSpeed = 1f;
    private Image image;
    private float targetAlpha;
    private Image ogImage;
    public static bool resetImage;
    public static bool initalize;
    private Color originalColor;

    // Use this for initialization
    void Start () {
        this.image = this.GetComponent<Image>();

        if (this.image == null)
        {
            Debug.LogError("Error: No image on " + this.name);
        }

        this.targetAlpha = 0.0f;
        this.ogImage = this.image;
        resetImage = false;
        initalize = false;
        this.image.enabled = false;
        originalColor = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (initalize)
        {
            this.image.enabled = true;
            if (!resetImage)
            {
                Color curColor = this.image.color;
                float alphaDiff = Mathf.Abs(curColor.a - this.targetAlpha);
                if (alphaDiff > 0.0001f)
                {
                    curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.fadeSpeed * Time.deltaTime);
                    this.image.color = curColor;
                }
            }
            else
            {
                print("RESET MISS IMAGE");
                this.image.color = originalColor;
                resetImage = false;
            }
        }
    }
}
