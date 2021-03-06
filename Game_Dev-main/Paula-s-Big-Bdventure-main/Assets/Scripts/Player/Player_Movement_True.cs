using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Player_Movement_True : MonoBehaviour
{
   public float speed = 7.5f;
   public float jumpSpeed = 8.0f;
   public float gravity = 20.0f;
   public Transform playerCameraParent;
   public float lookXLimit = 60.0f;
   private float turner;
   private float looker;
   public float sensitivity = 2.0f;

   CharacterController characterController;
   Vector3 moveDirection = Vector3.zero;
   Vector2 rotation = Vector2.zero;

   [HideInInspector]
   public bool canMove = true;

   private void Awake()
   {
      GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
   }
   void OnDestroy()
   {
      GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
   }
   private void OnGameStateChanged(GameState newGameState)
   {
      enabled = (newGameState == GameState.GamePlay);
   }

   void Start()
   {
      characterController = GetComponent<CharacterController>();
      rotation.y = transform.eulerAngles.y;
   }

   void Update()
   {
      if (SceneLoader.instance == null)
      {
         return;
      }
      // Control input with WASD + Mouse
      Keyboard keyboard = Keyboard.current;
      Mouse mouse = Mouse.current;
      if (characterController.isGrounded)
      {
         // We are grounded, so recalculate move direction based on axes
         Vector3 forward = transform.TransformDirection(Vector3.forward);
         Vector3 right = transform.TransformDirection(Vector3.right);
         float vertical = keyboard.wKey.ReadValue() - keyboard.sKey.ReadValue();
         float horizontal = keyboard.dKey.ReadValue() - keyboard.aKey.ReadValue();
         float curSpeedX = canMove ? speed * vertical : 0;
         float curSpeedY = canMove ? speed * horizontal : 0;
         moveDirection = (forward * curSpeedX) + (right * curSpeedY);


         //if (Input.GetButton("Jump") && canMove)
         if (keyboard.spaceKey.ReadValue() > 0f && canMove)
         {
            moveDirection.y = jumpSpeed;
         }
      }

      turner = mouse.delta.x.ReadValue() * SceneLoader.instance.CameraSensitivity * SceneLoader.instance.MaxCameraSensitivity;
      looker = mouse.delta.y.ReadValue() * SceneLoader.instance.CameraSensitivity * SceneLoader.instance.MaxCameraSensitivity;
      if (turner != 0)
      {
         //Code for action on mouse moving right
         transform.eulerAngles += new Vector3(0, turner, 0);
      }
      if (looker != 0)
      {
         //Code for action on mouse moving right
         transform.eulerAngles += new Vector3(looker, 0, 0);
      }
      // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
      // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
      // as an acceleration (ms^-2)
      moveDirection.y -= gravity * Time.deltaTime;

      // Move the controller
      characterController.Move(moveDirection * Time.deltaTime);

      // Player and Camera rotation
      if (canMove)
      {
         rotation.y += turner;
         rotation.x += -looker;
         rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
         playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
         transform.eulerAngles = new Vector2(0, rotation.y);
      }
   }
}
