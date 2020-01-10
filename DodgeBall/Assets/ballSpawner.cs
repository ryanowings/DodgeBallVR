using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour {

    //public Transform ball;
    public GameObject toSpawn;
    public Transform target;
    
    bool isTime = false;
    //float timeLeft = Random.Range(2.0f, 7.0f);
    public float timeLeft;
    public int maxBalls = 20;
    int currentBalls = 0;

    public GameObject ball;
    public GameObject ballShow;
    public Rigidbody rb;
    public float ballThrowingForce = 10f;

    public GameObject bs;


    // Use this for initialization
    void Start()
    {
        target = playerMan.instance.player.transform;
        rb = ball.GetComponent<Rigidbody>();
        timeLeft = Random.Range(2.0f, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
        changeIsTime();
        timeLeft -= Time.deltaTime;
        thrower();
        if(timeLeft <=.5)
        {
            ballShow.SetActive(true);
        }
        else
        {
            ballShow.SetActive(false);
        }

    }

    
    void thrower()
    {
        if (isTime == true && currentBalls <= maxBalls)
        {

            
            GameObject bs = Instantiate(toSpawn, transform.position, transform.rotation);
            //bs.AddComponent<Rigidbody>();
            bs.GetComponent<Rigidbody>().AddForce(transform.forward * ballThrowingForce );

            currentBalls++;
            timeLeft = Random.Range(2f, 3f);
            isTime = false;

            //GameObject ball =  GameObject.Equals("ball");
            //ball.rigidbody. = origin.TransformVector(10);
            //rigidbody.angularVelocity = origin.TransformVector(10 * 0.25f);

            //ball1.rb.AddForce(transform.forward * 20.0f);
            

        }
    }

    void changeIsTime()
    {

        if (timeLeft <= 0)
        {
            isTime = true;
            //timeLeft = 300;
            timeLeft = Random.Range(2f, 3f);

        }
    }
}
