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
        public const int StaminaMax = 100;
        public int Stamina { get; private set; }

        void Reset()
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
}
