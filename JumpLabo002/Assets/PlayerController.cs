using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float velocity;
    bool IsTouch { get; set; }
    int touch_counter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var info = JpUtil.Touch.GetTouch();
        if (info == JpUtil.TouchInfo.None)
            IsTouch = false;
        else
            IsTouch = true;

        switch (GameState.Instance.State)
        {
            case GameState.GameStateType.Normal:
                Update_GameNormal();
                break;
            case GameState.GameStateType.Repair:
                Update_GameRepair();
                break;
        }
    }

    // ゲーム通常時
    void Update_GameNormal()
    {
        if (IsTouch && touch_counter < 60)
        {
            velocity = 10;
            touch_counter++;
        }

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
            touch_counter = 0;

            pos.y = 0;
            transform.localPosition = pos;

            Landing();
        }
    }

    // 着地時
    void Landing()
    {
        var param = GameState.Instance.PlayerParam;
        param.StaminaLoss(1);

        if (param.Stamina <= 0)
        {
            // スタミナなくなったー！回復モードへ
            GameState.Instance.State = GameState.GameStateType.Repair;
        }
    }

    // 天使の矢ステート
    void Update_GameRepair()
    {
        // 回復
        var param = GameState.Instance.PlayerParam;
        param.StaminaRepair(1);

        if (param.Stamina >= GameState.PlayerParametter.StaminaMax)
        {
            // 通常モードへ
            GameState.Instance.State = GameState.GameStateType.Normal;
        }
    }
}
