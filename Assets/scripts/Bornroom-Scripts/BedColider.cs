using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedColider : MonoBehaviour
{
    public GameObject HintShow;
    GameObject Panel;
    Text Dialog;
    //bool vision = false;
    // Use this for initialization
    void Start()
    {
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
            HintShow.SetActive(true);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HintShow.SetActive(false);
                Panel.SetActive(true);
                if (JourneyStatus.BedlegExist == true)
                {
                    Dialog.text = "现在不是休息的时候。\n";
                }
                if (JourneyStatus.BedlegExist == false)
                {
                    Dialog.text = "少了一条腿的床就更没有\n让人休息的欲望了。\n";
                }

                if (PlayerStatus.MachineMaintain == true && JourneyStatus.BedlegExist ==true && JourneyStatus.TryToDealBed == false)
                {
                    Dialog.text += "(机械修理)\n有一条床腿似乎不那么稳定...\n按[R]拆掉床腿\n";
                }
                Dialog.text.Replace("\\n", "\n");
            }

            if (Input.GetKeyDown(KeyCode.R) && JourneyStatus.BedlegExist == true && PlayerStatus.MachineMaintain == true)
            {
                if (PlayerStatus.Strength >= 6)
                {
                    Dialog.text = "随着一声脆响\n你的手中多了一根大铁棒子\n(力量增加)\n";
                    JourneyStatus.BedlegExist = false;
                    PlayerStatus.Strength++;
                    JourneyStatus.TryToDealBed = true;
                }
                else
                {
                    Dialog.text = "你尽力了\n床腿纹丝不动。\n";
                    JourneyStatus.TryToDealBed = true;
                }
                Dialog.text.Replace("\\n","\n");

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

    // Update is called once per frame
    void Update()
    {

    }
}