using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjects : MonoBehaviour
{
    PlayerStats _stats;

    [SerializeField]
    Package _packagePrefab;

    private void Awake()
    {
        _stats = GetComponentInParent<PlayerStats>();
    }

    public void SpawnAndThrow()
    {
        if(_stats.BoxCount > 0)
        {
            Package package = (Package)PoolManager.Instance.Spawn(_packagePrefab.name);
            Rigidbody2D packageRB = package.GetComponent<Rigidbody2D>();
            package.transform.position = transform.position;
            packageRB.velocity = Vector3.zero;
            packageRB.angularVelocity = 0;
            packageRB.AddForce(transform.right * _stats.ThrowForce, ForceMode2D.Impulse);
            _stats.RemoveBoxesFromCount();
        }
    }
}
