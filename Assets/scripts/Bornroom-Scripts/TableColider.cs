using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableColider : MonoBehaviour
{
    public GameObject HintShow;
    GameObject Panel;
    Text Dialog;
    
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
                Dialog.text = "陈旧的木头桌子。\n似乎碰一下就会散架...\n";
                if (JourneyStatus.TryToDealPapaer == false)
                {
                    Dialog.text += "桌子上的字条似乎有什么含义...\n按[R]调查";
                }
                else if (JourneyStatus.TryToDealPapaer == true && JourneyStatus.PaperTranslated == false)
                {
                    Dialog.text = "你已经不想和那张破纸扯上什么关系了。";
                }
                else if (JourneyStatus.TryToDealPapaer == true && JourneyStatus.PaperTranslated == true)
                {
                    Dialog.text = "桌子上的纸条上歪歪扭扭地写着\n代表“眼睛”的楔形文字。\n";
                }

                Dialog.text.Replace("\\n", "\n");
            }

        }
        if (Input.GetKeyDown(KeyCode.R) && JourneyStatus.PaperTranslated ==false && JourneyStatus.TryToDealPapaer ==false)
        {
            if (PlayerStatus.Knowledge>=5)
            {
                Dialog.text = "（知识5）从一滩鬼画符之中\n你勉强辨识出了代表“眼睛”的字符\n";
                JourneyStatus.PaperTranslated = true;
                JourneyStatus.TryToDealPapaer = true;
            }
            else
            {
                Dialog.text = "你瞪大了你的死鱼眼也没发现什么秘密\n这时你眼前一黑,感到一阵恶寒\n理智受到打击\n";
                PlayerStatus.Sanity--;
                JourneyStatus.PaperTranslated = false;
                JourneyStatus.TryToDealPapaer = true;
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