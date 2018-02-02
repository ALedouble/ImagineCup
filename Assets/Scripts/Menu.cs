using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public EventSystem ES;
	private GameObject storeSelected;

	// Use this for initialization
	void Start () {
		storeSelected = ES.firstSelectedGameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (ES.currentSelectedGameObject != storeSelected) {
			if (ES.currentSelectedGameObject == null) 
				ES.SetSelectedGameObject (storeSelected);
	
			else
				storeSelected = ES.currentSelectedGameObject;
			}
		}


	public void Play(){
		SceneManager.LoadScene ("Proto 1");
	}

	public void Quit(){
		Application.Quit ();
	}
}
