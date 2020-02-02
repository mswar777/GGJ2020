using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMoving : MonoBehaviour
{
    float scale;
    bool up_scale;
    Vector3 original_scale;

    // Start is called before the first frame update
    void Start()
    {
        up_scale = true;
        scale = 1.0f;
        original_scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (up_scale)
        {
            scale += 0.0002f;
            if (scale > 1.03f)
            {
                scale = 1.03f;
                up_scale = false;
            }
        }
        else
        {
            scale -= 0.0002f;
            if (scale < 1.00f)
            {
                scale = 1.00f;
                up_scale = true;
            }
        }
        var tmpScale = transform.localScale;
        tmpScale = original_scale * scale;
        transform.localScale = tmpScale;
        //transform.rotation = new Vector3(0, 0, scale * 10);
    }
}
