using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _velocity;
    bool IsTouch { get; set; }
    bool IsEndTouch { get; set; }
    int _touch_counter;
    int _landing_counter;
    float _floor_height;
    SpriteRenderer _sprite;

    [SerializeField]
    private Sprite SpriteWait;
    [SerializeField]
    private Sprite SpriteJump;
    [SerializeField]
    private Sprite SpriteFall;
    [SerializeField]
    private Sprite SpriteLanding;

    void Awake()
    {
        _touch_counter = 0;
        _velocity = 0;
        _floor_height = transform.localPosition.y;
        _landing_counter = 0;
        
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = SpriteWait;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    {
        IsTouch = false;
        IsEndTouch = false;
        var info = JpUtil.Touch.GetTouch();
        if (info != JpUtil.TouchInfo.None)
            IsTouch = true;
        if (info != JpUtil.TouchInfo.Ended)
            IsEndTouch = true;

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
        
        if (_landing_counter == 0 && _touch_counter < 20)
        {
            if (IsTouch)
            {
                _velocity = 40;
                _touch_counter++;
                _sprite.sprite = SpriteJump;
            }
            else
            {
                _landing_counter = 3;
            }
        }
        else
        {
            if (pos.y > _floor_height)
            {
                _velocity -= 4.0f;
                //Debug.Log("OnJump : pos " + pos.y);            
            }
            else if (_landing_counter > 0)
            {
                _landing_counter--;
                _velocity = 0;
                if (_sprite.sprite != SpriteLanding)
                    _sprite.sprite = SpriteLanding;
            }
            else
            {
                // 着地
                _landing_counter = 0;
                _touch_counter = 0;

                Debug.Log("OnLanding : pos " + pos.y);
                OnLanding();
            }
        }

        pos.y += _velocity;
        if (pos.y < 0)
            pos.y = 0;
        transform.localPosition = pos;
    }

    // 着地時
    void OnLanding()
    {
        var param = GameState.Instance.PlayerParam;
        param.StaminaLoss(5);

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
