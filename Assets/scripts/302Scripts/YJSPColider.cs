using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YJSPColider : MonoBehaviour {

    public GameObject HintShow;
    GameObject Panel;
    GameObject YJPanel;
    Text Dialog;
    Text YJDialog;

    // Use this for initialization
    void Start()
    {
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        YJPanel = GameObject.Find("Main Camera/PlayerCanvas/DialogYJ");

        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
        YJDialog = GameObject.Find("Main Camera/PlayerCanvas/DialogYJ/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player"&& JourneyStatus.MeetYJSP == true)
        {
            HintShow.SetActive(true);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.MeetYJSP == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HintShow.SetActive(false);
                YJPanel.SetActive(true);
                YJDialog.text = "去找燃料吧，我有你需要的东西。\n";
                YJDialog.text.Replace("\\n", "\n");
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
            HintShow.SetActive(false);
            YJPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
