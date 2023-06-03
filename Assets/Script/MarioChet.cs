using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioChet : MonoBehaviour
{
    Vector2 ViTriChet;
    float TocDoNay = 20.5f;
    float DoNayCao = 120f;
    private void Start()
    {
        
    }
    private void Update()
    {
        StartCoroutine(MarioChetEffect());
    }
    IEnumerator MarioChetEffect()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + TocDoNay * Time.deltaTime);
            if (transform.localPosition.y >= ViTriChet.y + DoNayCao + 1) break;
            yield return null;
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - TocDoNay * Time.deltaTime);
            if (transform.localPosition.y <= -20f)
            {
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
}
