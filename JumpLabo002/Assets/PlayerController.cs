using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float velocity;
<<<<<<< HEAD
    public int stamina = 100;
=======
    bool IsTouch { get; set; }
    bool IsEndTouch { get; set; }
    int touch_counter;
    int jump_trigger;
    float floor_height;

    void Awake()
    {
        touch_counter = 0;
        velocity = 0;
        floor_height = transform.localPosition.y;
        jump_trigger = 0;
    }
>>>>>>> d8356f979b53e8471367f268468959b56735efde

    // Start is called before the first frame update
    void Start()
    {
        velocity = 10;
    }

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    {
<<<<<<< HEAD
=======
        IsTouch = false;
        IsEndTouch = false;
        var info = JpUtil.Touch.GetTouch();
        if (info != JpUtil.TouchInfo.None)
            IsTouch = true;
        if (info != JpUtil.TouchInfo.Ended)
            IsEndTouch = true;

>>>>>>> d8356f979b53e8471367f268468959b56735efde
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
        var pos = transform.localPosition;
<<<<<<< HEAD
        pos.y += velocity;
        transform.localPosition = pos;
        if (transform.localPosition.y > 0)
=======

        if (IsTouch && (touch_counter < 30))
        {
            if (touch_counter == 0)
                jump_trigger = 1;
            velocity = 40;
            touch_counter++;
        }

        if (jump_trigger > 0 && pos.y >= floor_height)
>>>>>>> d8356f979b53e8471367f268468959b56735efde
        {
            velocity -= 4.0f;
Debug.Log("OnJump : pos " + pos.y);            
        }
        else
        {
            // 着地
<<<<<<< HEAD
            pos.y = 0.0f;
            transform.localPosition = pos;
            velocity = 10;

            Landing();
=======
            touch_counter = 0;
            jump_trigger = 0;

            velocity = 0;
            pos.y = 0;
            transform.localPosition = pos;
Debug.Log("OnLanding : pos " + pos.y);
            OnLanding();
>>>>>>> d8356f979b53e8471367f268468959b56735efde
        }

        pos.y += velocity;
        transform.localPosition = pos;
    }

    // 着地時
    void OnLanding()
    {
        var param = GameState.Instance.PlayerParam;
<<<<<<< HEAD
        param.StaminaLoss(1);
        stamina -= 10;
=======
        param.StaminaLoss(5);
>>>>>>> d8356f979b53e8471367f268468959b56735efde

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
