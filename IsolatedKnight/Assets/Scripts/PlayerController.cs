using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput _inputActions;

    Player myPlayer;

    private void Awake()
    {
        _inputActions = new();
       
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
        if (Managers.GameManager.State == GameState.Nomal)
        {
            MouseRay(Mouse.current.position.ReadValue()); // pc에서 할때 주석풀기

            //MouseRay(Touchscreen.current.position.ReadValue());  핸드폰에서 할때 주석풀기
        }
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
                myPlayer.AttackAnimation();
                myPlayer.ResetTouchSpeed();
            }

            

           

            //Debug.Log(e.name);
        }

    }

}
