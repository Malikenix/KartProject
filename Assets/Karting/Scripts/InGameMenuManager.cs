using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KartGame.UI
{
    public class InGameMenuManager : MonoBehaviour
    {
        [Tooltip("Root GameObject of the menu UI")]
        public GameObject menuRoot;
        [Tooltip("Button to select when the menu is opened")]
        public Button firstSelectedButton;

        bool m_MenuActive;

        void Start()
        {
            menuRoot.SetActive(false);
            m_MenuActive = false;
        }

        void Update()
        {
            // Toggles menu with Escape key
            if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape))
            {
                SetMenuActivation(!m_MenuActive);
            }
        }

        public void SetMenuActivation(bool active)
        {
            m_MenuActive = active;
            menuRoot.SetActive(m_MenuActive);

            if (m_MenuActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f; // Pauses the game
                EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f; // Resumes the game
            }
        }
    }
}