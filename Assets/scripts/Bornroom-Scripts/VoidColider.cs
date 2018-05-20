using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoidColider : MonoBehaviour
{
    public GameObject HintShow;
    GameObject Panel;
    Text Dialog;
    bool Vision = false;
    // Use this for initialization
    void Start()
    {
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
        if (JourneyStatus.TolietExist == false)
        {
            this.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.TolietExist == false &&Vision ==true)
        {
            HintShow.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.TolietExist == false)
        {
            if (Input.GetKeyDown(KeyCode.E)&&Vision == true)
            {
                HintShow.SetActive(false);
                Panel.SetActive(true);
                Dialog.text = "你开始怀念有马桶的生活了。\n";
                Dialog.text.Replace("\\n","\n");
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player")
        {
            Panel.SetActive(false);
            Vision = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (JourneyStatus.TolietExist == false)
        {
            this.gameObject.SetActive(true);
        }
    }
}
