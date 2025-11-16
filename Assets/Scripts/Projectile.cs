using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isEnemy;

    //void Update()
    //{
    //    transform.Translate(Vector2.up * speed * Time.deltaTime);
    //}
    

      void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, isEnemy ? -1 * speed * Time.deltaTime : 1 * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (!isEnemy && collision.gameObject.tag == "Enemy")
        {
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            // PlayerController playerController = player.GetComponent<PlayerController>();
            print("hit into enemy");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (isEnemy == true && collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
