﻿//Created by Matthew Collard
//Last Updated: 2024/04/04
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
//Save system for storing player information between sessions"
public class SaveSystem : MonoBehaviour
{
    private const string FileType = ".txt";
    private static string SavePath => Application.persistentDataPath + "/Saves/";
    private static string BackUpSavePath => Application.persistentDataPath + "/BackUps/";
    private static int SaveCount;

    //Saves the player's data into the application datapath directory. This location is unique for every device, and will be stored safely
    public static void SaveData<T>(T data, string fileName)
    {
        Directory.CreateDirectory(SavePath);
        Directory.CreateDirectory(BackUpSavePath);

        if (SaveCount % 5 == 0) Save(BackUpSavePath);
        Save(SavePath);

        SaveCount++;

        void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path + fileName + FileType))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream();
                formatter.Serialize(memoryStream, data);
                string dataToSave = Convert.ToBase64String(memoryStream.ToArray());
                writer.WriteLine(dataToSave);
                writer.Close();
            }
        }
    }
    //Loads stored data from memory, same file location as the save directory
    public static T LoadData<T>(string fileName)
    {
        Directory.CreateDirectory(SavePath);
        Directory.CreateDirectory(BackUpSavePath);

        bool backUpNeeded = false;
        T dataToReturn;

        Load(SavePath);
        if (backUpNeeded) Load(BackUpSavePath);

        return dataToReturn;

        void Load(string path)
        {
            using (StreamReader reader = new StreamReader(path + fileName + FileType))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string dataToLoad = reader.ReadToEnd();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(dataToLoad));

                try { dataToReturn = (T)formatter.Deserialize(memoryStream); }
                catch
                {
                    backUpNeeded = true;
                    dataToReturn = default;
                }
            }
        }
    }

    public static bool SaveExists(string fileName) =>
        File.Exists(SavePath + fileName + FileType)
        || File.Exists(BackUpSavePath + fileName + FileType);
    // If File.Exists gives an error, try System.IO.File

}
