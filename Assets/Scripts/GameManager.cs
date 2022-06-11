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

    private string path;

    [Serializable] class SaveData
    {
        public string Username;
        public int currentBestScore;
    }

    public void SaveGame(int currentScore)
    {
        if(currentScore > bestScore)
        {
            SaveData data = new SaveData();
            data.Username = Username;
            data.currentBestScore = bestScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
    }

    public void LoadGame()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Username = data.Username;
            bestScore = data.currentBestScore;
        }
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
}
