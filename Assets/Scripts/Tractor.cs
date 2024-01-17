using System;
using System.Collections;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();

    private bool CanUnHover = false;

    [SerializeField] private Transform rootPosition;

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
        animator.SetTrigger("OnSelect");
        animator.enabled = false;
    }
    public void UnSelect()
    {
        animator.enabled = true;
        animator.SetTrigger("UnSelect");
        gameObject.transform.position = rootPosition.position;
    }
}
