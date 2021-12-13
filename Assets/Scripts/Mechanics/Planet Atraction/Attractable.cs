using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Attractable : MonoBehaviour
{
    [SerializeField] private bool rotateToCenter = true;
    [SerializeField] Attractor currentAttractor;

    Transform _tns;
    Collider2D _coll;
    Rigidbody2D _rb;


    [Range(0, 10)]
    public float speed = 5;
    Vector3 moveDir;
    public bool grounded;
    public float jumpForce = 200;
    public LayerMask SourfaceMask;

    Vector3 smoothMoveVelocity;


    private void Awake()
    {
        _tns = GetComponent<Transform>();
        _coll = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    private void Update()
    {
        if (currentAttractor != null)
        {
            if (!currentAttractor.AttractedObjects.Contains(_coll)) currentAttractor = null;
            if (rotateToCenter) RotateToCenter();

            // Calculate movement:
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            Vector3 _moveDir = new Vector2(inputX, inputY).normalized;
            Vector3 targetMoveAmount = _moveDir * speed;
            moveDir = Vector3.SmoothDamp(moveDir, targetMoveAmount, ref smoothMoveVelocity, .15f);

            // Jump
            if (grounded && Input.GetButtonDown("Jump"))
                _rb.AddForce(transform.up * jumpForce);

            Vector2 attractionDir = (Vector2)currentAttractor.planetTransform.position;
            // Grounded check
            Ray ray = new Ray(_rb.position, attractionDir);
            RaycastHit hit;
            grounded = Physics.Raycast(ray, out hit, 1 + .1f, SourfaceMask);
            Color color = grounded ? Color.green : Color.red;
            //Debug.Log(hit.transform.name);
            Debug.DrawRay(transform.position, attractionDir, color);

            // var v = Input.GetAxis("Vertical");
            // moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), v == 0 ? attractionDir.y : v).normalized;
        }
    }

    private void FixedUpdate()
    {
        // Apply movement to rigidbody
        // https://pastebin.com/YBbFGZzD#:~:text=%C2%A0%20%C2%A0%20%C2%A0%20%C2%A0%20//%20Apply%20movement%20to%20rigidbody
        // https://youtu.be/gHeQ8Hr92P4?t=785
        // https://youtu.be/TicipSVT-T8?t=1747
        Vector3 localMove = transform.TransformDirection(moveDir);
        _rb.MovePosition((Vector3)_rb.position + localMove * Time.fixedDeltaTime);
    }



    public void Attract(Attractor artgra)
    {
        Vector2 attractionDir = (Vector2)artgra.planetTransform.position - _rb.position;
        _rb.AddForce(attractionDir.normalized * -artgra.gravity * 100 * Time.fixedDeltaTime);

        if (currentAttractor == null)
        {
            currentAttractor = artgra;
        }
    }

    void RotateToCenter()
    {
        Vector2 distanceVector = (Vector2)currentAttractor.planetTransform.position - (Vector2)_tns.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        _tns.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
