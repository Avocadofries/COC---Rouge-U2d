using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate_Finalroom : MonoBehaviour {

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
                Dialog.text = "这扇门没有门牌号...\n但是上面有四个钥匙孔。\n";
                Dialog.text += "\n钥匙0/4\n";
                Dialog.text.Replace("\\n", "\n");
            }

          /*  if (Input.GetKeyDown(KeyCode.R))
            {
                JourneyStatus.istransformed_hall_302 = 12;
                //Player.transform.localPosition = new Vector2((float)5.95, (float)-2.3);
                Application.LoadLevel("");

            }*/
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
