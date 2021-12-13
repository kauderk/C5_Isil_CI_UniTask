using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityBody2D : MonoBehaviour
{

    GravityAttractor2D planet;
    Rigidbody2D rb;

    void Awake()
    {
        planet = FindObjectOfType<GravityAttractor2D>();// gameObject.GetComponent<GravityAttractor>();
        rb = GetComponent<Rigidbody2D>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Allow this body to be influenced by planet's gravity
        planet.Attract(rb);
    }
}