using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
    }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    public Vector3 playerMoveDirection;

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
    }
}
