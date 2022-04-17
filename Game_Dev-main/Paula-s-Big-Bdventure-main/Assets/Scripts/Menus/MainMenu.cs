
using UnityEngine;

public class MainMenu : MonoBehaviour
{

   public GameObject mainMenu;
   public GameObject levelMenu;
   public void StartGame()
   {
      InitializePlayerData();
      SceneLoader.instance.Load (SceneLoader.Scene.Cemetery);
      Debug.Log("Start Game");
   }
   public void StartMenu()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
      Debug.Log("Main Menu");
   }

   public void QuitGame()
   {
      Debug.Log("Quit Game");
      Application.Quit();
      //UnityEditor.EditorApplication.isPlaying = false;
   }

   public void GoToCemetery()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.Cemetery);
   }

   public void GoToCouncilRoom()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.CouncilRoom);
   }

   public void GoToFirstFloor()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.FirstFloor);
   }

   public void GoToSecondFloor()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.SecondFloor);
   }

   public void GoToThirdFloor()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.ThirdFloor);
   }

   public void GoToThrone()
   {
      InitializePlayerData();
      SceneLoader.instance.Load(SceneLoader.Scene.Throne);
   }

   public void SceneSelectorMenu()
   {
      if(mainMenu && levelMenu)
      {
         mainMenu.SetActive(false);
         levelMenu.SetActive(true);
      }
   }
   public void ShowMainMenu()
   {
      if (mainMenu && levelMenu)
      {
         mainMenu.SetActive(true);
         levelMenu.SetActive(false);
      }
   }
   void InitializePlayerData()
   {
      if (PlayerData.current == null)
      {
         PlayerData.current = new PlayerData();
      }
      SaveLoadData.Save();
   }
}
