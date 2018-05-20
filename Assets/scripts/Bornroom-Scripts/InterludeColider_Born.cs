using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InterludeColider_Born : MonoBehaviour {
    //JourneyStatus.BornInterlude
    GameObject Button;
    GameObject Panel;
    Text Dialog;
   // bool IsGamePaused = true;
    int process = 0;
    void Start()
    {
        GameObject Button = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button");
        Button Proceed = (Button)Button.GetComponent<Button>();
        Proceed.onClick.AddListener(DialogueProcess);

        if (JourneyStatus.BornInterlude == true)
        {
            Button.SetActive(false);
        }
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.BornInterlude ==false)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
            Dialog.text = "“我在哪？？”\n";
            Dialog.text.Replace("\\n","\n");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
           
            Panel.SetActive(false);
            //JourneyStatus.BornInterlude = true;
            
        }
    }

    // Update is called once per frame

    void DialogueProcess()
    {
        process++;
    }
    void Update()
    {
        if (JourneyStatus.BornInterlude == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button").SetActive(false);
        }

        if (process == 1)
        {
            Dialog.text = "你发现你身处一间脏兮兮的牢房中。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 2)
        {
            Dialog.text = "空气中散发着霉味...\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 3)
        {
            Dialog.text = "气温姑且不让人不适...\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 4)
        {
            Dialog.text = "房间内没有可见的光源,\n却依旧明亮\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 5)
        {
            Dialog.text = "你决定四处看看。\n上下左右键控制行走方向\n[E]键进行交互";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 6)
        {
            Time.timeScale = 1;
            JourneyStatus.BornInterlude = true;
        }
    }
}