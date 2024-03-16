using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private CarController _carController;

    CharacterControls _characterControls;

    private void OnEnable()
    {
        _carController = GetComponent<CarController>();

        if(_characterControls == null)
        {
            _characterControls = new CharacterControls();
            _characterControls.PlayerMovement.Movement.performed += i => _carController.HandleMovementInput(i.ReadValue<Vector2>());
            
        }

        _characterControls.Enable();
    }
}
