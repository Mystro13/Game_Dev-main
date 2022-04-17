using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerData
{
   public bool hasSwordData;
   public int healthData;
   public int keySlotData;
   public int manaSlotData;
   public int ammoSlotData;
   public int healthPotionSlotData;
   public int permaHealthSlotData;
   public float AudioVolume;
   public float EFXVolume;
   public float CameraSensitivity;

   public PlayerData()
   {
      hasSwordData = false;
      healthData = 0;
      keySlotData = 0;
      manaSlotData = 0;
      ammoSlotData = 0;
      healthPotionSlotData = 0;
      permaHealthSlotData = 0;
      AudioVolume = .2f;
      EFXVolume = .2f;
      CameraSensitivity = .2f;
   }
   public static PlayerData current;
}
