using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject options;
    public GameObject settingsB;
  



    private void Update()
    {
        #region Show options menu by key input
        if (!options.activeInHierarchy)
        {
            if (Input.GetKeyDown("escape"))
            {
                options.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        else
        {
            if (Input.GetKeyDown("escape"))
            {
                options.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        #endregion

        #region Show Settings Button when options active
        if (!options.activeInHierarchy)
        {
            settingsB.SetActive(true);
        }
        if (options.activeInHierarchy)
        {
            settingsB.SetActive(false);
        }
        #endregion
    }

    #region Show options menu by button press
    public void OpenSettings()
    {
        if (!options.activeInHierarchy)
        {
            options.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    public void CloseSettings()
    {
        if (options.activeInHierarchy)
        {
            options.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    #endregion

}
