using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerDataPanel : MonoBehaviour {
    GameObject StatusPanel,TagPanel;
    bool StatuspanelShow = false;
    int StrengthAfter = 0, AgilityAfter = 0, EloquenceAfter = 0, KnowledgeAfter = 0, CharmingAfter = 0;
    int TagBuff = 0;
	// Use this for initialization
	void Start () {
        StatusPanel = GameObject.Find("Main Camera/PlayerCanvas/StatusPanel");
        TagPanel = GameObject.Find("Main Camera/PlayerCanvas/StatusPanel/TagPanel");

        GameObject Status = GameObject.Find("Main Camera/PlayerCanvas/Status");
        Button StatusButton = (Button)Status.GetComponent<Button>();
        StatusButton.onClick.AddListener(ShowStatus);

        if (PlayerStatus.Freak == true)
        {
            TagPanel.GetComponent<Text>().text = "怪人";
        }
        else if (PlayerStatus.MachineMaintain == true)
        {
            TagPanel.GetComponent<Text>().text = "机械修理";
        }
        else if (PlayerStatus.Psychology == true)
        {
            TagPanel.GetComponent<Text>().text = "灵视";
        }
        else
        {
            TagPanel.GetComponent<Text>().text = "真猛男不需要特质";
        }
    }
	
	// Update is called once per frame
	void Update () {
        StrengthAfter = PlayerStatus.Strength;
        AgilityAfter = PlayerStatus.Agility;
        EloquenceAfter = PlayerStatus.Eloquence;
        KnowledgeAfter = PlayerStatus.Knowledge;
        CharmingAfter = PlayerStatus.Charming;

        GameObject.Find("Main Camera/PlayerCanvas/StatusPanel/Strength").GetComponent<Text>().text = StrengthAfter.ToString();
        GameObject.Find("Main Camera/PlayerCanvas/StatusPanel/Agility").GetComponent<Text>().text = AgilityAfter.ToString();
        GameObject.Find("Main Camera/PlayerCanvas/StatusPanel/Eloquence").GetComponent<Text>().text = EloquenceAfter.ToString();
        GameObject.Find("Main Camera/PlayerCanvas/StatusPanel/Knowledge").GetComponent<Text>().text = KnowledgeAfter.ToString();
        GameObject.Find("Main Camera/PlayerCanvas/StatusPanel/Charming").GetComponent<Text>().text = CharmingAfter.ToString();

    }

    void ShowStatus()
    {
        if (StatuspanelShow == false)
        {
            StatusPanel.SetActive(true);
            StatuspanelShow = true;
        }
        else
        {
            StatusPanel.SetActive(false);
            StatuspanelShow = false;
        }
        
    }
}
