using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TolietColider : MonoBehaviour
{
    public GameObject HintShow;
    GameObject Panel;
    public GameObject VoidGate;
    Text Dialog;
    bool havetried = false;
    //bool tolietexist = true;
    // Use this for initialization
    void Start()
    {
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
       
        if (JourneyStatus.TolietExist == false)
        {
            this.gameObject.transform.localPosition = new Vector2((float)-50.00, (float)0.00);
            //VoidGate.SetActive(true);
        }
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
            if (Input.GetKeyDown(KeyCode.E)&& JourneyStatus.TolietExist==true)
            {
                HintShow.SetActive(false);
                Panel.SetActive(true);
                if (JourneyStatus.TolietExist == true)
                {
                    Dialog.text = "一个马桶,\n这时的你尚且没有这个需求。\n";
                }
              
               
                if (PlayerStatus.MachineMaintain == true)
                {
                    Dialog.text += "(机械修理)\n绿翔学院高材生的身份让你有一种\n拆掉它的欲望\n按[R]拆马桶\n";
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && JourneyStatus.TolietExist == true && PlayerStatus.Strength>=6)
            {
                PlayerStatus.Sanity--;
                Dialog.text = "从下水道中窥见了不可名状之物\n理智受到打击\n";
                JourneyStatus.TolietExist = false;
                VoidGate.SetActive(true);
               // this.gameObject.SetActive(false);
               this.gameObject.transform.localPosition = new Vector2((float)-50.00, (float)0.00);


            }
            Dialog.text.Replace("\\n", "\n");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.TolietExist == true)
        {
            HintShow.SetActive(false);
            Panel.SetActive(false);
        }
        else
        {
            HintShow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}