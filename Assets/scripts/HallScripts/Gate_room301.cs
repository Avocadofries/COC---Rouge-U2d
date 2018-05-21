using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate_room301 : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时我也不知道会什么样
    {
        if (collision.gameObject.tag == "Player")
        {
            HintShow.SetActive(true);
            // Application.LoadLevel("Scene-hallway1");
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
                Dialog.text = "门牌上模糊地写着:3 - 1\n\n按下[R]键进入";
                Dialog.text.Replace("\\n", "\n");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if(JourneyStatus.Dia02 == false)
                {
                    JourneyStatus.istransformed_hall_301 = 12;
                    //Player.transform.localPosition = new Vector2((float)5.95, (float)-2.3);
                    Application.LoadLevel("Scene-301");
                }
                else
                {
                    Dialog.text = "门推不开了。";
                    Dialog.text.Replace("\\n", "\n");
                }
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