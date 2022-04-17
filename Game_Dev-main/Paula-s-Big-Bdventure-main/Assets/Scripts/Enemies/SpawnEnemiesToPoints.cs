using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesToPoints : MonoBehaviour
{
   public GameObject objectToSpawn;
   public GameObject objectParent;
   public Transform[] spawningPoints;
   bool enableSpawning;
   // Start is called before the first frame update
   void Awake()
   {
      foreach (Transform spawnPoint in spawningPoints)
      {
         GameObject enemyClone = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation, objectParent.transform);
         enemyClone.transform.localScale = new Vector3(.7f, .7f, .7f);
      }
   }
}