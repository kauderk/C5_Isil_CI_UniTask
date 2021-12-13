using UnityEngine;
using System.Collections;

public class GravityAttractor2D : MonoBehaviour
{

    public float gravity = -9.8f;


    public void Attract(Rigidbody2D body)
    {
        Vector3 gravityUp = ((Vector3)body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;

        // Apply downwards gravity to body
        body.AddForce(gravityUp * gravity);
        // Allign bodies up axis with the centre of planet
        //body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }
}
