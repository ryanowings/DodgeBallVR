using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMan : MonoBehaviour {


        #region Singleton
    public static playerMan instance;
    private void Awake()
    {
        instance = this;


    }


    #endregion

    // Use this for initialization
    public GameObject player;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
