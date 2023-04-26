using UnityEngine;

public class QuitTheGame : MonoBehaviour
{
    public GameObject QuitGameWindow; //ex-options
    public GameObject QuitButton; //ex-settingsB



    private void Update()
    {
        #region Show QuitGameWindow menu by key input
        if (!QuitGameWindow.activeInHierarchy)
        {
            if (Input.GetKeyDown("escape"))
            {
                QuitGameWindow.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        else
        {
            if (Input.GetKeyDown("escape"))
            {
                QuitGameWindow.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        #endregion

        #region Show QuitButton when QuitGameWindow active
        if (!QuitGameWindow.activeInHierarchy)
        {
            QuitButton.SetActive(true);
        }
        if (QuitGameWindow.activeInHierarchy)
        {
            QuitButton.SetActive(false);
        }
        #endregion
    }

    #region Show options menu by button press
    public void OpenQuitMenu()
    {
        if (!QuitGameWindow.activeInHierarchy)
        {
            QuitGameWindow.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    public void CloseQuitMenu()
    {
        if (QuitGameWindow.activeInHierarchy)
        {
            QuitGameWindow.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    #endregion

}
