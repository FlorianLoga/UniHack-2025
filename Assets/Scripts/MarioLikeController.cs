using UnityEngine;

public class MarioLikeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    public Vector3 playerMoveDirection;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3(inputX, inputY).normalized;

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
            playerMoveDirection.y * jumpSpeed * Time.deltaTime);
    }
}
