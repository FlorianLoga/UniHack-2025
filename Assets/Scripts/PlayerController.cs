using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject playerProjectile;

    public int lives = 3;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    private Vector2 movement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (GameObject.FindGameObjectsWithTag("PlayerProjectile").Length == 0)
        {
            Instantiate(playerProjectile, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives -= 1;
        if (lives == 0)
        {

        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        foreach (var bullet in FindObjectsOfType<EnemyProjectile>())
        {
            Destroy(bullet.gameObject);
        }
        transform.position = new Vector3(0, -4.5f, 0);
=======
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    public Vector3 playerMoveDirection;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3 (inputX, inputY).normalized;

        animator.SetFloat("moveX", inputX);
        animator.SetFloat("moveY", inputY);

        if (playerMoveDirection == Vector3.zero)
            animator.SetBool("moving", false);
        else
            animator.SetBool("moving", true);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed * Time.deltaTime,
            playerMoveDirection.y * moveSpeed * Time.deltaTime);
>>>>>>> a15d925035833d7073165c87dfcb1f59d076c225
    }
}
