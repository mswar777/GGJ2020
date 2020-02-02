using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowsmove2 : MonoBehaviour
{
    
    public float power = 1000f;
    public GameObject Arrow;
    public Transform spawnPoint;
    int[] dice = new int[] { 1, 2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30};
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      

   


    

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
            Vector3.right * power);
    }
    private void OnCollisionEnte2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AngelGround"))
            GetComponent<Rigidbody2D>().AddForce(
               Vector3.up * jumpPower);
    }
}
