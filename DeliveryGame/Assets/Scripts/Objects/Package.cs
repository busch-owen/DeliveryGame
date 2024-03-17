using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : PoolObjects
{
    // I AM A PACKAGE :D

    [SerializeField]
    float _lifeTime;

    private void OnEnable()
    {
        Invoke("OnDeSpawn", _lifeTime);
    }
}
