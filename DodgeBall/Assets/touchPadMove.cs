using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touchPadMove : MonoBehaviour
{

    [SerializeField]
    private Transform rig;

    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private Vector2 axis = Vector2.zero;
    private Vector3 pos;

    public string sceneName;
    public Scene currentScene;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (controller.GetTouch(touchpad))
        {
            axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

            if (rig != null)
            {
                if((sceneName != "start") && (sceneName != "L2"))
                {
                    if (rig.position.x > 5.15f)
                    {
                        pos = rig.position;
                        pos.x = 5.15f;
                        rig.position = pos;
                    }
                    if (rig.position.x < 1f)
                    {
                        pos = rig.position;
                        pos.x = 1f;
                        rig.position = pos;
                    }
                    if (rig.position.z > 3.2f)
                    {
                        pos = rig.position;
                        pos.z = 3.2f;
                        rig.position = pos;
                    }
                    if (rig.position.z < -3.1f)
                    {
                        pos = rig.position;
                        pos.z = -3.1f;
                        rig.position = pos;
                    }
                }
                

                rig.position += (transform.right * axis.x + transform.forward * axis.y) * Time.deltaTime;
                rig.position = new Vector3(rig.position.x, 0, rig.position.z);
            }
        }

    }
}