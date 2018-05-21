using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meet_02 : MonoBehaviour
{
    public GameObject HintShow;
    GameObject Panel;
    Text Dialog;

    GameObject Button;

    bool impact = false;
    int process2 = 0;
    // Use this for initialization
    void Start()
    {
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();

        GameObject Button = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2");
        GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2").SetActive(false);
        Button Proceed01 = (Button)Button.GetComponent<Button>();
        Proceed01.onClick.AddListener(observe);
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
            HintShow.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2").SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                HintShow.SetActive(false);
                Panel.SetActive(true);
                Dialog.text = "桌后坐着一位少女，昏暗的环境也没能掩盖她的戏谑眼神。\n少女头上戴着鲜红色的恶魔角发饰。\n";
                if (PlayerStatus.Agility >= 5)
                {
                    Dialog.text += "按[R]仔细观察";
                }
                else
                {
                }
                Dialog.text.Replace("\\n", "\n");
            }

            if (PlayerStatus.Agility >= 5 && Input.GetKeyDown(KeyCode.R))
            {
                Dialog.text = "（敏捷）那恶魔的角……似乎不是装饰\n而是真正从颅骨中生长而出的！\n理解到这奇异的情况，理智受到打击\n";
                if (impact == false)
                {
                    PlayerStatus.Sanity--;
                    impact = true;
                }
                
                //GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button").SetActive(true);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
            HintShow.SetActive(false);
            Panel.SetActive(false);
        }
    }
    void observe()
    {
        JourneyStatus.observed = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (JourneyStatus.observed == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button2").SetActive(false);
        }
    }
}