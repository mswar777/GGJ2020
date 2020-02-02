using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiController : MonoBehaviour
{
    [SerializeField]
    Sprite SpriteNormal;
    [SerializeField]
    Sprite SpriteFall;

    int ScreenX = 700;

    public float Velocity;
    public Vector2 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = StartPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.localPosition;
        pos.x += Velocity;
        transform.localPosition = pos;

        // 画面外に出ると消滅
        if (Velocity > 0)
        {
            if (pos.x > ScreenX)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
        else if (Velocity < 0)
        {
            if (pos.x < -ScreenX)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
