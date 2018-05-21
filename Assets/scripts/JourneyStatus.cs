using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourneyStatus : MonoBehaviour {
    //用以标识各场景各组件状态，只在出生点引用一次
    //Beginning
    public static int istransformed_born_hall = 0;
    public static int istransformed_hall_301 = 0;
    public static int istransformed_hall_302 = 0;

    public static int MaxHealth = PlayerStatus.Health;
    public static int MaxSanity = PlayerStatus.Sanity;
    //bornroom
    public static bool BornInterlude = false;
    
    public static bool BedlegExist = true;
    public static bool TryToDealBed = false;

    public static bool TolietExist = true;
    public static bool TryToDealToliet = false;

    public static bool PaperTranslated = false;
    public static bool TryToDealPapaer = false;

    //hallway
    public static bool HallInterlude = false;

    //301
    public static bool Interlude301 = false;
    public static bool observed = false;
    public static bool Dia02 = false;
    //302
    public static bool Interlude302 = false;
    public static bool MeetYJSP = false;

    // Use this for initialization
	void Start () {
        MaxHealth = PlayerStatus.Health;
        MaxSanity = PlayerStatus.Sanity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
