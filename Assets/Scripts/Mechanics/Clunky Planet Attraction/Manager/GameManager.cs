using System;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public static event Action<GameState> OnOldGameSatateChanged;

    public float planetoidPlayerBithAngle = 30;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.cleaning:
                break;
        }

        OnOldGameSatateChanged?.Invoke(newState);
    }

}
