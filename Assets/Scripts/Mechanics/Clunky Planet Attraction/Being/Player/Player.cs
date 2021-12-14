using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : SateliteBeing
{
    // lerp de salto
    float jumpHigh = 1.3f;
    float tJump = 0;
    float speedJump = 2;

    // jump variables
    bool isJumping = false;
    bool isFalling = false;

    private void Start()
    {
        satelite.angle = GameManager.Instance.planetoidPlayerBithAngle;
    }

    public void CustomUpdate()
    {
        // an action or callback that returns satelite.radius would be nice here...
        RotateAroundPlanet(Input.GetAxis("Horizontal"), satelite);

        #region jumping logic 
        // si se presiona UP, se activa el salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            isJumping = true;
        }

        // si el salto está activo
        if (isJumping)
        {
            // se calcula el radio con un lerp
            satelite.radius = Mathf.Lerp(
                    MapData.planets[satelite.currentPlanet].radius,
                    MapData.planets[satelite.currentPlanet].radius + jumpHigh,
                    Tweens.Parabolic(tJump)
                  );
            // se incrementa el tiempo de salto
            tJump += Time.deltaTime * speedJump;

            // si termina la animación
            if (tJump >= 1)
            {
                isJumping = false;
                tJump = 0;
            }

            // se verifica si se está colisionando con el área de gravedad de algún otro planeta
            for (int i = 0; i < MapData.planets.Count; i++)
            {
                if (i != satelite.currentPlanet)
                {
                    float distance = Vector3.Distance(transform.position, MapData.planets[i].position);
                    if (distance <= MapData.planets[i].gravityRadius)
                    {
                        // colisionó
                        isFalling = true;
                    }
                }
            }
        }
        // de lo contrario, se mantiene en el piso
        else
        {
            satelite.radius = MapData.planets[satelite.currentPlanet].radius;
        }
        #endregion
    }
}
