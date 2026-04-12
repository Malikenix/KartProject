using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelExit : MonoBehaviour
{
    // This line creates the slot in the Inspector
    public GameObject finishMessage;

    void Start()
    {
        // This hides the default Win UI as soon as the game starts
        // so it doesn't interfere with your custom "Level 1 Finished" text.
        GameObject winUI = GameObject.Find("WinSceneCanvas");
        if (winUI != null)
        {
            winUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Checks if the Kart (tagged "Player") hits the finish line or last checkpoint
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        // Double-check to hide the default win UI again just in case the GameManager 
        // tries to re-enable it when objectives are met.
        GameObject winUI = GameObject.Find("WinSceneCanvas");
        if (winUI != null) winUI.SetActive(false);

        // Show your custom "LEVEL 1 FINISHED!" message
        if (finishMessage != null)
        {
            finishMessage.SetActive(true);
        }

        // Wait for 3 seconds so the player can see the message
        yield return new WaitForSeconds(3f);

        // Load the next scene. Ensure "Level2" is added in Build Settings.
        SceneManager.LoadScene("Level2");
    }
}