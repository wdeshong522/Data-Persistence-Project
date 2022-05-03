using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;

    public int m_Points;
    public string highscoreName;
    public int highscorePoints;
    public string nameInput;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }

    [System.Serializable]
    class SaveDataFile
    {
        public string name;
        public int m_Points;
    }

    public void SaveHighscore()
    {
        SaveDataFile data = new SaveDataFile();
        data.m_Points = m_Points;
        data.name = nameInput;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataFile data = JsonUtility.FromJson<SaveDataFile>(json);

            highscorePoints = data.m_Points;
            highscoreName = data.name;
        }
        else
        {
            highscorePoints = 0;
            highscoreName = "";
        }
    }
}
