using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterludeColider_hall : MonoBehaviour {

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

        if (JourneyStatus.HallInterlude == true)
        {
            Button.SetActive(false);
        }
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.HallInterlude == false)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
            Dialog.text = "当你打开铁门，\n从你所在的牢房中倾泻而出的光线照亮了地面\n";
            Dialog.text.Replace("\\n", "\n");
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
            //JourneyStatus.HallInterlude = true;

        }
    }

    // Update is called once per frame

    void DialogueProcess()
    {
        process++;
    }
    void Update()
    {
        if (JourneyStatus.HallInterlude == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button").SetActive(false);
        }

        if (process == 1)
        {
            Dialog.text = "你的影子拉成长长的一条线。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 2)
        {
            Dialog.text = "空气中依旧充斥着挥之不去的霉味。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 3)
        {
            Dialog.text = "墙壁和地板都是毫无特点的灰色。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 4)
        {
            Dialog.text = "环境亮度急剧下降。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 5)
        {
            Dialog.text = "你需要想个法子离开这里。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 6)
        {
            Time.timeScale = 1;
            JourneyStatus.HallInterlude = true;
        }
    }
}
