using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityRepeatTimer : MonoBehaviour, IRepeatTimer
{
    private Coroutine coroutine;

    public void StartRepeat(float interval, Func<bool> condition, Action tick)
    {
        StopRepeat();
        coroutine = StartCoroutine(delayTime(interval, condition, tick));
    }

    public void StopRepeat()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private IEnumerator delayTime(float interval, Func<bool> condition, Action tick)
    {
        while (condition())
        {
            tick?.Invoke();
            yield return new WaitForSeconds(interval);
        }
    }
}
