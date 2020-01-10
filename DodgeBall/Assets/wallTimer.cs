using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wallTimer : MonoBehaviour {
    public AudioSource beginSound;
    public float timer = 7f;
    private bool timeBool = true;
    public bool audioPlayed = false;
    Vector3 pos;

    private GameObject badMan;
    public GameObject spawn;
    public GameObject spawnSat;
    Vector3 spawnPos;
    Vector3 spawnPos1;
    Vector3 spawnPos2;
    Vector3 spawnSat1;
    Vector3 spawnSat2;

    public string sceneName;
    public Scene currentScene;
    public int manCount;
    public bool manDead;
    public AudioSource cheer;
    private bool levelTimer = false;
    private float levelTime = 3f;
    // Use this for initialization
    void Start () {

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(sceneName);
        spawnPos.y = 0f;
        spawnPos.x = -3.2f;
        spawnPos.z = 0f;

        spawnPos1.y = 0f;
        spawnPos1.x = -3.5f;
        spawnPos1.z = 0f;
        spawnPos2.y = 0f;
        spawnPos2.x = -1.4f;
        spawnPos2.z = 2.5f;

        spawnSat1.y = 4.95f;
        spawnSat1.x = -6.6f;
        spawnSat1.z = 5.26f;
        spawnSat2.y = 4.95f;
        spawnSat2.x = -6.6f;
        spawnSat2.z = -5.65f;

        manCount = 0;
        manDead=false;

    }
    public void manHit()
    {
        manCount = manCount + 1;
        Debug.Log("manCount++");
    }
    // Update is called once per frame
    void Update () {
        if (timeBool)
        {
            timer -= Time.deltaTime;
            if(audioPlayed == false && timer <= 1.7f  )
            {
                PlaySound();
                audioPlayed = true;

            }
            if (timer <= 0f )
            {
                pos = transform.position;
                pos.y = 1.6f;
                pos.x = 7.74f;
                transform.position = pos;
                timeBool = false;
                if(sceneName == "L1")
                    badMan = Instantiate(spawn, spawnPos, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                if(sceneName == "L3")
                {
                    GameObject badMan = Instantiate(spawn, spawnPos1, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                    GameObject badMan2 = Instantiate(spawn, spawnPos2, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                }
                if (sceneName == "L4")
                {
                    badMan = Instantiate(spawn, spawnPos2, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                    GameObject badMan2 = Instantiate(spawnSat, spawnSat1, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                    GameObject badMan3 = Instantiate(spawnSat, spawnSat2, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                }
                
                //gameObject.SetActive(false);
            }
            
        }
        
        if (levelTimer != true && manCount > 0 && sceneName == "L1")
        {
            levelTimer = true;
            
            CheerSound();
            Debug.Log("End plz");
            //SceneManager.LoadScene("L3");
            //ADD WIN SOUND
        }
        if (levelTimer != true && manCount > 1 && sceneName == "L3")
        {
            levelTimer = true;
            
            CheerSound();
            Debug.Log("End plz");
            //SceneManager.LoadScene("L3");
            //ADD WIN SOUND
        }
        if (levelTimer != true && manCount > 2 && sceneName == "L4")
        {
            levelTimer = true;

            CheerSound();
            Debug.Log("End plz");
            //SceneManager.LoadScene("L3");
            //ADD WIN SOUND
        }
        if (levelTimer)
            levelTime -= Time.deltaTime;
        if(levelTime <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlaySound()
    {
        Debug.Log("BEGIN PLAYED");
        beginSound.Play(0);
        
    }
    public void CheerSound()
    {
        Debug.Log("cheer PLAYED");
        cheer.Play(0);

    }

}
