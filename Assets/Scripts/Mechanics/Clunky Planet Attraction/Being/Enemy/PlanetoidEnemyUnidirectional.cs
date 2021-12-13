using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_Utils;


public class PlanetoidEnemyUnidirectional : SateliteBeing
{
    float unidirectional = 0;

    private void Awake()
    {
        unidirectional = (Utils.Random1() > 0.5f) ? 1 : -1;
        StartInPosAngle(unidirectional, satelite);
    }

    void Update()
    {
        RotateAroundPlanetWithRadius(unidirectional, satelite);
    }
}
