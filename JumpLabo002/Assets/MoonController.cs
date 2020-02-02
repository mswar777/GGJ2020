using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.localPosition;
        pos.y= GameState.Instance.StageParam.FloorHeight;
        transform.localPosition = pos;
    }
}
