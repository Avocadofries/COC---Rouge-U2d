using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject GameOptions = GameObject.Find("Canvas/StartButton");
        Button btn = (Button)GameOptions.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void onClick()
    {
        Application.LoadLevel("CharacterCreate");
    }
}
