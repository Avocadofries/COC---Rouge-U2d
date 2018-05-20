using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterludeColider_302 : MonoBehaviour
{

    GameObject Button;
    GameObject Panel;
    Text Dialog;
    // bool IsGamePaused = true;
    int process1 = 0;
    void Start()
    {
        GameObject Button = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button");
        Button Proceed = (Button)Button.GetComponent<Button>();
        Proceed.onClick.AddListener(DialogueProcess);

        if (JourneyStatus.Interlude302 == true)
        {
            Button.SetActive(false);
        }
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.Interlude302 == false)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
            Dialog.text = "一间闷热的屋子。\n你开始出汗。\n";
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
            //JourneyStatus.Interlude302 = true;

        }
    }

    // Update is called once per frame

    void DialogueProcess()
    {
        process1++;
    }
    void Update()
    {
        if (JourneyStatus.Interlude302 == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button").SetActive(false);
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2").SetActive(true);
        }

        if (process1 == 1)
        {
            Dialog.text = "屋子北侧排列着三个火炉。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process1 == 2)
        {
            Dialog.text = "屋子的正中间是一张桌子。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process1 == 3)
        {
            Dialog.text = "桌子上摆着几个茶杯。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process1 == 4)
        {
            Dialog.text = "桌子后面站着一位皮肤黝黑的男子。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process1 == 5)
        {
            Dialog.text = "男子的目光如同野兽一般。\n似乎有一种摄人心魄的魔力。\n";
            if (PlayerStatus.Charming >= 3)
            {
                Dialog.text += "你的理智受到了冲击。\n";
                PlayerStatus.Sanity--;
            }
            else if (PlayerStatus.Charming < 3)
            {
                Dialog.text += "（魅力）男人的视线只在你身上停留了一小会。\n也对，你都丑成个妈了。\n";
            }
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process1 == 6)
        {
            Time.timeScale = 1;
            JourneyStatus.Interlude302 = true;
        }
    }
}