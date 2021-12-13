using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class SliderU : MonoBehaviour
{
    public void ToogleDisabled(bool isDisabled)
    {
        GetComponent<UnityEngine.UI.Slider>().interactable = !isDisabled;
    }
}
