using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;
        pos.y += velocity;
        transform.localPosition = pos;
        if (transform.localPosition.y > 0)
        {
            velocity -= 0.2f;
        }
        else
        {
            pos.y = 0;
            transform.localPosition = pos;
            velocity = 10;
        }
    }
}
