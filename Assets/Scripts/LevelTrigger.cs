using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private CollectibleCount collectibleCount; // Reference to the CollectibleCount script
    private const int requiredScore = 5; // The score required to unlock the next level

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the collider is the player
        {
            if (collectibleCount.GetScore() >= requiredScore)
            {
                // Load the scene named "End"
                SceneManager.LoadScene("Main Menu");
            }
            else
            {
                Debug.Log("Collect more items to unlock the next level!");
            }
        }
    }
}
