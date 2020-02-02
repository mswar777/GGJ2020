using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSequence : MonoBehaviour
{
    float timeout;

    // Start is called before the first frame update
    void Start()
    {
        timeout = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        string NextSceneName = "GameScene01";
        timeout -= Time.deltaTime;
        if (timeout <= 0.0f)
        {
            SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
        }
    }
}
