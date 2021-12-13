using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteBeing : MonoBehaviour
{
    [SerializeField]
    public Satelite satelite = new Satelite();

    public void StartInPosAngle(float direction, Satelite satelite)
    {
        transform.position = MapData.planets[satelite.currentPlanet].position;
        RotateAroundPlanetWithRadius(direction, satelite); // depends on -> MapData 
        RotateAroundPlanetWithRadius(direction, satelite); // twice bc the func is a little bit weird
    }

    public void RotateAroundPlanet(float direction, Satelite satelite)
    {
        satelite.angle -= direction * Time.deltaTime * satelite.speed;

        // se transforma la coordenada polar en cartesiana
        float x = satelite.radius * Mathf.Cos(satelite.angle) + MapData.planets[satelite.currentPlanet].position.x;
        float y = satelite.radius * Mathf.Sin(satelite.angle) + MapData.planets[satelite.currentPlanet].position.y;


        // se actualiza la rotación
        Vector3 up = transform.position - MapData.planets[satelite.currentPlanet].position;

        // se actualiza la posición
        transform.position = new Vector3(x, y, 0);
        transform.up = up;
    }


    public void RotateAroundPlanetWithRadius(float direction, Satelite satelite)
    {
        RotateAroundPlanet(direction, satelite);
        satelite.radius = MapData.planets[satelite.currentPlanet].radius;
    }
}
