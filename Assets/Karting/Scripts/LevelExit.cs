using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object hitting the finish line is the Player
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}