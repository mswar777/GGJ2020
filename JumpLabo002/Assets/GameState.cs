using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 突貫なので、パラメーター全公開やで！
public class GameState : MonoBehaviour
{
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

    // ゲーム中パラメータ
    public class Parametter
    {
        const int stamina_max = 100;
        public int stamina;

        public void Reset()
        {
            stamina = stamina_max;
        }
    }

    public Parametter Param { get; set; }


    void Awake()
    {
        //Param.Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
