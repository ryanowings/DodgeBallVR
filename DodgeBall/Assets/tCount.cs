using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tCount : MonoBehaviour {

    public int tarCount;
    private bool target;
    public bool basket;
    private string sceneName;
    public Scene currentScene;
    public AudioSource swish;
    public AudioSource cheer;
    private bool levelTimer = false;
    private float levelTime = 3f;

    // Use this for initialization
    void Start() {
        tarCount = 0;
        target = false;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void tarCountUp()
    {
        tarCount = tarCount + 1;
        Debug.Log("Target Count");
    }
    public void basketMade()
    {
        swish.Play(0);
        if(sceneName != "L2")
            cheer.Play(0);
        
        basket = true;
    }
	// Update is called once per frame
	void Update () {
        if (tarCount == 3)
        {
            //SceneManager.LoadScene("L1");
            target = true;
        }
        if (target && basket)
        {
            levelTimer = true;
            cheer.Play(0);
            //SceneManager.LoadScene("L1");
        }
        if(sceneName == "L5" && basket)
        {
            levelTimer = true;
            //SceneManager.LoadScene("L6");
        }
        
        if (levelTimer)
            levelTime -= Time.deltaTime;
        if (levelTime <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
