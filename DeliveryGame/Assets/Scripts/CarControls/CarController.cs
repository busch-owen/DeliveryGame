using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Vector2 _movement;
    float _throttleAmount;
    float _brakeAmount;

    [SerializeField]
    Sprite[] _truckSprites;

    SpriteRenderer _truckRenderer;

    Rigidbody2D _rb;

    CarStats _stats;

    private void Awake()
    {
        _stats = GetComponent<CarStats>();
        _truckRenderer = GetComponentInChildren<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveCar();
        UpdateCarVisuals();
    }

    public void HandleMovementInput(Vector2 movement)
    {
        _movement = movement;
    }

    public void HandleBrakeInput(float brake)
    {
        _brakeAmount = brake;
    }

    public void HandleThrottleInput(float throttle)
    {
        _throttleAmount = throttle;
    }

    public void MoveCar()
    {
        _rb.velocity = Vector2.Lerp(_rb.velocity, _movement * _stats.speed, _stats.tireFriction);
    }

    public void UpdateCarVisuals()
    {
        float truckAngle = Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg;
        Debug.Log(truckAngle);

        switch(truckAngle)
        {
            case 0:
                _truckRenderer.sprite = _truckSprites[0];
                break;
            case 45:
                _truckRenderer.sprite = _truckSprites[1];
                break;
            case 90:
                _truckRenderer.sprite = _truckSprites[2];
                break;
            case 135:
                _truckRenderer.sprite = _truckSprites[3];
                break;
            case 180:
                _truckRenderer.sprite = _truckSprites[4];
                break;
            case -135:
                _truckRenderer.sprite = _truckSprites[5];
                break;
            case -90:
                _truckRenderer.sprite = _truckSprites[6];
                break;
            case -45:
                _truckRenderer.sprite = _truckSprites[7];
                break;

        }
    }
}
