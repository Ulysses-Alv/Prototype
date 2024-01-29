using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();

    private bool CanUnHover = false;

    [SerializeField] private Transform rootPosition;

    [SerializeField] private float targetMultiplier;
    [SerializeField] private float duration;
    
    [SerializeField] private float durationReturn;

    public void OnHover()
    {
        animator.SetTrigger("OnHover");
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.25f);
        CanUnHover = true;
    }

    public void UnHover()
    {
        if (!CanUnHover) return;

        animator.SetTrigger("UnHover");
    }

    public void OnSelect()
    {
        // animator.SetTrigger("OnSelect");
        //animator.enabled = false;

        Vector3 targetScale = transform.localScale * targetMultiplier;

        StartCoroutine(Shrink(transform.localScale, targetScale, duration));
    }

    private IEnumerator Shrink(Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        float timeElapsed = 0;
        Vector3 current = Vector3.zero;

        while (timeElapsed < duration)
        {
            current = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            transform.localScale = current;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        //transform.localScale = currentPosition;
    }

    public void UnSelect()
    {
        StopAllCoroutines();
        StartCoroutine(ReturnRoot(gameObject.transform, rootPosition.transform, durationReturn));
    }

    private IEnumerator ReturnRoot(Transform startTransform, Transform targetTransform, float duration)
    {
        float timeElapsed = 0;
            
        Trans transform = new Trans();

        while (timeElapsed<duration)
        {
            transform.currentPosition = Vector3.Lerp(startTransform.position, targetTransform.position, timeElapsed / duration);
            transform.currentRotation = Vector3.Lerp(startTransform.rotation.eulerAngles, targetTransform.rotation.eulerAngles, timeElapsed / duration);
            transform.currentScale = Vector3.Lerp(startTransform.localScale, targetTransform.localScale, timeElapsed / duration);
            
            gameObject.transform.position = transform.currentPosition;
            gameObject.transform.rotation= Quaternion.Euler(transform.currentRotation);
            gameObject.transform.localScale = transform.currentScale;

            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}

public struct Trans
{
    public Vector3 currentPosition;
    public Vector3 currentRotation;
    public Vector3 currentScale;
    public Trans(Vector3 currentPosition, Vector3 currentRotation, Vector3 currentScale)
    {
        this.currentPosition = Vector3.zero;
        this.currentRotation = Vector3.zero;
        this.currentScale = Vector3.zero;
    }
}
