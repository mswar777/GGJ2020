using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochisukoController : MonoBehaviour
{
    public float Speed = 5.0f;
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = -Speed;
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
            velocity = Speed;
            OnTurn();
        }
        else if (pos.x > 500)
        {
            sprite.flipX = false;
            velocity = -Speed;
            OnTurn();
        }

        pos.x += velocity;
        transform.localPosition = pos;
    }

    void OnTurn()
    {
        GameState.Instance.StageParam.AddFloorHeight(-200);
    }
}
