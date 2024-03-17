using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private CarController _carController;
    private ThrowAim _throwAim;
    private ThrowObjects _throwObjects;

    CharacterControls _characterControls;

    private void OnEnable()
    {
        _carController = GetComponent<CarController>();
        _throwAim = GetComponentInChildren<ThrowAim>();
        _throwObjects = GetComponentInChildren<ThrowObjects>();

        if(_characterControls == null)
        {
            _characterControls = new CharacterControls();
            _characterControls.PlayerMovement.Movement.performed += i => _carController.HandleMovementInput(i.ReadValue<Vector2>());
            _characterControls.PlayerMovement.AimMouse.performed += i => _throwAim.HandleMouseAim(i.ReadValue<Vector2>());
            _characterControls.PlayerMovement.AimController.performed += i => _throwAim.HandleControllerAim(i.ReadValue<Vector2>());

            _characterControls.PlayerActions.ThrowBoxes.performed += i => _throwObjects.SpawnAndThrow();
        }

        _characterControls.Enable();
    }
}
