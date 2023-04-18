using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveQuiz : MonoBehaviour
{
    public void Leave()
    {
        SceneManager.LoadScene("Map");
        Time.timeScale = 1;
    }

    public void LeaveToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
