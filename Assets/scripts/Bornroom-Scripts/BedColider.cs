using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedColider : MonoBehaviour
{
    public GameObject HintShow;
    public GameObject Panel;
    Text Dialog;
    // Use this for initialization
    bool legexist = true;
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
                if (legexist == true)
                {
                    Dialog.text = "现在不是休息的时候。\n";
                }
                else
                {
                    Dialog.text = "三只脚的床就更没有让人睡觉的欲望了。\n";
                }
                if (PlayerStatus.MachineMaintain == true)
                {
                    Dialog.text += "(机械维修)似乎可以把床腿拔下来当棍子...\n[F]\n";
                }

            }

            if (Input.GetKeyDown(KeyCode.F) && legexist == true)
            {
                PlayerStatus.Strength++;
                legexist = false;
                Dialog.text = "三只脚的床就更没有让人睡觉的欲望了。\n";
            }

            Dialog.text.Replace("\\n", "\n");

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
        if (legexist == false)
        {
            PlayerStatus.Strength++;
            Dialog.text = "三条腿的床就更没有让人睡觉的欲望了。";
        }

    }
}