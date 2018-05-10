using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public float _speed;
    public GameObject Player;
    public Animator _anim;
	// Use this for initialization
	void Start () {
        if(flag.is_transformed == 21)
            Player.transform.localPosition = new Vector2((float)5.95, (float)-2.3);
        _anim = GetComponent<Animator>();
        //DontDestroyOnLoad(Player);
    }
    void Move()//操控移动函数
    { 
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))*_speed*Time.deltaTime,Space.World);
        _anim.SetInteger("runhor", (int)Input.GetAxisRaw("Horizontal")); //横向状态切换标识 <0向左 0横向不动 >0向右
        _anim.SetInteger("runver", (int)Input.GetAxisRaw("Vertical")); //纵向状态切换标识 <0向下 0纵向不动 >0向上
        //状态切换标识在plyer animator切换动画时使用
    }
     
 
    // Update is called once per frame
    void Update () {
        Move();
	}
}
