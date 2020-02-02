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

    bool _is_hit;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = StartPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.localPosition;
        float relative_h = pos.y - HitTarget.transform.localPosition.y;
        relative_h = relative_h >= 0 ? relative_h : -relative_h;

        var player = HitTarget.GetComponent<PlayerController>();

        if (death_counter > 30)
        {
            Destroy(this.gameObject);
            return;
        }
        else if (_is_hit)
        {
            // ヒット後・・・
            death_counter++;
            // プレイヤー足下へ
            pos.y = HitTarget.transform.localPosition.y - 50;
        }
        else
        {
            // プレイヤーが上の時
            if (player.Velocity < 0 && HitTarget.transform.localPosition.y > pos.y)
            {
                // 矩形でヒットチェック
                if (pos.x < HitRadius &&
                    pos.x > -HitRadius &&
                    relative_h < HitHeight)
                {                
                    // Hit!
                    Debug.Log("Hit! " + transform.name);
                    _is_hit = true;
                    GetComponent<SpriteRenderer>().sprite = SpriteFall;
                    Velocity = 0;
                    death_counter = 0;
                    player.HitMochi = true;

                    // プレイヤー足下へ
                    pos.y = HitTarget.transform.localPosition.y - 50;
                }
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
