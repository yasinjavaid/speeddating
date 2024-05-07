using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static IEnumerator CheckAnimationCompleted(Animator anim, string CurrentAnim, Action Oncomplete)
    {
        while (!anim.GetCurrentAnimatorStateInfo(0).IsName(CurrentAnim) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        { yield return null; }
        if (Oncomplete != null)
            Oncomplete();
    }
}
