using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    // Lataa Main Menu Scripti
    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}