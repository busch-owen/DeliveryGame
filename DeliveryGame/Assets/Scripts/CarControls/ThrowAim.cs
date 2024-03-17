using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAim : MonoBehaviour
{
    public float AimAngle { get; private set; }

    [SerializeField]
    float _aimSpeed;

    private void FixedUpdate()
    {
        RotateHandle();
    }

    public void HandleMouseAim(Vector2 aimPos)
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(aimPos) - Camera.main.transform.position;
        AimAngle = Mathf.Atan2(worldPos.y, worldPos.x) * Mathf.Rad2Deg;
    }

    public void HandleControllerAim(Vector2 aimPos)
    {
        AimAngle = Mathf.Atan2(aimPos.y, aimPos.x) * Mathf.Rad2Deg;
    }

    void RotateHandle()
    {
        Quaternion rotation = Quaternion.AngleAxis(AimAngle, Vector3.forward);
        transform.localRotation = Quaternion.Slerp(transform.rotation, rotation, _aimSpeed);
    }
}
