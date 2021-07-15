using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

[Serializable]
public class SaveData
{
    public bool[] isActive;
    public int[] highScores;
    public int[] stars;
}

public class GameData : MonoBehaviour
{
    public static GameData gameData;
    public SaveData saveData;
    // Start is called before the first frame update
    void Awake()
    {
        if(gameData == null)
        {
            DontDestroyOnLoad(this.gameObject);
            gameData = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Load();
    }

    private void Start()
    {
       
    }

    [ContextMenu("Save")]
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Create);
        SaveData data = new SaveData();
        data = saveData;
        formatter.Serialize(file, data);
        file.Close();
        Debug.Log("saved");
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
            saveData = formatter.Deserialize(file) as SaveData;
            file.Close();
            Debug.Log("Loaded");
        }
        if(saveData.isActive.Length == 0) 
        {
            saveData.isActive = new bool[10];
            saveData.highScores = new int[10];
            saveData.stars = new int[10];
            saveData.isActive[0] = true;
        }
    } 
    
    private void OnDisable()
    {
        Save();
    }

    void Update()
    {

    }
}
