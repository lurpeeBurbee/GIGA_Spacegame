using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    private List<Dictionary<string, object>> data;
    private List<Button> buttonsList;
    private List<TMP_Text> buttonTexts;
    public int currentQuestion;
    private int newQuestion, randomBackground;
    private int currentButton;
    public int answersToComplete = 10; // How many correct answers player needs to give
    public Button correctButton;
    private Button button1, button2, button3, button4;
    private TMP_Text button1text, button2text, button3text, button4text;
    private TMP_Text questionText, scoreText;
    private GameObject popUpComplete;
    public Animator correctAnimator, wrongAnimator;

    public GameObject Truck;
    private TruckLoaderScript truckLoaderScript;
    public GameObject panelBar, QuizCanvas, endScreen, bg1, bg2, bg3;
    public GameObject[] endScreenBackgrounds;
    public GameManager gm;
    private ScoreScript scoreScript;

    public AudioSource audioSource;
    public AudioClip correctSound, quizComplete;



    void Awake()
    {
        panelBar = GameObject.Find("PanelBar");
        Truck = GameObject.Find("Truck");
        scoreScript = QuizCanvas.GetComponent<ScoreScript>();
        truckLoaderScript = Truck.GetComponent<TruckLoaderScript>();

        button1 = GameObject.Find("Answer1").GetComponent<Button>();
        button2 = GameObject.Find("Answer2").GetComponent<Button>();
        button3 = GameObject.Find("Answer3").GetComponent<Button>();
        button4 = GameObject.Find("Answer4").GetComponent<Button>();

        button1text = GameObject.Find("AnswerText1").GetComponent<TMP_Text>();
        button2text = GameObject.Find("AnswerText2").GetComponent<TMP_Text>();
        button3text = GameObject.Find("AnswerText3").GetComponent<TMP_Text>();
        button4text = GameObject.Find("AnswerText4").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();

        questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();

        popUpComplete = GameObject.Find("PopUpComplete");
        popUpComplete.SetActive(false);
        endScreen.SetActive(false);
        bg1.SetActive(false);
        bg2.SetActive(false);
        bg3.SetActive(false);

        data = new List<Dictionary<string, object>>();
        // Filling the list with the stuff from file QuizQuestions.csv
        data = CSVReader.Read("QuizQuestions");
        // prints into console QuizQuestions.csv 's data, so this bit is not strictly necessary, but it's nice 
        for (var i = 0; i < data.Count; i++)
        {
            print("Nro " + data[i]["Nro"] + " " +
                   "Question " + data[i]["Question"] + " " +
                   "CorrectAnswer " + data[i]["CorrectAnswer"] + " " +
                   "False1 " + data[i]["False1"] + " " +
                   "False2 " + data[i]["False2"] + " " +
                   "False3 " + data[i]["False3"]);
        }
        // Getting our first quiz round
        UpdateQuiz();
    }

    void Start()
    {
        // These will check the answer when a button is pressed
        button1.onClick.AddListener(CheckButton1);
        button2.onClick.AddListener(CheckButton2);
        button3.onClick.AddListener(CheckButton3);
        button4.onClick.AddListener(CheckButton4);
    }

   /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowEndScreen();
        }


    } */

    void UpdateQuiz()
    {
        GetNewQuestion();
        // Update the question text
        questionText.text = data[currentQuestion]["Question"].ToString();
        // Listing our buttons for randomizing answers
        buttonsList = new List<Button>();
        buttonsList.Add(button1);
        buttonsList.Add(button2);
        buttonsList.Add(button3);
        buttonsList.Add(button4);
        // Listing our buttons' texts in the same way to update them at the same time with the buttons
        buttonTexts = new List<TMP_Text>();
        buttonTexts.Add(button1text);
        buttonTexts.Add(button2text);
        buttonTexts.Add(button3text);
        buttonTexts.Add(button4text);
        // Getting a button for the correct answer
        currentButton = UnityEngine.Random.Range(0, buttonsList.Count);
        correctButton = buttonsList[currentButton];
        // Setting the text for the correct answer
        buttonTexts[currentButton].text = data[currentQuestion]["CorrectAnswer"].ToString();
        // In order to not pick the same button for the next answer, we remove it from the list (the text as well)
        buttonsList.RemoveAt(currentButton);
        buttonTexts.RemoveAt(currentButton);
        // Picking a button for 1st wrong answer
        currentButton = UnityEngine.Random.Range(0, buttonsList.Count);
        buttonTexts[currentButton].text = data[currentQuestion]["False1"].ToString();
        buttonsList.RemoveAt(currentButton);
        buttonTexts.RemoveAt(currentButton);
        // And for the second
        currentButton = UnityEngine.Random.Range(0, buttonsList.Count);
        buttonTexts[currentButton].text = data[currentQuestion]["False2"].ToString();
        buttonsList.RemoveAt(currentButton);
        buttonTexts.RemoveAt(currentButton);
        // And the third
        currentButton = UnityEngine.Random.Range(0, buttonsList.Count);
        buttonTexts[currentButton].text = data[currentQuestion]["False3"].ToString();
        buttonsList.RemoveAt(currentButton);
        buttonTexts.RemoveAt(currentButton);
        // And now let's make sure the lists are empty for sure for the next round
        buttonsList.Clear();
        buttonTexts.Clear();
    }

    void CheckButton1()
    {
        if (button1 != correctButton)
            AnswerWrong();
        else
            AnswerCorrect();
    }

    void CheckButton2()
    {
        if (button2 != correctButton)
            AnswerWrong();
        else
            AnswerCorrect();
    }

    void CheckButton3()
    {
        if (button3 != correctButton)
            AnswerWrong();
        else
            AnswerCorrect();
    }

    void CheckButton4()
    {
        if (button4 != correctButton)
            AnswerWrong();
        else
            AnswerCorrect();
    }

    void AnswerCorrect()
    {
        print("Correct!");
        // Updating score
        scoreScript.AddToScore();
        // Adding progress
        truckLoaderScript.progress += truckLoaderScript.maxProgress / answersToComplete;
        // loading items to truck!
        if (truckLoaderScript.progress > truckLoaderScript.fill)
        {
            truckLoaderScript.LoadNewItem();
            Mathf.RoundToInt(truckLoaderScript.fill += 100 / truckLoaderScript.maxFill);
        }

        // popping up a check mark pop up
        correctAnimator.SetTrigger("OnCorrectAnswer");
        // Playing a sound
        audioSource.PlayOneShot(correctSound);
        // Checking if we have enough correct answers to end the game
        if (truckLoaderScript.progress >= truckLoaderScript.maxProgress)
        {
            // Game is ending!
            // Update score text!
            scoreText.text = (Mathf.RoundToInt(ScoreScript.score)).ToString();
            // Updating player score and planet cleared into GameManager
            // gm.scoreList[gm.currentPlanet - 1] = (Mathf.RoundToInt(ScoreScript.score));
            // gm.planetStatus[gm.currentPlanet - 1] = 1;
            // gm.Save();
            // Play a sound to celebrate!
            audioSource.PlayOneShot(quizComplete);
            // Kill the listeners so answer buttons stop working
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button3.onClick.RemoveAllListeners();
            button4.onClick.RemoveAllListeners();
            // Pop up the -game complete- pop up
            popUpComplete.SetActive(true);
        }
        else
        {
            // We get ready for a new round
            // First we remove the current question from the pool so it doesnt repeat
            data.RemoveAt(currentQuestion);
            UpdateQuiz();
        }
    }

    void AnswerWrong()
    {
        scoreScript.ReducePoints();
        print("Wrong answer!");
        wrongAnimator.SetTrigger("OnWrongAnswer");
        UpdateQuiz();
    }

    void GetNewQuestion()
    {
        newQuestion = UnityEngine.Random.Range(0, data.Count);
        // The if is here to make sure the while loop doesnt do weird stuff when there is only one question left
        if (data.Count > 1)
        {
            while (newQuestion == currentQuestion)
            {
                newQuestion = UnityEngine.Random.Range(0, data.Count);
            }
        }
        currentQuestion = newQuestion;
        print("currentQuestion has been set to question " + currentQuestion + ".");
    }

    void ShowEndScreen()
    {
        endScreen.SetActive(true);
        randomBackground = UnityEngine.Random.Range(0, endScreenBackgrounds.Length);
        Debug.Log("Rolled a random background with the index of " + randomBackground);
        endScreenBackgrounds[randomBackground].SetActive(true);
    }
}