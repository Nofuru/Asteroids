using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosionSound : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _source;

    private void Play(int _tag)
    {
        _source[_tag].Play();
    }

    private void Awake()
    {
        AsteroidOnTriggerEnterAction.asteroidDestroyed.AddListener(Play);
    }
}
