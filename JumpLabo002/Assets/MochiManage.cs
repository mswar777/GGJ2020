using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiManage : MonoBehaviour
{
    [SerializeField]
    GameObject MochiPrefab;

    public float MinY = 0;
    public float MaxY = 400;
    public float SpawnSpan = 5;
    float _spawn_time = 0;
    public float ScreenX = 700;
    public float SpeedMin = 4;
    public float SpeedMax = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _spawn_time += Time.fixedDeltaTime;
        if (_spawn_time >= SpawnSpan)
        {
            _spawn_time = 0;
            CreateMochi();
        }
    }

    void CreateMochi()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        var mochi = GameObject.Instantiate(MochiPrefab, pos, Quaternion.identity);

        // Manageの下に作るよ
        mochi.transform.SetParent(this.transform);
        var controller = mochi.GetComponent<MochiController>();
        controller.StartPosition.y = Random.Range(MinY, MaxY);
        controller.Velocity = Random.Range(SpeedMin, SpeedMax);
        if (Random.Range(0.0f, 1.0f) > 0.5f)
        {
            controller.StartPosition.x = ScreenX;
            controller.Velocity *= -1.0f;
        }
        else
        {
            controller.StartPosition.x = -ScreenX;
        }
    }
}
