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
                if (JourneyStatus.TolietExist == true && JourneyStatus.TryToDealToliet == false)
                {
                    Dialog.text = "一个马桶,\n这时的你尚且没有这个需求。\n";
                }
                else if (JourneyStatus.TryToDealToliet == true)
                {
                    Dialog.text = "你决定老老实实地拥抱生命的大和谐,\n而不是像个白痴一样撅着屁股撬马桶。\n";
                }
              
               
                if (PlayerStatus.MachineMaintain == true && JourneyStatus.TryToDealToliet == false)
                {
                    Dialog.text += "(机械修理)\n绿翔学院高材生的身份让你有一种\n拆掉它的欲望\n按[R]拆马桶\n";
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && JourneyStatus.TolietExist == true)
            {
                if (PlayerStatus.Strength >= 6)
                {
                    PlayerStatus.Sanity--;
                    Dialog.text = "从下水道中窥见了不可名状之物\n理智受到打击\n";
                    JourneyStatus.TolietExist = false;
                    JourneyStatus.TryToDealToliet = true;
                    VoidGate.SetActive(true);
                    this.gameObject.transform.localPosition = new Vector2((float)-50.00, (float)0.00);
                }
                else
                {
                    Dialog.text = "你撅着屁股跟马桶较劲,\n而马桶纹丝不动。\n你感觉很没面子。\n";
                    JourneyStatus.TryToDealToliet = true;
                }
               
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