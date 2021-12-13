using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAuido : MonoBehaviour
{
    public void Volume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ToogleMute(bool mute)
    {
        AudioListener.pause = mute;
    }
}
