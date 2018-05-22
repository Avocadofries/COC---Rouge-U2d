using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject StartGame = GameObject.Find("Canvas/StartButton");
        Button btn = (Button)StartGame.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
	}
	
	// Update is called once per frame
	void onClick () {
        Destroy(menubgm.clone);
        Application.LoadLevel("Scene-Bornroom");
    }
}
