using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Practice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Hit")
        {

            Destroy(collision.gameObject);
            SceneManager.LoadScene("L1");
        }

        


    }
}
