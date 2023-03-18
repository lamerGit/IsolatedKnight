using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput _inputActions;

    Player myPlayer;

    float _swordWindSpeed = 40.0f;
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

            //MouseRay(Touchscreen.current.position.ReadValue()); // 핸드폰에서 할때 주석풀기
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
                
                e.GetComponent<EnemyBase>().OnTouchDamage(myPlayer.TouchDamage);
                myPlayer.AttackAnimation();
                myPlayer.ResetTouchSpeed();

                if (Managers.GameManager.SwordWindTier1SwordWindOn)
                {
                    SwordWind();
                }

                if(Managers.GameManager.AxeArrowTier1ArrowOn)
                {
                    myPlayer.ExpAttack();
                }

                if(Managers.GameManager.AxeFrenzyTier1FrenzyOn)
                {
                    myPlayer.CurrentStamina += myPlayer.StaminaRecoverySpeed*0.5f;
                }

            }

        }

    }

    void SwordWind()
    {
        Poolable bullet = Managers.Pool.Pop(Managers.Object.SwordWind);

        bullet.transform.position = transform.position+Vector3.up*1.5f;
        bullet.Spawn(transform);

        Vector3 dir = transform.forward;

        bullet.transform.rotation = Quaternion.Euler(0,60,0);
        SwordWind component = bullet.GetComponent<SwordWind>();

        
        dir.y += 0.17f;
        component.Rigid.velocity = dir * _swordWindSpeed;

        component.Damage = myPlayer.TouchDamage + Managers.GameManager.ExtraTouchDamage;
        component.Dir = dir;
        component.Speed = _swordWindSpeed;

        if (Managers.GameManager.State == GameState.LevelUp)
        {
            component.Rigid.velocity = Vector3.zero;

        }
    }

}
