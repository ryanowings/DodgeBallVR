using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetCollision : MonoBehaviour {
    public Rigidbody rb;
    
    public bool hit = false;

    public enemyMan man;

    public tCount tarCount;
    public wallTimer wall;
    //public int manCount;
    //public string sceneName;

    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody>();
        
        //TCount = FindObjectOfType<tCount>();
        //tarCount = gameObject.GetComponent("tCount") as tCount;
        // if hasGun has not yet been set in the inspector see if there is one attched to the current component
        if ((tarCount == null) && (GetComponent<tCount>() != null))
        {
            tarCount = GetComponent<tCount>();
        }
        if ((wall == null) && (GetComponent<wallTimer>() != null))
        {
            wall = GetComponent<wallTimer>();
        }

    }
	
	// Update is called once per frame
	void Update () {
       rb.drag = 0;
       if (rb.transform.position.y < .2f)
        {
            rb.drag = .5f;
            //rb.angularVelocity = Vector3.;
        }
        


    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "trigger")
        {
            tarCount.basketMade();

        }
    }

        private void OnCollisionEnter(Collision collision)
    {
        
        if((collision.gameObject.name == "NPC_cross" || collision.gameObject.CompareTag("Target") || collision.gameObject.tag == "Hit" || collision.gameObject.tag == "Sat") && (gameObject.tag == "PickGood" || gameObject.tag == "Spear" || gameObject.tag == "Shurk") )
        {
            //man.Hit();
            hit = true;
            
            Destroy(collision.gameObject);

            if (collision.gameObject.CompareTag("Hit"))
            {
                wall.manHit();
                Debug.Log("MAN Hit");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (collision.gameObject.CompareTag("Target"))
            {
                tarCount.tarCountUp();
                Debug.Log("Target Hit");
            }
            
        }

        if(rb.gameObject.tag == "Live" && (rb.gameObject.tag == "Spear" || rb.gameObject.tag == "SpearBad" || rb.gameObject.tag == "SpearPick" || rb.gameObject.tag == "Shurk" || rb.gameObject.tag == "PickGood"))
            gameObject.tag = "PickDead";

        if ((collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor"))&& rb.gameObject.tag != "Spear" && rb.gameObject.tag != "SpearBad" && rb.gameObject.tag != "SpearPick" && rb.gameObject.tag != "Shurk" && rb.gameObject.tag != "Hit" && rb.gameObject.name != "NPC_cross")
        {                                                                                             //can probably change this to rb.gameObject.tag == "PickGood"
            gameObject.tag = "PickDead";

            rb.drag = 1;
            //Destroy(collision.gameObject);
            //Debug.Log("Wall Hit");
        }
        if (collision.gameObject.CompareTag("Wall") && (rb.gameObject.tag == "Spear" || rb.gameObject.tag == "Shurk"))
        {
            if(rb.gameObject.CompareTag("Spear"))
            {
                gameObject.tag = "SpearBad";
            }
            rb.isKinematic = true;
        }
        

    }

}
