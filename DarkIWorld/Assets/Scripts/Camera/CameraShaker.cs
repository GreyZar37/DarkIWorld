using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public bool isShaking = false;
    public float duration = 1f;

    public AnimationCurve curve;

    private void Update()
    {
        if (isShaking)
        {
            isShaking = false;
            StartCoroutine(shake());


        }
    }

    

    IEnumerator shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }

        transform.position = startPosition;
    }
}
