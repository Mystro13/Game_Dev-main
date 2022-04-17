using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
   public PlayerHealth playerHealth;
   private GameObject sword;
   public void Execute()
   {
      sword = GameObject.Find("Sword");
      if (sword)
      {
         sword.SetActive(false);
         //sword.GetComponent<Rigidbody>().useGravity = false;
         //DetachFromParent();
         //AttachToParent(swordGrip);
         //EnableSword();
      }

      //if(playerHealth)
      //{
      //   playerHealth.ShowSword();
      //}

      //GameObject battleSword = GameObject.Find("BattleSword");
      //if(battleSword)
      //{
      //   battleSword.SetActive(true);
      //}
   }
   //void AttachToParent(GameObject newParent)
   //{
   //   sword.transform.position = newParent.transform.position;
   //   sword.transform.parent = newParent.transform; 
   //}
   //void DetachFromParent()
   //{
   //   sword.transform.parent = null;
   //}
   //void EnableSword()
   //{
   //   AimSwordScript aimSwordScript = sword.GetComponent<AimSwordScript>();
   //   if(aimSwordScript)
   //   {
   //      aimSwordScript.EnableSword();
   //   }
   //   sword.GetComponent<Rigidbody>().useGravity = true;
   //}
}
