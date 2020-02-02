using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiController : MonoBehaviour
{
    [SerializeField]
    Sprite SpriteNormal;
    [SerializeField]
    Sprite SpriteFall;

    public GameObject HitTarget;

    int ScreenX = 700;

    public float Velocity;
    public Vector2 StartPosition;
    public float HitRadius;
    public float HitHeight;

    int death_counter;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = StartPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.localPosition;

        if (death_counter > 40)
        {
            Destroy(this.gameObject, 0.1f);
            return;
        }
        if (Velocity == 0)
        {
            death_counter++;
        }

        // プレイヤーが上の時
        var player = HitTarget.GetComponent<PlayerController>();
        if (player.IsFalling && HitTarget.transform.position.y > pos.y)
        {
            // 矩形でヒットチェック
            float relative_h = pos.y - HitTarget.transform.position.y;
            relative_h = relative_h >= 0 ? relative_h : -relative_h; 
            if (pos.x < HitRadius &&
                pos.x > -HitRadius &&
                relative_h < HitHeight)
            {                
                // Hit!
                Debug.Log("Hit! " + transform.name);
                GetComponent<SpriteRenderer>().sprite = SpriteFall;
                Velocity = 0;
                // プレイヤー足下へ
                pos.y = HitTarget.transform.position.y - relative_h;
            }
        }

        // 移動
        pos.x += Velocity;
        transform.localPosition = pos;

        // 画面外に出ると消滅
        if (Velocity > 0)
        {
            if (pos.x > ScreenX)
            {
                Destroy(this.gameObject);
            }
        }
        else if (Velocity < 0)
        {
            if (pos.x < -ScreenX)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
