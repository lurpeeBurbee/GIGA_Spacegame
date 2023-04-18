using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlanetLoad : MonoBehaviour
{
    #region Variables;
    [Header("Desired scene name")]
    [Tooltip("Name the scene name exactly how it's written in the scene folder!")] public string scenePath;
    #endregion

    #region Scene Loading
    // Main menu Control script

    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(scenePath);
        Time.timeScale = 1f;
    }
    #endregion
}