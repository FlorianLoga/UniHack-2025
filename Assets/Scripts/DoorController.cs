using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Jucatorul a atins usa. Incarc scena: " + nextSceneName);

            SceneManager.LoadScene(nextSceneName);
        }
    }
}
