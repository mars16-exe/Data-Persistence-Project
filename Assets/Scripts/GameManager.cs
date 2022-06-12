using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string Username;
    public int bestScore;
    public string currentPlayer;

    private string path;

    [Serializable] class SaveData
    {
        public string currentBestplayer;
        public int currentBestScore;
    }

    private void Awake()
    {
        path = Application.persistentDataPath + "/saveData.json";

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SaveGame()
    {
            SaveData data = new SaveData();
            data.currentBestplayer = currentPlayer;
            data.currentBestScore = bestScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
    }

    public void LoadGame()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Username = data.currentBestplayer;
            bestScore = data.currentBestScore;
        }
    }
}
