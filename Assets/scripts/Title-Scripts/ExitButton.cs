using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExitButton : MonoBehaviour {

    void Start()
    {
        GameObject ExitGame = GameObject.Find("Canvas/ExitButton");
        Button btn = (Button)ExitGame.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void onClick()
    {
        Application.Quit();
    }
}
