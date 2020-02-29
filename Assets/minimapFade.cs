using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minimapFade : MonoBehaviour
{
    public Transform player;
    public float fadeAmount = 100;
    public Image back;
    public RawImage front;
    bool hi = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hi = !hi;
        }
        
        if (hi)
        {
            StartCoroutine(FadeImage(true, back));
            StartCoroutine(FadeRawImage(true, front));
        }
        else
        {
            StartCoroutine(FadeImage(false, back));
            StartCoroutine(FadeRawImage(true, front));
        }
    }
    IEnumerator FadeImage(bool fadeAway, Image img)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0.5f; i -= Time.deltaTime)
            {
                img.color = new Color(100, 100, 100, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0.5f; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(100, 100, 100, i);
                yield return null;
            }
        }
    }
    IEnumerator FadeRawImage(bool fadeAway, RawImage img)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0.5f; i -= Time.deltaTime)
            {
                img.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0.5f; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(255, 255, 255, i);
                yield return null;
            }
        }
    }

}
