using UnityEngine;
using System.Collections;
public class bgm_control : MonoBehaviour
{
    public GameObject MusicBk;
    private GameObject clone;

    void Start()
    {
        if (!JourneyStatus.IsHaveMusicBk)
        {
           clone = Instantiate(MusicBk, transform.position, transform.rotation) as GameObject;
            JourneyStatus.IsHaveMusicBk = true;  
        }

     DontDestroyOnLoad(clone);  
    }  
}  