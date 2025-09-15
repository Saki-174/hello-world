using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Score s;
    private bool beDestoryed = false;
    //碰到吃掉他加一分
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (beDestoryed) { return; }
            Destroy(gameObject);     
            //摧毁物体后再加一分
            s.score += 1;
            beDestoryed = true;           
        }
    }
}
