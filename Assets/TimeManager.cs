using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] GameObject tractor;
    [SerializeField] ParticleSystem particle;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);

        tractor.GetComponent<Animator>().SetTrigger("Start");
        particle.Play();

        yield return new WaitForSeconds(10f);

        var moduloVelocidad = particle.velocityOverLifetime;
        moduloVelocidad.enabled = true;
       
        yield return new WaitForSeconds(0.5f);

        particle.Stop();
        var mainModule = particle.main;
        mainModule.playOnAwake = false;
    }
}
