using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateColider : MonoBehaviour
{
    public GameObject HintShow;
    public GameObject Panel;
    //public GameObject Player;
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
                Dialog.text = "一扇铁门，没有上锁，从栅栏孔里可以看到外面昏暗的走廊。\n\n按下[R]键走出铁门";
                Dialog.text.Replace("\\n", "\n");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                //Player.transform.localPosition = new Vector2((float)-2.44,(float) -4.23);
                flag.is_transformed = 12;
                Application.LoadLevel("Scene-hallway1");

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