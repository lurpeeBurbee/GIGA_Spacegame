using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveQuiz : MonoBehaviour
{
    public void Leave()
    {

        // Vaihda t‰h‰n spawnpoint niin, ett‰ spawnaa edellisen planeetan viereen!
        // T‰m‰ ajetaan mm. silloin kun quizzista on p‰‰sty yksi rundi l‰pi!

        SceneManager.LoadScene("Map");
        Time.timeScale = 1;
    }

    public void LeaveToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
