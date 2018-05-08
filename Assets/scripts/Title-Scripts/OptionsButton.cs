using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionsButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject GameOptions = GameObject.Find("Canvas/OptionsButton");
        Button btn = (Button)GameOptions.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void onClick()
    {
        Application.LoadLevel("Options");
    }
}
