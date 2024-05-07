using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BubbleAnswer : MonoBehaviour
{
    public bool isDotesBubble;
    public Text text;
    private IEnumerator typing;
    private void OnEnable()
    {
        typing = ShowDots();
        if (isDotesBubble)
        {
            StartCoroutine(typing);
        }

    }
    public void StopRoutine() 
    {
        StopCoroutine(typing);
    }

    private IEnumerator ShowDots()
    {
        while (isDotesBubble)
        {
            text.text = ".";
            yield return new WaitForSeconds (0.5f);
            text.text = ". .";
            yield return new WaitForSeconds(0.5f);
            text.text = ". . .";
            yield return new WaitForSeconds(0.5f);
            text.text = ". . . .";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
