using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochisukoController : MonoBehaviour
{
    const float speed = 1.0f;
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var sprite = GetComponent<SpriteRenderer>();
        var pos = transform.localPosition;
        if (pos.x < -500)
        {
            sprite.flipX = true;
            velocity = speed;
        }
        else if (pos.x > 500)
        {
            sprite.flipX = false;
            velocity = -speed;
        }

        pos.x += velocity;
        transform.localPosition = pos;
    }
}
