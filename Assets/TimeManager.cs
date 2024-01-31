using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject tractor;

    [SerializeField] private List<ParticleSystem> particles;

    private List<ParticleSystem.VelocityOverLifetimeModule> modulosVelocidad = new List<ParticleSystem.VelocityOverLifetimeModule>(2);

    private void Awake()
    {
        particles.ForEach(
            particle =>
            modulosVelocidad.Add(
                particle.velocityOverLifetime));

        modulosVelocidad.ForEach(module => module.enabled = false);
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(7f);

        tractor.GetComponent<Animator>().SetTrigger("Start");
        particles.ForEach(particle => particle.Play());

        yield return new WaitForSeconds(10f);

        modulosVelocidad.ForEach(moduloVelocidad => moduloVelocidad.enabled = true);

        yield return new WaitForSeconds(0.5f);

        particles.ForEach(particle => particle.Stop());
        List<ParticleSystem.MainModule> main = new List<ParticleSystem.MainModule>();
        particles.ForEach(particle => main.Add(particle.main));
        main.ForEach(module => module.playOnAwake = false);
    }
}
