using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance {  get; private set; } //����ģʽ����ȷ����ɫֻ��һ��״̬
    public static PlayerState Instance
    {
        get
        {
            //ȷ��ֻ��һ��ʵ��
            if(instance == null)
                instance = new PlayerState();
            return instance;
        }
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
        state = State.idle;//��ʼ��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
