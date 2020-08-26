using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class OffsetGrab : XRGrabInteractable
{
    private XRBaseInteractor interactor1;
    private XRBaseInteractor interactor2;
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    private void Start()
    {
        //TODO: make these public to unity editor
        movementType = MovementType.Kinematic;
        smoothPosition = true;
        smoothPositionAmount = 1f;
        smoothRotation = true;
        smoothRotationAmount = 1f;

        throwOnDetach = false;
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        StoreInteractor(interactor);
        MatchAttachmentPoints(interactor);

    }


    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttachment = attachTransform != null;
        interactor.attachTransform.position = hasAttachment ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttachment ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        ResetAttachmentPoints(interactor);
        ClearInteractor(interactor);
    }

    private void ResetAttachmentPoints(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
