using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyMan : MonoBehaviour {

    public Transform ball;
    public Object toSpawn;
    public Transform target;
    NavMeshAgent agent;
    bool isTime = true;
    //float timeLeft = Random.Range(2.0f, 7.0f);
    float timeLeft = 300f;
    public int maxBalls = 20;
    int currentBalls = 0;

    Vector3 pos;
    Quaternion rot;

    public float speed = 1f;
    public int speedRand;
    public bool hit = false;
    public Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        target = playerMan.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

        speedRand = Random.Range(1, 10);
        if (speedRand < 6)
            speed = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        faceTarget();
        //changeIsTime();
        //timeLeft--;
        //thrower();

        // *Enemy Movement*

        if (transform.position.y < 3f)
        {
            if (rb.transform.position.z < -3.2f)
            {
                speed = -speed;
                pos = transform.position;
                pos.z = -3.1f;
                transform.position = pos;
            }
            if (rb.transform.position.z > 3.5)
            {
                speed = -speed;
                pos = transform.position;
                pos.z = 3.46f;
                transform.position = pos;
            }
            if (rb.transform.position.x < -5.5f)
            {
                speed = -speed;
                pos = transform.position;
                pos.x = -5.45f;
                transform.position = pos;
            }
            if (rb.transform.position.x > -.5f)
            {
                speed = -speed;
                pos = transform.position;
                pos.x = -.45f;
                transform.position = pos;
            }
            if (rb.transform.rotation.x != 0)
            {
                rot = transform.rotation;
                rot.x = 0;
                transform.rotation = rot;
            }

            if (hit == false)
            {
                //pos = transform.position;
                //pos.x += speed;
                //transform.position = pos;
                rb.gameObject.transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            }

        }
        else
        {
            pos = transform.position;
            
            transform.position = pos;
        }
            



    }
    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void thrower()
    {
        if (currentBalls <= maxBalls)
        {
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //GameObject ball = Prefab.CreatePrimitive(PrimitiveType.Sphere);


            float xvar = Random.Range(1.0f, 3.0f);
            float yvar = Random.Range(1.0f, 2.0f);
            float zvar = Random.Range(1.0f, 3.0f);
            //Instantiate(ball, new Vector3(xvar, yvar, zvar),Quaternion.identity);
            //Instantiate(toSpawn, transform.position, transform.rotation);
            Debug.Log("Sphere spawned");
            Debug.Log(transform.position);
            currentBalls= currentBalls + 1;
            timeLeft = Random.Range(200f, 300f);
            isTime = false;

        }
    }

    void changeIsTime()
    {
        
        if (timeLeft<=0)
        {
            isTime = true;
            //timeLeft = 300;
            timeLeft = Random.Range(200f, 300f);
            
        }
    }
    public void Hit()
    {
        hit = true;
    }
}