using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 突貫なので、パラメーター全公開やで！
public class GameState
{
    // 暫定だし公開シングルトン化するやで ;-p
    public static GameState Instance 
    {
        get {
            if (_state_instance == null)
                _state_instance = new GameState();
            return _state_instance;
        }
    }
    static GameState _state_instance;

    public enum SceneType {
        Title,
        Game01,
        GameOver,
        Ending,
    }

    public SceneType SceneNow { get; set; }

    // ゲーム中状態
    public enum GameStateType
    {
        Normal, // 通常ゲームシーン
        Repair, // 天使の矢タイム
    }
    public GameStateType State { get; set; }

    public class PlayerParametter

    {
        public const int StaminaMax = 1000;
        public int Stamina { get; private set; }

        public void Reset()
        {
            Stamina = StaminaMax;
        }

        public void StaminaRepair(int n)
        {
            Stamina += n;
            if (Stamina > StaminaMax)
                Stamina = StaminaMax;

        }

        public void StaminaLoss(int n)
        {
            Stamina -= n;
            if (Stamina < 0)
                Stamina = 0;
        }
    }
    public PlayerParametter PlayerParam = new PlayerParametter();

    public class StageParametter
    {
        public float StartHeight = -200;
        public float WinHeight = 600;

        public float LoseHeight = -500;

        public float FloorHeight { get; private set; }


        public void Reset()
        {
            FloorHeight = StartHeight;
        }

        public void AddFloorHeight(float n)
        {
            FloorHeight += n;
            if (FloorHeight > WinHeight)
                FloorHeight = WinHeight;
            if (FloorHeight < LoseHeight)
                FloorHeight = LoseHeight;
        }

        public bool IsWin
        {
            get { return FloorHeight >= WinHeight; }
        }

        public bool IsLose
        {
            get { return FloorHeight <= LoseHeight; }
        }

    }

    public StageParametter StageParam = new StageParametter();
}
