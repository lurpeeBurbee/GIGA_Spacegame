using UnityEngine;

public class MMOptions : MonoBehaviour
{
    public GameObject options;
    public GameObject settingsB;

    #region Show options menu by button press
    public void OpenSettings()
    {
        if (!options.activeInHierarchy)
        {
            options.SetActive(true);
        }

    }
    public void CloseSettings()
    {
        if (options.activeInHierarchy)
        {
            options.SetActive(false);
        }
    }
    #endregion

}
