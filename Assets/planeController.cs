using System.Collections;
using UnityEngine;

public class planeController : MonoBehaviour
{
    [SerializeField] private Material planeMaterial;

    [SerializeField] private float duration;
    private float start = 5f;
    [SerializeField, Range(0.01f, 5f)] private float target = 0.01f;

    void Start()
    {
        StartCoroutine(Expand(start, target, duration));
    }
    private IEnumerator Expand(float start, float target, float duration)
    {
        float timeElapsed = 0;
        float current = 0;

        while (timeElapsed < duration)
        {
            current = Mathf.Lerp(start, target, timeElapsed / duration);
            planeMaterial.SetVector("TransitionVector", new Vector2 (0, current));
           // planeMaterial.SetFloat("Transition", current);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
