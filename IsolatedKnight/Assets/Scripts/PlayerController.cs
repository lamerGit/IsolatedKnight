using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput _inputActions;
    Animator _animator;

    Player myPlayer;

    private void Awake()
    {
        _inputActions = new();
        _animator = GetComponent<Animator>();

        myPlayer = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Click.performed += OnClick;
    }

    private void OnDisable()
    {
        _inputActions.Player.Click.performed -= OnClick;
        _inputActions.Disable();
    }

    private void OnClick(InputAction.CallbackContext obj)
    {
        MouseRay(Mouse.current.position.ReadValue());
        //MouseRay(Touchscreen.current.position.ReadValue());
    }

    private void MouseRay(Vector2 mousePos)
    {
        Ray ray=Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hit,1000.0f,LayerMask.GetMask("Enemy")))
        {
            GameObject e = hit.transform.gameObject;
            if (myPlayer.TouchPossibleCheck && myPlayer.StaminaCheck)
            {
                e.GetComponent<EnemyBase>().OnDamage(myPlayer.TouchDamage);
                _animator.SetTrigger("Attack");
                myPlayer.ResetTouchSpeed();
            }

            

           

            //Debug.Log(e.name);
        }

    }

}
