using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : Singleton<CarStats>
{
    [field: SerializeField]
    public float speed { get; private set; }

    [field: SerializeField]
    public float tireFriction { get; private set; }
}
