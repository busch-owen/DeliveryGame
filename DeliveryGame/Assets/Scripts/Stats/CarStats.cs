using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : Singleton<CarStats>
{
    [field: SerializeField]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float TireFriction { get; private set; }
}
