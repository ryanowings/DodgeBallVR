using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "start")
        {

            Destroy(collision.gameObject);
            SceneManager.LoadScene("start");
        }

        if (collision.gameObject.name == "exit")

        {
            Application.Quit();
            Debug.Log("exit");
        }


    }
}
