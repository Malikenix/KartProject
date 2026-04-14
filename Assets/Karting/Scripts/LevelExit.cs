using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelExit : MonoBehaviour
{
    public GameObject finishMessage;
    public string nextSceneName;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if the thing hitting the trigger is the Kart or Player
        if (!hasTriggered && (other.CompareTag("Player") || other.gameObject.name.Contains("Kart")))
        {
            hasTriggered = true;
            Debug.Log("🏁 FINISH LINE HIT! Loading: " + nextSceneName);

            // Show your custom "LEVEL 1 FINISHED" UI
            if (finishMessage != null) finishMessage.SetActive(true);

            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        // Wait 3 seconds for the player to see the message
        yield return new WaitForSeconds(3f);

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("❌ Scene name is empty in the Inspector!");
        }
    }
}