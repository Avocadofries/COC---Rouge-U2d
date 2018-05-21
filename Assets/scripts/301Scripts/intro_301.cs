using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class intro_301 : MonoBehaviour
{
    //JourneyStatus.BornInterlude
    GameObject Button;
    GameObject Panel;
    Text Dialog;
    // bool IsGamePaused = true;
    int process = 0;
    void Start()
    {
        GameObject Button = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button");
        Button Proceed = (Button)Button.GetComponent<Button>();
        Proceed.onClick.AddListener(DialogueProcess);
        
        Panel = GameObject.Find("Main Camera/PlayerCanvas/Dialog");
        Dialog = GameObject.Find("Main Camera/PlayerCanvas/Dialog/Text").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞时显示提示信息
    {
        if (collision.gameObject.tag == "Player" && JourneyStatus.Interlude301 == false)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
            Dialog.text = "好冷。\n";
            Dialog.text.Replace("\\n", "\n");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)//离开时关闭提示信息
    {
        if (collision.gameObject.tag == "Player")
        {

            Panel.SetActive(false);

        }
    }

    // Update is called once per frame

    void DialogueProcess()
    {
        process++;
    }
    void Update()
    {
        if (JourneyStatus.Interlude301 == true)
        {
            GameObject.Find("Main Camera/PlayerCanvas/Dialog/Button").SetActive(false);
        }

        if (process == 1)
        {
            Dialog.text = "好暗。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 2)
        {
            Dialog.text = "屋子暗得出奇。你打着哆嗦摸索着迈进房间。\n";
            Dialog.text.Replace("\\n", "\n");
        }
        else if (process == 3)
        {
            Time.timeScale = 1;
            JourneyStatus.Interlude301 = true;
        }
    }
}