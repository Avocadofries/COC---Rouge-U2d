using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainmenuButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject BackMenu = GameObject.Find("Canvas/MenuButton");
        Button btn = (Button)BackMenu.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void onClick()
    {
        Application.LoadLevel("menu");
    }
}