using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour {
    
    //点数类
    public int Health;  //健康
    public int Sanity;  //脑残

    public int Strength; //力量
    public int Agility;  //敏捷
    public int Eloquence; //口才
    public int Knowledge; //知识
    public int Charming; //魅力
    //特质类
    public bool Psychology = false;  //灵视
    public bool MachineMaintain = false; //机械修理
    public bool Freak= false; //怪人
    //骚话
    public Text TrashTalk;//骚话栏

    public int Sum;
	// Use this for initialization
	void Start () {
      
        Health = int.Parse(GameObject.Find("Canvas/Status/HealthText/HealthValue").GetComponent<Text>().text);
      //  Debug.Log(Health);
        Sanity = int.Parse(GameObject.Find("Canvas/Status/SanityText/SanityValue").GetComponent<Text>().text);
      //  Debug.Log(Sanity);
        Strength = int.Parse(GameObject.Find("Canvas/Status/StrengthText/StrengthValue").GetComponent<Text>().text);
      //  Debug.Log(Strength);
        Agility = int.Parse(GameObject.Find("Canvas/Status/AgilityText/AgilityValue").GetComponent<Text>().text);
      //  Debug.Log(Agility);
        Eloquence = int.Parse(GameObject.Find("Canvas/Status/EloquenceText/EloquenceValue").GetComponent<Text>().text);
      //  Debug.Log(Eloquence);
        Knowledge = int.Parse(GameObject.Find("Canvas/Status/KnowledgeText/KnowledgeValue").GetComponent<Text>().text);
        //  Debug.Log(Knowledge);
        Charming = int.Parse(GameObject.Find("Canvas/Status/CharmingText/CharmingValue").GetComponent<Text>().text);

        //数值设定按钮相关操作
         GameObject StrengthPlus = GameObject.Find("Canvas/Status/StrengthText/StrengthPlus");
         Button strplus = (Button)StrengthPlus.GetComponent<Button>();
         strplus.onClick.AddListener(strpl);
         GameObject StrengthMinus = GameObject.Find("Canvas/Status/StrengthText/StrengthMinus");
         Button strminus = (Button)StrengthMinus.GetComponent<Button>();
         strminus.onClick.AddListener(strmi);

         GameObject AgilityPlus = GameObject.Find("Canvas/Status/AgilityText/AgilityPlus");
         Button agiplus = (Button)AgilityPlus.GetComponent<Button>();
         agiplus.onClick.AddListener(agipl);
         GameObject AgilityMinus = GameObject.Find("Canvas/Status/AgilityText/AgilityMinus");
         Button agiminus= (Button)AgilityMinus.GetComponent<Button>();
         agiminus.onClick.AddListener(agimi);

         GameObject EloquencePlus = GameObject.Find("Canvas/Status/EloquenceText/EloquencePlus");
         Button eloplus = (Button)EloquencePlus.GetComponent<Button>();
         eloplus.onClick.AddListener(elopl);
         GameObject EloquenceMinus = GameObject.Find("Canvas/Status/EloquenceText/EloquenceMinus");
         Button elominus = (Button)EloquenceMinus.GetComponent<Button>();
         elominus.onClick.AddListener(elomi);

         GameObject KnowledgePlus = GameObject.Find("Canvas/Status/KnowledgeText/KnowledgePlus");
         Button knoplus = (Button)KnowledgePlus.GetComponent<Button>();
         knoplus.onClick.AddListener(knopl);
         GameObject KnowledgeMinus = GameObject.Find("Canvas/Status/KnowledgeText/KnowledgeMinus");
         Button knominus = (Button)KnowledgeMinus.GetComponent<Button>();
         knominus.onClick.AddListener(knomi);

         GameObject CharmingPlus = GameObject.Find("Canvas/Status/CharmingText/CharmingPlus");
         Button chaplus = (Button)CharmingPlus.GetComponent<Button>();
         chaplus.onClick.AddListener(chapl);
         GameObject CharmingMinus = GameObject.Find("Canvas/Status/CharmingText/CharmingMinus");
         Button chaminus = (Button)CharmingMinus.GetComponent<Button>();
         chaminus.onClick.AddListener(chami);



         GameObject Psychology = GameObject.Find("Canvas/Tags/Psychology");
         Button psychoset = (Button)Psychology.GetComponent<Button>();
         psychoset.onClick.AddListener(SetPsy);
         GameObject MachineMaintain = GameObject.Find("Canvas/Tags/MachineMaintain");
         Button machineset = (Button)MachineMaintain.GetComponent<Button>();
         machineset.onClick.AddListener(SetMac);
         GameObject Freak = GameObject.Find("Canvas/Tags/Freak");
         Button freakset = (Button)Freak.GetComponent<Button>();
         freakset.onClick.AddListener(SetFrc);
         
    }
    void strpl()
    {
        Strength++;
        //Debug.Log(Strength);
        if (Strength != 0)
        {
            GameObject.Find("Canvas/Status/StrengthText/StrengthMinus").GetComponent<Button>().enabled = true;
        }
    }
    void strmi()
    {
        Strength--;
        //Debug.Log(Strength);
        if (Strength == 0)
        {
            GameObject.Find("Canvas/Status/StrengthText/StrengthMinus").GetComponent<Button>().enabled = false;
        }
    }
    void agipl()
    {
        Agility++;
        //Debug.Log(Agility);
        if (Agility != 0)
        {
            GameObject.Find("Canvas/Status/AgilityText/AgilityMinus").GetComponent<Button>().enabled = true;
        }
    }
    void agimi()
    {
        Agility--;
        //Debug.Log(Agility);
        if (Agility == 0)
        {
            GameObject.Find("Canvas/Status/AgilityText/AgilityMinus").GetComponent<Button>().enabled = false;
        }
    }
    void elopl()
    {
        Eloquence++;
        //Debug.Log(Eloquence);
        if (Eloquence != 0)
        {
            GameObject.Find("Canvas/Status/EloquenceText/EloquenceMinus").GetComponent<Button>().enabled = true;
        }
    }
    void elomi()
    {
        Eloquence--;
        //Debug.Log(Eloquence);
        if (Eloquence == 0)
        {
            GameObject.Find("Canvas/Status/EloquenceText/EloquenceMinus").GetComponent<Button>().enabled = false;
        }
    }
    void knopl()
    {
        Knowledge++;
        //Debug.Log(Knowledge);
        if (Knowledge != 0)
        {
            GameObject.Find("Canvas/Status/KnowledgeText/KnowledgeMinus").GetComponent<Button>().enabled = true;
        }
    }
    void knomi()
    {
        Knowledge--;
        //Debug.Log(Knowledge);
        if (Knowledge == 0)
        {
            GameObject.Find("Canvas/Status/KnowledgeText/KnowledgeMinus").GetComponent<Button>().enabled = false;
        }
    }
    void chapl()
    {
        Charming++;
        //Debug.Log(Charming);
        if (Charming != 0)
        {
            GameObject.Find("Canvas/Status/CharmingText/CharmingMinus").GetComponent<Button>().enabled = true;
        }
    }
    void chami()
    {
        Charming--;
        //Debug.Log(Charming);
        if (Charming == 0)
        {
            GameObject.Find("Canvas/Status/CharmingText/CharmingMinus").GetComponent<Button>().enabled = false;
        }
    }

    void SetPsy()
    {
        Psychology = true;
        MachineMaintain = false;
        Freak = false;
    }

    void SetMac()
    {
        MachineMaintain = true;
        Psychology = false;
        Freak = false;
    }

    void SetFrc()
    {
        Freak = true;
        Psychology = false;
        MachineMaintain = false;
    }

	// Update is called once per frame
	void Update () {
        GameObject.Find("Canvas/Status/HealthText/HealthValue").GetComponent<Text>().text = Health.ToString();
        //  Debug.Log(Health);
        GameObject.Find("Canvas/Status/SanityText/SanityValue").GetComponent<Text>().text = Sanity.ToString();
        //  Debug.Log(Sanity);
        GameObject.Find("Canvas/Status/StrengthText/StrengthValue").GetComponent<Text>().text = Strength.ToString();
        //  Debug.Log(Strength);
        GameObject.Find("Canvas/Status/AgilityText/AgilityValue").GetComponent<Text>().text = Agility.ToString();
        //  Debug.Log(Agility);
        GameObject.Find("Canvas/Status/EloquenceText/EloquenceValue").GetComponent<Text>().text = Eloquence.ToString();
        //  Debug.Log(Eloquence);
        GameObject.Find("Canvas/Status/KnowledgeText/KnowledgeValue").GetComponent<Text>().text = Knowledge.ToString();
        //  Debug.Log(Knowledge);
        GameObject.Find("Canvas/Status/CharmingText/CharmingValue").GetComponent<Text>().text = Charming.ToString();
        //  Debug.Log(Charming);
        Sum = Strength + Agility + Eloquence + Knowledge + Charming;
        if (Sum > 24)
        {
            GameObject.Find("Canvas/StartButton").GetComponent<Button>().enabled = false;
            GameObject.Find("Canvas/TrashTalk").GetComponent<Text>().text = "你不会那么强的。";
        }
        else
        {
            GameObject.Find("Canvas/StartButton").GetComponent<Button>().enabled = true;
            GameObject.Find("Canvas/TrashTalk").GetComponent<Text>().text = "你还可以继续分配点数，惊不惊喜";
        }

    }


}
