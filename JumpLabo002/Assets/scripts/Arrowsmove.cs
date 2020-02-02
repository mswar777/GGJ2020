using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowsmove : MonoBehaviour
{

    Rigidbody2D rb2d;
    public float power = 1000f;
    public GameObject Arrow;
    public Transform spawnPoint;
    
    int[] dice = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //射出機の上下移動
        
       


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
    private void OnCollisionEnte2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("AngelGround"))
        this.rb2d.AddForce(
           transform.up * jumpPower);
    }
}
