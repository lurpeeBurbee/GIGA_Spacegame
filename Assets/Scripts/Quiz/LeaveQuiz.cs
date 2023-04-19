using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveQuiz : MonoBehaviour
{
    public void Leave()
    {

        // Vaihda tähän spawnpoint niin, että spawnaa edellisen planeetan viereen!
        SceneManager.LoadScene("Map");
        Time.timeScale = 1;
    }

    public void LeaveToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
