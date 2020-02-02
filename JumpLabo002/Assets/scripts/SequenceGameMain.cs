using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceGameMain : MonoBehaviour
{
    [SerializeField]
    private GameObject RepairObject;

    void Awake()
    {
        GameState.Instance.SceneNow = GameState.SceneType.Game01;
        GameState.Instance.PlayerParam.Reset();
        GameState.Instance.StageParam.Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.StageParam.IsWin)
        {
            SceneManager.LoadScene("ClearScene");
        }
        if (GameState.Instance.StageParam.IsLose)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        // 回復中〜
        if (GameState.Instance.State == GameState.GameStateType.Repair)
        {
            if (RepairObject.activeSelf == false)
                RepairObject.SetActive(true);
        }
        else
        {
            if (RepairObject.activeSelf)
                RepairObject.SetActive(false);
        }
    }
}
