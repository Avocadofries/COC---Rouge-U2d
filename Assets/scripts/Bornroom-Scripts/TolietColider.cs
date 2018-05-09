using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TolietColider : MonoBehaviour
{
    public GameObject HintShow;
    public GameObject Panel;
    Text Dialog;
    bool tolietexist = true;
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
            if (Input.GetKeyDown(KeyCode.E)&& tolietexist==true)
            {
                HintShow.SetActive(false);
                Panel.SetActive(true);
                if (tolietexist == true)
                {
                    Dialog.text = "这时的你尚且没有这个需求。\n";
                }
                else
                {
                    Dialog.text = "不仅没地方拉屎还受到了精神创伤\n";
                }
               
                if (PlayerStatus.MachineMaintain == true)
                {
                    Dialog.text += "(机械修理)(力量6)虽然潜意识在抗拒\n但是绿翔学院高材生的身份让你有一种拆掉它的欲望[F]\n";
                }
            }
            if (Input.GetKeyDown(KeyCode.F) && tolietexist == true&&PlayerStatus.Strength>=6)
            {
                PlayerStatus.Sanity--;
                Dialog.text = "从下水道中窥见了不可名状之物\n理智受到打击\n";
                this.gameObject.SetActive(false);
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

    }
}