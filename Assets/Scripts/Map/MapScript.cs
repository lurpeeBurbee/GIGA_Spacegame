using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    private Transform playerPos;
    private GameManager gm;
    public List<Transform> spawns;

    private void Awake()
    {
        playerPos = GameObject.Find("PlayerScaler").transform;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Start()
    {
        // gm.CheckCurrentPlanet();
        // // Setting where the player spawns when the scene loads
        playerPos.position = spawns[gm.currentPlanet].position;
        Debug.Log("Loaded player in spawn " + gm.currentPlanet);
    }
}
