using UnityEngine;

public class QuizPauseScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject leaveConfirm;
    public GameObject OptionsMenu;
    // These game objects need to be disabled in the inspector!

    public void PauseQuiz()
    {
        Time.timeScale = 0;
        Debug.Log("Timescale is now set to 0 (Pause-button was pressed).");
        pauseMenu.SetActive(true);
    }

    public void ResumeQuiz()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Timescale is now set to 1 (Resume-button in pause menu was pressed).");
    }

    public void LeaveConfirm()
    {
        leaveConfirm.SetActive(true);
    }

    public void LeaveCancel()
    {
        leaveConfirm.SetActive(false);
    }

    public void OptionsOpen()
    {
        OptionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void OptionsClose()
    {
        OptionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}