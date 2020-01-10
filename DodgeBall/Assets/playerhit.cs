using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerhit : MonoBehaviour {
    public AudioSource playerHit;
    public GameObject hitLight;

    private float timer = 0f;
    private bool timerBool = false;

    public int manCount = 0;
    public string sceneName;
    public Scene currentScene;

    public int lives = 3;
    // Use this for initialization
    void Start () {
        //playerHit = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

    }

    // Update is called once per frame
    void Update () {

        if(timerBool)
            timer += Time.deltaTime;

        if (timer > 2.5f)
        {
            //SceneManager.LoadScene("L1");//restart level
            Scene loadedLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadedLevel.buildIndex);
            
        }
        if (sceneName == "L1" && manCount == 1)
        {
            SceneManager.LoadScene("L3");
            //ADD WIN SOUND
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Live")
        {
            Debug.Log("Player Hit");
            playerHit.Play(0);
            
            hitLight.SetActive(true);//Hit light on
            timerBool = true;
            

        }
    }
    public void manHit()
    {
        manCount = manCount + 1;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Live")
        {

            Debug.Log("Player Hit");
            playerHit.Play(0);
            
            
            hitLight.SetActive(true);//Hit light on
            timerBool = true;
            
        }
    }
}
