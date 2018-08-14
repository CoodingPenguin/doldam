using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour {

    Text text;
    float blinkSpeed = 1.5f;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(BlinkFunction());
    }

    IEnumerator BlinkFunction()
    {
        float alpha = 1;
        while (true)
        {
            while (true)
            {
                alpha -= Time.deltaTime * blinkSpeed;
                text.color = new Color(0, 0, 0, alpha);
                if (alpha < 0)
                {
                    break;
                }
                yield return null;
            }
            while (true)
            {
                alpha += Time.deltaTime * blinkSpeed;
                text.color = new Color(0, 0, 0, alpha);
                if (alpha > 1)
                {
                    break;
                }
                yield return null;
            }
        }
    }
}
