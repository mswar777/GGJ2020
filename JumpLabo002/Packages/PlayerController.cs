using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float velocity;
    Slider _slider;
    int stamina = 100;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 10;
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState.Instance.State)
        {
            case GameState.GameStateType.Normal:
                Update_GameNormal();
                break;
            case GameState.GameStateType.Repair:
                Update_GameRepair();
                break;
        }
        _slider.value = stamina;
    }

    // ゲーム通常時
    void Update_GameNormal()
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
            stamina -= 10;

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
