using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    [SerializeField]
    static public List<Planet> planets = new List<Planet>() {
    new Planet(0, 0, 7, 5),
    new Planet(30 , 30, 7, 5),
    new Planet(30, 30, 7, 5),
    // new Planet(0, 0, 3, 5),
    // new Planet(0, 7.88f, 2, 4),
    // new Planet(7.5f, 0, 1.5f, 3.5f),
  };
}

public class Planet
{
    [SerializeField]
    public Vector3 position;
    [SerializeField]
    public float radius;
    [SerializeField]
    public float gravityRadius;

    public Planet(float x, float y, float radius, float gravityRadius)
    {
        this.position = new Vector3(x, y, 0);
        this.radius = radius;
        this.gravityRadius = gravityRadius;
    }
}
