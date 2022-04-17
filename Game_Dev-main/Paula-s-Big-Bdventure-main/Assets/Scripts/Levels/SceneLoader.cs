using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Text;

public class SceneLoader:MonoBehaviour
{
   public static SceneLoader instance;
   public enum Scene
   {
      MainMenu,
      Cemetery,
      FirstFloor,
      CouncilRoom,
      SecondFloor,
      ThirdFloor,
      Throne,
   }

   //sliders
   public Slider AudioVolumeSlider;
   public Slider EFXVolumeSlider;
   public Slider CameraSensitivitySlider;
   public float MaxAudioVolume  = 10;
   public float MaxEFXVolume = 10;
   public float MaxCameraSensitivity = 10;
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

   //We may need to save the full player between scenes
   GameObject savedPlayer;
   PlayerInteraction playerInteraction;
   //When we save player between scene, we need to define where to spawn the player in the next scene.
   //We could use the scene loader object as the place to spawn the player
   public Transform playerSceneTarget;
   public void Load(Scene scene)
   {
      //SaveLoadData.Save();
      SceneManager.LoadScene(scene.ToString());
      //SaveLoadData.Load();
      //if (savedPlayer)
      //{
      //   playerInteraction = savedPlayer.GetComponent<PlayerInteraction>();
      //   if (playerInteraction)
      //   {
      //      playerInteraction.SetPlayerData(PlayerData.current);
      //   }
      //}
   }

   void Awake()
   {
      if (instance == null)
      {
         DontDestroyOnLoad(gameObject);
         instance = this;
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
         if (AudioVolumeSlider != null)
         {
            AudioVolumeSlider.value = AudioVolume;
         }
         if (EFXVolumeSlider != null)
         {
            EFXVolumeSlider.value = EFXVolume;
         }
         if (CameraSensitivitySlider != null)
         {
            CameraSensitivitySlider.value = CameraSensitivity;
         }
      }
      else if (instance != this)
      {
         GameObject canvas = GameObject.Find("Canvas");
         if(canvas)
         {
            foreach (var slider in canvas.transform.GetComponentsInChildren<Slider>(includeInactive: true))
            {
               Debug.Log($"slider {slider.name}");
               string sliderName = slider.name;
               if (sliderName.ToUpper().Contains("AUDIOVOLUME"))
               {
                  slider.value = instance.AudioVolume;
                  instance.AudioVolumeSlider = slider;
                  //AudioVolumeSlider.value = AudioVolume;
               }
               else if (sliderName.ToUpper().Contains("EFX"))
               {
                  slider.value = instance.EFXVolume;
                  instance.EFXVolumeSlider = slider;
                  //EFXVolumeSlider.value = EFXVolume;
               }
               else if (sliderName.ToUpper().Contains("CAMERA"))
               {
                  slider.value = instance.CameraSensitivity;
                  instance.CameraSensitivitySlider = slider;
                  //CameraSensitivitySlider.value = CameraSensitivity;
               }
            }
         }
         Destroy(gameObject);
      }

      if (playerSceneTarget == null)
         playerSceneTarget = gameObject.transform;

      //if (gameObject)
      //{
      //   if (PlayerData.current != null)
      //   {
      //      AudioVolume.value = PlayerData.current.AudioVolume;
      //      EFXVolume.value = PlayerData.current.EFXVolume;
      //      CameraSensitivity.value = PlayerData.current.CameraSensitivity;
      //   }
      //}
   }

   public void AssignPlayer(GameObject player)
   {
      savedPlayer = player;
   }

   void Update()
   {
      //Debug.Log($"Mouse sensitivity {CameraSensitivitySlider.value * MaxCameraSensitivity}");
   }
}
