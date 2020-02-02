using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabitMove : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = new Vector2(-speed,0);
        rb.AddForce(force);
    }
    
}
