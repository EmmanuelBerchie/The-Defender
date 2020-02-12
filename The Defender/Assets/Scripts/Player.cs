using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        // determining where we want the ship to be and how to control it
        var deltaX = Input.GetAxis("Horizontal"); 
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector2(newXPos, transform.position.y); 
        
    }
}
