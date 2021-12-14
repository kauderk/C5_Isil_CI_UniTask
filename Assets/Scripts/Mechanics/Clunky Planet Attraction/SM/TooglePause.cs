using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooglePause : MonoBehaviour
{
    public void Toogle(bool b)
    {
        var player = FindObjectOfType<PlayerController>();
        if (!player) return;

        var state = player.GetPlayerState();
        if (PlayerState.PAUSE == state)
            player.SetStateToGameplay();
        else
            player.SetStateToPaused();
    }
}
