using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    GameState _state = GameState.Nomal;
    public GameState State { get { return _state; } 
        set { _state = value;
            StateChange?.Invoke();
        } }

    public Action StateChange { get; set; }
}
