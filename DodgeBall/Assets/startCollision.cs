using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class startCollision : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "target")
        {

            Destroy(collision.gameObject);
            SceneManager.LoadScene("L2");
        }

        if (collision.gameObject.name == "exit")

        {
            Application.Quit();
            Debug.Log("exit");
        }


    }
}