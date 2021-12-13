using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Attractable : MonoBehaviour
{
    [SerializeField] private bool rotateToCenter = true;
    [SerializeField] Attractor currentAttractor;

    Transform m_transform;
    Collider2D m_collider;
    Rigidbody2D m_rigdibody;

    public bool isJumping = false;
    public float tJump = 0;
    public float jumpSpeed = 1;
    public float jumpSpeed2 = 1;
    public float gravity = 1;


    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_collider = GetComponent<Collider2D>();
        m_rigdibody = GetComponent<Rigidbody2D>();
        m_rigdibody.gravityScale = 0;
    }

    private void Update()
    {
        if (currentAttractor != null)
        {
            if (!currentAttractor.AttractedObjects.Contains(m_collider)) currentAttractor = null;
            if (rotateToCenter) RotateToCenter();


            if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
            {
                isJumping = true;
            }

            if (isJumping)
            {
                Vector2 attractionDir = (Vector2)currentAttractor.planetTransform.position - m_rigdibody.position;
                var nForce = 100 * Time.fixedDeltaTime;
                Debug.Log(currentAttractor.gravity);
                gravity = (jumpSpeed - currentAttractor.gravity);
                m_rigdibody.AddForce(attractionDir.normalized * -gravity * nForce);

                // se incrementa el tiempo de salto
                tJump += Time.deltaTime * jumpSpeed2;

                // si termina la animación
                if (tJump >= 1)
                {
                    isJumping = false;
                    tJump = 0;
                }
            }
        }
    }

    public void Attract(Attractor artgra)
    {
        Vector2 attractionDir = (Vector2)artgra.planetTransform.position - m_rigdibody.position;
        m_rigdibody.AddForce(attractionDir.normalized * -artgra.gravity * 100 * Time.fixedDeltaTime);

        if (currentAttractor == null)
        {
            currentAttractor = artgra;
        }

    }

    void RotateToCenter()
    {
        Vector2 distanceVector = (Vector2)currentAttractor.planetTransform.position - (Vector2)m_transform.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        m_transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
