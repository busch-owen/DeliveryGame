using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [field: SerializeField]
    public float ThrowForce { get; private set; }

    [field: SerializeField]
    public int BoxCapacity { get; private set; }

    [field: SerializeField]
    public int BoxCount { get; private set;}

    private void Awake()
    {
        BoxCount = BoxCapacity;
    }

    public void RemoveBoxesFromCount()
    {
        BoxCount--;
        BoxCount = Mathf.Clamp(BoxCount, 0, BoxCapacity);
    }
}
