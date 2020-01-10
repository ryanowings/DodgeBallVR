using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectPickup : MonoBehaviour
{
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private GameObject obj;
    private FixedJoint fJoint;

    public float forceMod = 2f;
    private bool throwing;
    private Rigidbody rigidbody;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        fJoint = GetComponent<FixedJoint>();
    }

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (controller.GetPressDown(triggerButton))
        {
            PickUpObj();
        }

        if (controller.GetPressUp(triggerButton))
        {
            DropObj();
        }
        
    }

    

    void FixedUpdate()
    {
        if (throwing)
        {
            Transform origin;
            if (trackedObj.origin != null)
            {
                origin = trackedObj.origin;
                if (origin.gameObject.tag == "SpearPick")
                    origin.gameObject.tag = "Spear";
            }
            else
            {
                origin = trackedObj.transform.parent;
                if (origin.gameObject.tag == "SpearPick")
                    origin.gameObject.tag = "Spear";
            }
            /*
            if (origin.gameObject.tag == "Spear" || origin.gameObject.tag == "SpearPick")//SPEAR PHYSICS
            {
                origin.gameObject.tag = "Spear";
                rigidbody.useGravity = true;
                rigidbody.AddForce(gameObject.transform.forward * 30000);
                Vector3.Slerp(gameObject.transform.forward, rigidbody.velocity.normalized, Time.deltaTime * 2);
                rigidbody.ResetCenterOfMass();
                Debug.Log("SPEAR THROWN");
            }*/

            if (origin != null)
            {
                rigidbody.velocity = origin.TransformVector(controller.velocity) * forceMod;
                rigidbody.angularVelocity = origin.TransformVector(controller.angularVelocity * 0.25f);
            }
            else
            {
                rigidbody.velocity = controller.velocity * 2f;
                rigidbody.angularVelocity = controller.angularVelocity * forceMod;
            }
            
            

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;

            throwing = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickDead") || other.CompareTag("Spear") || other.CompareTag("SpearBad") || other.CompareTag("PickGood") || other.CompareTag("Shurk")) //ADD TAG FOR EACH OBJECT
        {
            obj = other.gameObject;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PickDead") || other.CompareTag("Spear") || other.CompareTag("SpearBad") || other.CompareTag("SpearPick") || other.CompareTag("PickGood") || other.CompareTag("Shurk")) //ADD TAG FOR EACH OBJECT
        {
            obj = other.gameObject;
        }
        //if (other.CompareTag("Spear"))
        //{
            //obj = other.gameObject;
        //}
        //if (other.gameObject.CompareTag("SpearBad"))
        //{
         //   other.gameObject.tag = "Spear";
        //}
    }

    void OnTriggerExit(Collider other)
    {
        obj = null;
    }

    void PickUpObj()
    {
        
        if (obj != null)
        {
            fJoint.connectedBody = obj.GetComponent<Rigidbody>();
            rigidbody = fJoint.connectedBody;
            if (fJoint.connectedBody.gameObject.tag == "Spear")
            {
                Debug.Log("Spear Pickup");
                rigidbody.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                fJoint.connectedBody.isKinematic = false;
            }
            if (fJoint.connectedBody.gameObject.tag == "SpearBad")
            {
                
                Debug.Log("Spear Pickup");
                fJoint.connectedBody.gameObject.tag = "SpearPick";
                rigidbody.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                fJoint.connectedBody.isKinematic = false;
            }
            if (obj.gameObject.tag == "PickDead")
            {
                obj.gameObject.tag = "PickGood";
            }
            
            
            throwing = false;
            rigidbody = null;
        }
        else
        {
            fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        if (fJoint.connectedBody != null)
        {
            rigidbody = fJoint.connectedBody;
            if(fJoint.connectedBody.gameObject.tag == "SpearPick")
                fJoint.connectedBody.gameObject.tag = "Spear";

            fJoint.connectedBody = null;

            throwing = true;

        }
    }
}