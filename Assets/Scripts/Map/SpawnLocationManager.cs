using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLocationManager : MonoBehaviour
{

    [SerializeField]
    private SpawnLocationList spawnLocationList;

    public GameObject player;
    public string currentScene;
    public static string previousScene;

    GameObject SpawnArea;
  
    public static Transform SpawnAreaLocation;

    public Transform [] SpawnAreaList = new Transform[1];


    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;

        Debug.Log("Coming from the scene : " + previousScene);

        Debug.Log("Scene now is : " + currentScene);


        // Nämä määrittävät, minne space shuttle spawnaa kun tulee ulos planeetasta.
        // Vie Player kohdalle, johon haluat sen spawnautuvan ja kopioi Inspectorista oikeelta ylhäältä kolme pistettä Transform - > Copy -> Position (ei World)

        if (currentScene == "Map" && previousScene == "Earth")
        {
            player.transform.position = new Vector3(10, -3, 0);
        }
        if (currentScene == "Map" && previousScene == "Venus")
        {
            player.transform.position = new Vector3(4, -3.8f, 0f);
        }
        if (currentScene == "Map" && previousScene == "Mercury")
        {
            player.transform.position = new Vector3(-3.10f, -4.4f, 0); // <-- Pastee tähän Playerin position.
        }

        // jne.. 

        // + joka planeetan scenessä pitää raahata Playerin inspectoriin Spawn Location Manageriin Spawn Location List-kohdalle "SpawnLocation"-scriptableObject,
        // joka löytyy Scripts > ScriptableObjects-folderista


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.CompareTag("planetExitArea")) {

            previousScene = SceneManager.GetActiveScene().name;
            //if (SpawnArea != null)
            //{
             //  player.transform.position = SpawnArea.transform.position;
                SceneManager.LoadScene("Map");


            Debug.Log("Exiting planet");
         //   }
        }
    }


}
