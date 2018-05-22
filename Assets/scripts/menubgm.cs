using UnityEngine;
using System.Collections;
public class menubgm : MonoBehaviour
{
    public AudioSource ac;
    public static AudioSource clone;

    void Start()
    {
        clone = ac;
        DontDestroyOnLoad(clone);
    }
}