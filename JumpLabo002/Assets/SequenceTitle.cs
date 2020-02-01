using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Title メインシーケンス
public class SequenceTitle : MonoBehaviour
{
    void Awake()
    {
        GameState.Instance.SceneNow = GameState.SceneType.Title;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string NextSceneName = "GameScene01";

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
        }
    }
}
