using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    class PlayerParametter

    {
        public const int stamina_max = 100;
        public int stamina;
        void Reset()
        {
            stamina = stamina_max;
        }
    }

    PlayerParametter param = new PlayerParametter();
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
            // 着地
            pos.y = 0;
            transform.localPosition = pos;
            velocity = 10;

            Landing();
        }
    }

    // 着地時
    void Landing()
    {
        param.stamina -= 1;
    }
}
