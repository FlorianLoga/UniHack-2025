using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float horizontalOffset = 1.5f;
    [SerializeField] private float verticalOffset = 0.5f;

    [SerializeField] private float verticalStart = 5.5f;
    [SerializeField] private float horizontalStart = -7f;

    [SerializeField] private float verticalMoveAmount = -0.5f;
    [SerializeField] private float horizontalMoveAmount = 0.25f;
    [SerializeField] private float moveDelay = 0.2f;

    [SerializeField] private float maxNumberOfSteps = 30f;
    private int currentSteps = 0;

    [SerializeField] GameObject enemy;

    private bool hasCollided = false;

    void Start()
    {
        SpawnEnemies();
        InvokeRepeating("MoveEnemies", 0.5f, moveDelay);
    }


    private void SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 pos = new Vector3(horizontalStart + j * horizontalOffset, verticalStart - i * verticalOffset, 0);
                Instantiate(enemy, pos, Quaternion.identity);
            }
        }
    }



    private void MoveEnemies()
    {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Vector3 currentPos = enemy.transform.position;
            enemy.transform.position = currentPos + new Vector3(horizontalMoveAmount, 0, 0);
        }
        currentSteps++;
        if (currentSteps >= maxNumberOfSteps)
        {
            currentSteps = 0;
            horizontalMoveAmount *= -1;
            Vector3 down = new Vector3(0, verticalMoveAmount, 0);
            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.transform.position -= down;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Wall" && !hasCollided)
    //    {
    //        hasCollided = true;
    //        Invoke(nameof(ResetHasCollided), 2f);
    //        horizontalMoveAmount *= -1;

    //        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
    //        {
    //            Vector3 currentPos = enemy.transform.position;
    //            enemy.transform.position = currentPos - new Vector3(0, verticalMoveAmount, 0);
    //        }
    //    }
    //}

    //private void ResetHasCollided()
    //{
    //    hasCollided = false;
    //}
}