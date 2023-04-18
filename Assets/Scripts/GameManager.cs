using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    #region Variables
    // public int cargo;

    public static GameManager manager;
    #endregion

    public int currentPlanet;
    public List<int> planetStatus;
    [NonSerialized]
    public int Planet1, Planet2, Planet3, Planet4, Planet5, Planet6, Planet7, Planet8, Planet9;
    public List<int> scoreList;
    [NonSerialized]
    public int planet1Score, planet2Score, planet3Score, planet4Score, planet5Score, planet6Score, planet7Score, planet8Score, planet9Score, userVol;

    private void Awake()
    {

        Application.targetFrameRate = 60;
        //Screen.SetResolution(1920, 1080, true, 60);
        #region Check managers

        Debug.Log("Checking & destroying other GameManagers...");

        // Luodaan Manageri ja tsekataan, onko toinen olemassa ja tuhotaan toinen. 
        if (manager == null)
        {
            // Jos ei ole manageria kerrotaan, etta tama luokka on manageri.
            // Kerrotaan, etta tama manageri ei saa tuhoutua jos scene vaihtuu toiseen. 
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            // Jos on olemassa manageri, niin silloin tama manageri on toinen manageri ja se on liikaa!
            // Joten tama manageri tuhotaan pois, jolloin ja vain se ensimmainen jaljelle. 
            Destroy(gameObject);
            return;
        }
        #endregion

        scoreList.Add(planet1Score);
        scoreList.Add(planet2Score);
        scoreList.Add(planet3Score);
        scoreList.Add(planet4Score);
        scoreList.Add(planet5Score);
        scoreList.Add(planet6Score);
        scoreList.Add(planet7Score);
        scoreList.Add(planet8Score);
        scoreList.Add(planet9Score);

        planetStatus.Add(Planet1);
        planetStatus.Add(Planet2);
        planetStatus.Add(Planet3);
        planetStatus.Add(Planet4);
        planetStatus.Add(Planet5);
        planetStatus.Add(Planet6);
        planetStatus.Add(Planet7);
        planetStatus.Add(Planet8);
        planetStatus.Add(Planet9);

    }

    // Save game
    public void Save()
    {
        Debug.Log("Game Saved");
        BinaryFormatter bf = new();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData playerData = new();
        playerData.currentPlanet = currentPlanet;
        playerData.Planet1 = Planet1;
        playerData.Planet2 = Planet2;
        playerData.Planet3 = Planet3;
        playerData.Planet4 = Planet4;
        playerData.Planet5 = Planet5;
        playerData.Planet6 = Planet6;
        playerData.Planet7 = Planet7;
        playerData.Planet8 = Planet8;
        playerData.Planet9 = Planet9;
        playerData.planet1Score = planet1Score;
        playerData.planet2Score = planet2Score;
        playerData.planet3Score = planet3Score;
        playerData.planet4Score = planet4Score;
        playerData.planet5Score = planet5Score;
        playerData.planet6Score = planet6Score;
        playerData.planet7Score = planet7Score;
        playerData.planet8Score = planet8Score;
        playerData.planet9Score = planet9Score;
        playerData.userVol = userVol;

        bf.Serialize(file, playerData);
        file.Close();
    }

    // Load saved game
    public void Load()
    {
        // Checking if we have a safe file we can load
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Debug.Log("Game Loaded");
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            file.Close();
            currentPlanet = playerData.currentPlanet;
            Planet1 = playerData.Planet1;
            Planet2 = playerData.Planet2;
            Planet3 = playerData.Planet3;
            Planet4 = playerData.Planet4;
            Planet5 = playerData.Planet5;
            Planet6 = playerData.Planet6;
            Planet7 = playerData.Planet7;
            Planet8 = playerData.Planet8;
            Planet9 = playerData.Planet9;
            planet1Score = playerData.planet1Score;
            planet2Score = playerData.planet2Score;
            planet3Score = playerData.planet3Score;
            planet4Score = playerData.planet4Score;
            planet5Score = playerData.planet5Score;
            planet6Score = playerData.planet6Score;
            planet7Score = playerData.planet7Score;
            planet8Score = playerData.planet8Score;
            planet9Score = playerData.planet9Score;
            userVol = playerData.userVol;
        }
    }

    // Data that gets saved
    [Serializable]
    class PlayerData
    {
        public int currentPlanet;
        public int Planet1, Planet2, Planet3, Planet4, Planet5, Planet6, Planet7, Planet8, Planet9;
        public int planet1Score, planet2Score, planet3Score, planet4Score, planet5Score, planet6Score, planet7Score, planet8Score, planet9Score, userVol;
    }
}
