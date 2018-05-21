using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class event_02 : MonoBehaviour
{
    GameObject Panel02;
    Text Dialog02;
    
    GameObject Button02;
    GameObject Button1;
    GameObject Button2;
    GameObject Button3;
    GameObject Button4;

    GameObject cup1;
    GameObject cup2;

    int process2 = 0;
    // Use this for initialization
    void Start()
    {
        Panel02 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02");
        Dialog02 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Text").GetComponent<Text>();

        GameObject cup1 = GameObject.Find("Canvas_301/blood");
        GameObject cup2 = GameObject.Find("Canvas_301/blood (1)");

        GameObject Button02 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button");
        GameObject Button1 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (1)");
        GameObject Button2 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (2)");
        GameObject Button3 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (3)");
        GameObject Button4 = GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (4)");
        Button Proceed = (Button)Button02.GetComponent<Button>();
        Proceed.onClick.AddListener(DialogueProcess);

        Button Proceed1 = (Button)Button1.GetComponent<Button>();
        Proceed1.onClick.AddListener(DialogueProcess1);
        Button Proceed2 = (Button)Button2.GetComponent<Button>();
        Proceed2.onClick.AddListener(DialogueProcess);
        Button Proceed3 = (Button)Button3.GetComponent<Button>();
        Proceed3.onClick.AddListener(DialogueProcess1);
        Button Proceed4 = (Button)Button4.GetComponent<Button>();
        Proceed4.onClick.AddListener(DialogueProcess1);

        if (JourneyStatus.observed == false)
        {
            Panel02.SetActive(false);
        }
        else if (JourneyStatus.observed == true)
        {
            Panel02.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.observed == true)
        {
            Panel02.SetActive(true);
            //Button.SetActive(true);
            Time.timeScale = 0;
            Dialog02.text = "“看够了吗？”\n";
            Dialog02.text.Replace("\\n", "\n");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
            Panel02.SetActive(false);
        }
    }
    void DialogueProcess()
    {
        process2++;
    }
    void DialogueProcess1()
    {
        process2 += 10;
        GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button").SetActive(true);
        GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (1)").SetActive(false);
        GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (2)").SetActive(false);
        GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (3)").SetActive(false);
        GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (4)").SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(JourneyStatus.Dia02 == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button").SetActive(false);
            process2 = 32;
        }
        GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button").SetActive(true);
            if (process2 == 1)
            {
                Panel02.SetActive(true);
                Dialog02.text = "面前的少女扣上了帽子。\n突然，她探身过来嗅了嗅你。\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 2)
            {
                Dialog02.text = "“这样啊……\n那么从现在起你就是我的Darling了！”\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 3)
            {
                Dialog02.text = "少女笑着。\n“我可以告诉Darling一个情报哦。”\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 4)
            {
                Dialog02.text = "“只要凑齐四把钥匙，就能离开这里。”\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 5)
            {
                Dialog02.text = "“我这里就有一把哦。想要吗，\nDarling？”\n少女脸上的戏谑更深了。\n她猛地探头过来。\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 6)
            {
                Dialog02.text = "“就是这个表情！你可真是有趣。”\n她缩回脑袋大笑着拍手。\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 7)
            {
                Dialog02.text = "“那么，这里的房间号是多少呢，Darling？\n         3-1                    002\n\n         301                    3_1”\n";
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button").SetActive(false);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (1)").SetActive(true);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (2)").SetActive(true);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (3)").SetActive(true);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (4)").SetActive(true);
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 8)
            {
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button").SetActive(true);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (1)").SetActive(false);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (2)").SetActive(false);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (3)").SetActive(false);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (4)").SetActive(false);
                Dialog02.text = "“哈哈哈哈哈！不愧是我的Darling！”\n少女发出一阵狂笑，扔出一把钥匙。\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 9)
            {
                Dialog02.text = "“002，是我的名字哦，Darling。”\n002满意地看着你。\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 10)
            {
                Dialog02.text = "“既然你通过了考验，那么我要再告诉Darling一条信息。”\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 11)
            {
                Dialog02.text = "“对面那个男人说的话，你最好照做。”\n002皱起眉头，眼神中有一丝厌恶。\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 12)
            {
                process2 = 32;
            }
            else if (process2 == 17)
            {
            Dialog02.text = "“这样可不行哦……连这种问题都回答错了的话。”\n少女皱起眉头，眼里透着失望。\n";
            Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 18)
            {
                Dialog02.text = "“既然这样的话，就得请Darling接受惩罚了。”\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 19)
            {
            Dialog02.text = "“这两杯酒里，有一杯藏着钥匙。\n而不小心选错的话，会死哦。”\n少女又露出了开始时的戏谑表情。\n";
            Dialog02.text.Replace("\\n", "\n");
            GameObject.Find("Canvas_301/blood").SetActive(true);
            GameObject.Find("Canvas_301/blood (1)").SetActive(true);
        }
            else if (process2 == 20)
            {
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button").SetActive(false);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (3)").SetActive(true);
                GameObject.Find("Main Camera/PlayerCanvas/Dialog_02/Button (4)").SetActive(true);
                Dialog02.text = "“要喝哪一杯呢，Darling？”\n\n\n\n         左边那杯           右边那杯\n";
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 30)
            {
                Dialog02.text = "黏稠的液体涌入你的口腔。口感实在太过恶心，理智受到打击。\n吞咽的瞬间，感到口中似乎有什么异物。\n";
                PlayerStatus.Sanity--;
                Dialog02.text.Replace("\\n", "\n");
            }
            else if (process2 == 31)
        {
            Dialog02.text = "“算你走运呢，Darling。”\n少女盯着你。你吐出口中的异物，发现是一把恶魔角形状的钥匙。\n";
            Dialog02.text.Replace("\\n", "\n");
            GameObject.Find("Canvas_301/blood").SetActive(false);
            GameObject.Find("Canvas_301/blood (1)").SetActive(false);
            }
            else if (process2 == 32)
            {
                Dialog02.text = "“那么，该上路了，Darling。”\n少女戏谑地笑着向你道别。\n";
                Dialog02.text.Replace("\\n", "\n");
                Time.timeScale = 1;
                JourneyStatus.Dia02 = true;
        }
        }
    }