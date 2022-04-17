using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStockUp : MonoBehaviour
{
   [SerializeField] private List<GameObject> stockItems;
   [SerializeField] private int capacity = 10;
   //[SerializeField] private int ammoMaxStock = 1;
   private int manaMaxStock = 1;
   private int healthPotionMaxStock = 1;
   private int permaHealthMaxStock = 1;
   //[SerializeField] private GameObject ammoObject;
   [SerializeField] private GameObject manaObject;
   [SerializeField] private GameObject healthPotionObject;
   [SerializeField] private GameObject permaHealthObject;
   public bool hasStockedUp = false;
   public void StockUp()
   {
      capacity = 1;
      hasStockedUp = true;
      stockItems = new List<GameObject>();
      //ExecuteStockUpOn(ammoObject, ammoMaxStock);
      UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
      int selection = UnityEngine.Random.Range(0, 3);
      selection = 1;
      switch (selection)
      {
         case 0: ExecuteStockUpOn(manaObject, manaMaxStock); break;
         case 1: ExecuteStockUpOn(healthPotionObject, healthPotionMaxStock); break;
         case 2: ExecuteStockUpOn(permaHealthObject, permaHealthMaxStock); break;
      }
   }
   public void DropItems()
   {
      hasStockedUp = false;
      Debug.Log($"Drop items {stockItems.Count}");
      foreach (GameObject dropping in stockItems)
      {
         Debug.Log($"Drop- {dropping.tag}");
         dropping.transform.position = GeneratedPosition(gameObject.transform.position);
         dropping.transform.rotation = gameObject.transform.rotation;
         dropping.transform.parent = null;
         dropping.SetActive(true);


         var bCol = dropping.AddComponent<BoxCollider>();
         bCol.isTrigger = true;

         var rb = dropping.AddComponent<Rigidbody>();
         //rb.isKinematic = true;
         rb.useGravity = true;
         dropping.AddComponent<InteractionObject>();

         InteractionObject interactionObject = dropping.GetComponent<InteractionObject>();
         if (interactionObject != null)
         {
            Debug.Log("Drop interaction object script");
            interactionObject.interactionType = InteractionType.Dropping;
         }
      }
      stockItems = new List<GameObject>();
   }
   void ExecuteStockUpOn(GameObject stockItemObject, int maximum)
   {
      Debug.Log($"Stock {stockItems.Count} {capacity} {maximum}");
      if (stockItems.Count < capacity)
      {
         GameObject clone = Instantiate(stockItemObject, transform.position, transform.rotation, gameObject.transform);
         StockItem stockItem = clone.GetComponent<StockItem>();
         if (stockItem)
         {
            clone.SetActive(false);
            stockItem.quantity = 1;
            stockItems.Add(clone);
         }
      }
   }

   Vector3 GeneratedPosition(Vector3 centralPosition)
   {
      float x, y, z;
      x = UnityEngine.Random.Range(-3f, 3f);
      y = 0f;
      z = UnityEngine.Random.Range(-3f, 3f);
      return new Vector3(x, y, z) + centralPosition;
   }
}
