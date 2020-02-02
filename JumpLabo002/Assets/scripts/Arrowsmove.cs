using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowsmove : MonoBehaviour
{
    public float speed;
    public float moveableRange = 5.5f;
    public float power = 1000f;
    public GameObject Arrow;
    public Transform spawnPoint;
    public float moveRange;
    int[] dice = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw(
            "Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(
                    transform.position.x, -moveableRange, moveableRange),
                    transform.position.y);

        //射出機の上下移動
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, moveRange), transform.position.z);

       
    }
    private void FixedUpdate()
    {
        RandomShoot();
    }

    void RandomShoot()
    {
        int index = Random.Range(0, 20);

        int shoot = dice[index];

        if (shoot == 2)
        {
            shooting();
        }

    }

    void shooting()
    {
        GameObject newArrow =
            Instantiate(Arrow, spawnPoint.position,
            Quaternion.identity) as GameObject;
        newArrow.GetComponent<Rigidbody2D>().AddForce(
            Vector3.left * power);
    }
}
