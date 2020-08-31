using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GridGrab : MonoBehaviour
{
    public XRBaseInteractor referenceHandLeft = null;
    public XRBaseInteractor referenceHandRight = null;

    private XRBaseInteractor hand1 =null;
    private XRBaseInteractor hand2 = null;

    private Vector3 initialHandPosition1 = Vector3.zero;
    private Vector3 initialHandPosition2 = Vector3.zero;

    private Vector3 initialObjectScale = new Vector3(1, 1, 1);
    private Quaternion initialObjectRotation = Quaternion.identity;
    private Vector3 initialObjectDirection = Vector3.zero;

    private Transform origParent = null;

    private bool bothGrab = false;
    public GameControlls ButtonsMap;
    void Start()
    {

        //ButtonsMap.Map.StopScale.canceled += 
        if(hand2 == null)
        {
            initialHandPosition1 = hand1.attachTransform.localPosition;
            initialHandPosition2 = hand2.attachTransform.localPosition;
            initialObjectRotation = transform.rotation;
            initialObjectScale = transform.localScale;
            initialObjectDirection = transform.position - (initialHandPosition1 + initialHandPosition2) * 0.5f;
        }

    }

    public void OnStartScale(InputValue input)
    {
        print("pressed ");
        bothGrab = true;
    }
    public void OnStopScale(InputValue input)
    {
        print("pressed stop");
        bothGrab = false;
    }

    public void Update() 
    {

        if (false && referenceHandLeft != null && referenceHandRight != null)
        {
            Vector3 currentHandPosition1 = hand1.attachTransform.position; // current first hand position
            Vector3 currentHandPosition2 = hand2.attachTransform.position; // current second hand position

            Vector3 handDir1 = (initialHandPosition1 - initialHandPosition2).normalized; // direction vector of initial first and second hand position
            Vector3 handDir2 = (currentHandPosition1 - currentHandPosition2).normalized; // direction vector of current first and second hand position 

            Quaternion handRot = Quaternion.FromToRotation(handDir1, handDir2); // calculate rotation based on those two direction vectors

            float currentGrabDistance = Vector3.Distance(currentHandPosition1, currentHandPosition2);
            float initialGrabDistance = Vector3.Distance(initialHandPosition1, initialHandPosition2);
            float p = (currentGrabDistance / initialGrabDistance); // percentage based on the distance of the initial positions and the new positions

            Vector3 newScale = new Vector3(p * initialObjectScale.x, p * initialObjectScale.y, p * initialObjectScale.z); // calculate new object scale with p

            transform.rotation = handRot * initialObjectRotation; // add rotation
            transform.localScale = newScale; // set new scale

            // set the position of the object to the center of both hands based on the original object direction relative to the new scale and rotation
            transform.position = (0.5f * (currentHandPosition1 + currentHandPosition2)) + (handRot * (initialObjectDirection * p));

        }
    
    }
}
