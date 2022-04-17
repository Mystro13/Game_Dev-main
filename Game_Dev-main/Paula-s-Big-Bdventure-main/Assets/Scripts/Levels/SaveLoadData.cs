using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadData
{
   // save and load player data from
   // https://github.com/tutsplus/unity-savegames#
   public static PlayerData savedData = new PlayerData();
   private const string FILENAME = "GameData.GD";
   //it's static so we can call it from anywhere
   public static void Save()
   {
      string fileData = Path.Combine(Application.persistentDataPath, FILENAME);
      SaveLoadData.savedData = PlayerData.current;
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(fileData);
      bf.Serialize(file, SaveLoadData.savedData);
      file.Close();
   }

   public static void Load()
   {
      string fileData = Path.Combine(Application.persistentDataPath, FILENAME);
      if (File.Exists(fileData))
      {
         BinaryFormatter bf = new BinaryFormatter();
         FileStream file = File.Open(Path.Combine(Application.persistentDataPath, FILENAME), FileMode.Open);
         SaveLoadData.savedData = (PlayerData)bf.Deserialize(file);
         file.Close();
         PlayerData.current = SaveLoadData.savedData;
      }
   }
}
