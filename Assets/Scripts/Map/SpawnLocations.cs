using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations : ScriptableObject
{
    public GameObject SpawnArea;

    public static Transform SpawnAreaLocation;

    public List<Transform> SpawnAreaList = new List<Transform>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SpawnAreaLocation = SpawnArea.transform;    
        SpawnAreaList.Add(SpawnAreaLocation);
        Debug.Log("Static Spawnarealocation : " + SpawnAreaLocation);
    }


}
