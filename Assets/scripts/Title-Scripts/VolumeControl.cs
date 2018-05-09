using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class VolumeControl : MonoBehaviour
{
    public AudioClip backgroundMusic;//将准备好的MP3格式的背景声音文件拖入此处  

    public AudioClip palyOnceSound;//将准备好的MP3格式的音效文件拖入此处

    public AudioClip buttonSound;//按钮音效  

    private AudioSource _audioSource;//用于控制声音的AudioSource组件  

    private bool isPlayMusic;//是否播放游戏背景音乐 

    private bool isPlayButtonSound; //是否播放按键音效  


    void Awake()
    { 
        _audioSource = this.gameObject.AddComponent<AudioSource>();//在添加此脚本的对象中添加AudioSource组件，此处为摄像机
        _audioSource.loop = true;//设置循环播放
        _audioSource.volume = 1.0f;//设置音量为最大，区间在0-1之间  
        _audioSource.clip = backgroundMusic;//设置audioClip 

    }

    void Update()
    {
        if (isPlayMusic == false) _audioSource.Pause(); //如果isPlayMusic为false,则暂停播放背景音乐  
    }
void OnGUI()
    {

        if (GUI.Button(new Rect(100, 10, 80, 30), "Play"))//绘制播放按钮并设置其点击后的处理 
        {
            //播放声音 
            if (isPlayMusic) _audioSource.Play();

            AddBtnSound();

        }

        if (GUI.Button(new Rect(100, 50, 80, 30), "Pause")) //绘制暂停按钮并设置其点击后的处理  
        {
            //暂停声音，暂停后再播放，则声音为继续播放  
            _audioSource.Pause();
            AddBtnSound();

        }

        if (GUI.Button(new Rect(100, 90, 80, 30), "Stop"))//绘制停止按钮并设置其点击后的处理  
        {
            //停止播放，停止后再播放，则声音为从头播放  
            _audioSource.Stop();
            AddBtnSound();
        }

        if (GUI.Button(new Rect(200, 10, 150, 30), "AddSound_Method_1"))//绘制添加音效按钮,PlayOnShot方式添加音效 
        {
            _audioSource.PlayOneShot(palyOnceSound);
            AddBtnSound();
        }

        if (GUI.Button(new Rect(200, 50, 150, 30), "AddSound_Method_2")) //绘制添加音效按钮，PlayClipAtPoint方式添加音效  
        {
            AudioSource.PlayClipAtPoint(palyOnceSound, _audioSource.transform.localPosition);
            AddBtnSound();
        }
        GUI.Label(new Rect(250, 130, 100, 30), "音量大小调节");//音量控制Label 
        _audioSource.volume = GUI.HorizontalSlider(new Rect(120, 130, 100, 20), _audioSource.volume, 0.0f, 1.0f);//音量控制slider  
        isPlayMusic = GUI.Toggle(new Rect(50, 170, 100, 20), isPlayMusic, "背景音乐");  //选择是否播放背景音乐  
        isPlayButtonSound = GUI.Toggle(new Rect(170, 170, 100, 20), isPlayButtonSound, "按钮音效");  //选择是否播放按键声音  
    }

    private void AddBtnSound()//添加按键声音  
    {
        if (isPlayButtonSound) AudioSource.PlayClipAtPoint(buttonSound, _audioSource.transform.localPosition);
    }

}