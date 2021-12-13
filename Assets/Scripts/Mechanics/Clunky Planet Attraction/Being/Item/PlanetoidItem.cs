using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetoidItem : SateliteBeing
{
    private void Start()
    {
        satelite.angle = GameManager.Instance.planetoidPlayerBithAngle + 60;
        StartInPosAngle(1, satelite);
    }
}
