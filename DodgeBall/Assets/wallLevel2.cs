using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wallLevel2 : MonoBehaviour
{
    public AudioSource beginSound;
    public float timer = 7f;
    private bool timeBool = true;
    public bool audioPlayed = false;
    Vector3 pos;

    private GameObject badMan;
    private GameObject badMan2;
    public GameObject spawn;
    Vector3 spawnPos1;
    Vector3 spawnPos2;

    public string sceneName;
    public Scene currentScene;
    public int manCount;
    public bool manDead;
    public AudioSource cheer;
    private bool levelTimer = false;
    private float levelTime = 2.5f;
    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(sceneName);
        spawnPos1.y = 0f;
        spawnPos1.x = -3.5f;
        spawnPos1.z = 0f;
        spawnPos2.y = 0f;
        spawnPos2.x = -1.4f;
        spawnPos2.z = 2.5f;
        manCount = 0;
        manDead = false;
    }
    public void manHit()
    {
        manCount = manCount + 1;
        Debug.Log("manCount++");
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBool)
        {
            timer -= Time.deltaTime;
            if (audioPlayed == false && timer <= 1.7f)
            {
                PlaySound();
                audioPlayed = true;

            }
            if (timer <= 0f)
            {
                pos = transform.position;
                pos.y = -13.46f;
                transform.position = pos;
                timeBool = false;
                GameObject badMan = Instantiate(spawn, spawnPos1, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                GameObject badMan2 = Instantiate(spawn, spawnPos2, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                //gameObject.SetActive(false);
            }
        }
        if (manCount == 1)
        {
            manDead = true;

        }
        if (manDead)
        {
            levelTimer = true;
            PlaySound();
            CheerSound();
            //Debug.Log("End plz");
            //SceneManager.LoadScene("L3");
            //ADD WIN SOUND
        }
        if (levelTimer)
            levelTime -= Time.deltaTime;
        if (levelTime <= 0)
            SceneManager.LoadScene("L4");
    }
    void PlaySound()
    {
        Debug.Log("BEGIN PLAYED");
        beginSound.Play(0);

    }
    void CheerSound()
    {
        Debug.Log("cheer PLAYED");
        cheer.Play(0);

    }
}
