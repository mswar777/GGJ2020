using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGameMain : MonoBehaviour
{
    void Awake()
    {
        GameState.Instance.SceneNow = GameState.SceneType.Game01;
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
