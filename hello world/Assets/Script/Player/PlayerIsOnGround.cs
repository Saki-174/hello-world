using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsOnGround : MonoBehaviour
{
    public static bool isOnGround;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
