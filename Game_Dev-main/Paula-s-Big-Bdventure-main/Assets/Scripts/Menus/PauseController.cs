using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseController : MonoBehaviour
{
   void Update()
   {
      Keyboard keyboard = Keyboard.current;
      if (keyboard.backspaceKey.wasPressedThisFrame)
      {
         GameState currentGameState = GameStateManager.Instance.CurrentGameState;
         GameState newGameState = currentGameState == GameState.GamePlay
         ? GameState.Paused : GameState.GamePlay;

         GameStateManager.Instance.SetState(newGameState);
      }
   }
}

