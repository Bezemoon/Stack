using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void Awake()
    {
        ParticleStop();    
    }

    private void ParticleStop()
    {
        _particle.Stop();
    }

    public void ParticalPlay()
    {
        SwitchPrewarm(true);
        StartCoroutine(ParticleCoroutine());
    }

    private void SwitchPrewarm(bool value)
    {
        var main = _particle.main;
        main.prewarm = value;
    }

    IEnumerator ParticleCoroutine()
    {
        _particle.Play();
        SwitchPrewarm(false);

        yield return new WaitForSeconds(.3f);

        ParticleStop();
    }

}
