using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetYJSP : MonoBehaviour {

    GameObject Button;
    GameObject Panel;
    GameObject YJPanel;
    Text Dialog;
    Text YJDialog;

    bool drunk = false;
    // bool IsGamePaused = true;
    int process2 = 0;
    void Start()
    {
        GameObject Button = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2");
        Button Proceed = (Button)Button.GetComponent<Button>();
        Proceed.onClick.AddListener(DialogueProcess);

        if (JourneyStatus.MeetYJSP == false)
        {
            Button.SetActive(true);
        }
        else if (JourneyStatus.MeetYJSP == true)
        {
            Button.SetActive(false);
        }

        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        YJPanel = GameObject.Find("Main Camera/PlayerCanvas/DialogYJ");

        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
        YJDialog = GameObject.Find("Main Camera/PlayerCanvas/DialogYJ/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.MeetYJSP == false)
        {
            Panel.SetActive(true);
            //Button.SetActive(true);
            Time.timeScale = 0;
            Dialog.text = "你跟不知道名字的男人四目相交。\n";
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
            YJPanel.SetActive(false);
            
        }
    }

    // Update is called once per frame

    void DialogueProcess()
    {
        process2++;
    }
    void Update()
    {
        if (JourneyStatus.MeetYJSP == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2").SetActive(false);
        }

        if (process2 == 1)
        {
            Dialog.text = "“那么首先能告诉我你的年龄吗。”\n（嗯？我为什么要说这句话？）\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 2)
        {
            YJPanel.SetActive(true);
            YJDialog.text = "是24岁。\n";
            YJDialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 3)
        {
            Dialog.text = "“已经工作了吧？”\n（谁问你这个了？？）\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 4)
        {
            YJDialog.text = "是学生。\n";
            YJDialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 5)
        {
            Dialog.text = "“那么身高和体重是多少呢？”\n(你的嘴巴不受控制，\n依旧问着毫不相关的问题）\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 6)
        {
            YJDialog.text = "身高是170公分,\n体重是74公斤\n";
            YJDialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 7)
        {
            Dialog.text = "“停！你到底想干什么？”\n你试图摆脱这个窘境\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 8)
        {
            YJDialog.text = "别激动，来杯红茶吗？\n";
            YJDialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 9)
        {
            Dialog.text = "男人递给你一杯红茶。\n";
            if (PlayerStatus.Agility >= 5)
            {
                Dialog.text += "（敏捷）你注意到红茶是冷的\n杯底还有些许沉淀\n";
            }
            Dialog.text += " 喝[R]    不喝[继续]\n";
            Dialog.text.Replace("\\n", "\n");
            if (Input.GetKeyDown(KeyCode.R))
            {
                drunk = true;
            }
        }
        else if (process2 == 10)
        {
            if (drunk == true)
            {
                Dialog.text = "你接过红茶，一饮而尽。\n就是头有点晕。\n(灵视)你似乎可以看到以前看不到的东西了。\n";
                Dialog.text.Replace("\\n", "\n");
                PlayerStatus.Health--;
                PlayerStatus.Psychology = true;
            }
            else
            {
                Dialog.text = "你拒绝了男人\n";
                Dialog.text.Replace("\\n", "\n");
                YJDialog.text = "诶呀，真可惜。";
                YJDialog.text.Replace("\\n", "\n");
            }
        }
        else if (process2 == 11)
        {
            YJDialog.text = "我需要你帮我个忙。\n去拿燃料，我才能给你杯热的红茶。\n";
            YJDialog.text.Replace("\\n", "\n");
        }
        else if (process2 == 12)
        {
            Dialog.text = "虽然将信将疑，\n但你还是答应了男人。";
            Dialog.text.Replace("\\n", "\n");
            Time.timeScale = 1;
            JourneyStatus.MeetYJSP = true;
        }

    }
}
