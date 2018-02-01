using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour {

	// Use this for initialization

	public GameObject[] lootObjects;// objects which can be dropped as loot
	public GameObject[] cashGo;
		
		
	public int chance;
		
		
		public void DropLoot(Vector3 dropPosition)
		{
			chance = Random.Range(1, 100); // Adds another chance to spawn an item
			if (chance > 1 && chance < 50) // 50% chance
			{
				// create a random number
				int lootNumber = Random.Range(0, lootObjects.Length);
				// create a new gameobject on the position of the enemy
				GameObject loot = (GameObject)Instantiate(lootObjects[lootNumber], dropPosition, Quaternion.EulerRotation(-90, 0, 0));
				Debug.Log("Loot obj to spawn" + lootNumber);
			}
			Debug.Log("Change to spawn" + chance);
		}
		
		
}

