using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{    //单例模式用来确保角色只有一个状态
    public static PlayerState Instance { get; private set; }
    private void Awake()
    {       
        Instance = this;       
    }
    public enum State
    {
        idle,
        move,
        jump,
        doubleJump,
        fall,
        dead
    }
    public State state;
    // Start is called before the first frame update
    
    void Start()
    {
        state = State.idle;//初始化
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
