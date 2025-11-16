using UnityEngine;

public class MarioLikeController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, rb.linearVelocity.y);
    }

    private void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y) + Vector2.down * 0.3f, Vector2.down * 0.5f);
        if (Input.GetKeyDown(KeyCode.Space))
            if(Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) + Vector2.down * 0.3f, Vector2.down, 0.5f))
                rb.AddForce(Vector2.up * jumpSpeed * Time.fixedDeltaTime);
    }
}


//using UnityEngine;

//public class MarioLikeController : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public float jumpForce = 7f;
//    public Transform groundCheck;
//    public float checkRadius = 0.2f;
//    public LayerMask groundLayer;

//    private Rigidbody2D rb;
//    private bool isGrounded;
//    private float moveInput;
//    private SpriteRenderer sr;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//    }

//    void Update()
//    {
//        // Mișcare stânga-dreapta
//        moveInput = Input.GetAxisRaw("Horizontal");
//        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

//        // întoarcerea sprite-ului după direcție
//        if (moveInput > 0) sr.flipX = false;
//        if (moveInput < 0) sr.flipX = true;

//        // Sărit
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

//        if (Input.GetButtonDown("Jump") && isGrounded)
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        }
//    }
//}
