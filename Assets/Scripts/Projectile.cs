using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Rigidbody2D rb;


    //void Update()
    //{
    //    transform.Translate(Vector2.up * speed * Time.deltaTime);
    //}
    

      void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, 1 * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
