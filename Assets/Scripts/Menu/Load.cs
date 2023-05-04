using UnityEngine;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour
{
    #region Variables;
    [Tooltip("Used in interractive UI")] public GameObject interractionMenu; // Näyttää interractio menun pelissä
    [Tooltip("Used in interractive UI")] public GameObject examineMenu; // Avaa Examine menun, Examine napin painnalluksesta
    [Tooltip("Used in interractive UI")] public GameObject talkMenu; // Avaa Talk menun, Talk napin painnalluksesta
    [Tooltip("Name the scene name exactly how its written in scene folder!")] public string scenePath; // Scene pathin määrittely Unity Editorissa
    // public Movement2 player;
    #endregion

    #region Scene Loading
    // Main menu hallinoinnin scripti
    public void Menu() // Napin 'On Click ()' Load.Menu. Avaa unity editorrissa asetetun ScenePathin Scenen 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scenePath); // Muokataan editorissa
        // player.GetComponent<Movement2>().enabled = true;
        
        // GameObject.Find("PlayerScaler").GetComponent<Movement2>().enabled = true; // Etsii pelaajan scalerin ja enablee sen liike scriptin. NOTE: antaa erroria jos scaler ei ole scenessä.
        // Debug.Log("Etsittiin pelaajan prefab");
    }

    // public void LoadQuiz()
    // {
    //     SceneManager.LoadScene("Quiz");
    // }
    //
    public void ExitApplication() // Quit Button
    {
        Application.Quit();
    }

    public void Examine() // Napin 'On Click ()' Load.Examine
    {
        if (!examineMenu.activeInHierarchy)
        {
            examineMenu.SetActive(true);
            talkMenu.SetActive(false);
        }
        else
        {
            examineMenu.SetActive(false);
        }
    }
    public void Talk() // Napin 'On Click ()' Load.Talk
    {
        if (!talkMenu.activeInHierarchy)
        {
            talkMenu.SetActive(true);
            examineMenu.SetActive(false);
        }
        else
        {
            talkMenu.SetActive(false);
        }
    }

    public void Close() // Napin 'On Click ()' Load.Talk
    {
        interractionMenu.SetActive(false);
        GameObject.Find("PlayerScaler").GetComponent<Movement2>().enabled = true;
    }
    #endregion
}