using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public abstract class Cube : XRBaseInteractable
{
    public GameGrid cubeGrid;

    protected GameObject selection;

    public UnityEvent CubeChanged;

    public enum CubeType
    {
        empty,
        start,
        end,
        block
    }
    public CubeType type;

    public void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
    }

    public void SetValidSelection()
    {
        selection = Instantiate(Resources.Load<GameObject>("Prefabs/ValidGridSelection"), transform.position, transform.rotation, transform);
    }

    public void SetInvalidSelection()
    {
        selection = Instantiate(Resources.Load<GameObject>("Prefabs/InvalidGridSelection"), transform.position, transform.rotation, transform);
    }

    protected override void OnHoverEnter(XRBaseInteractor interactor)
    {
        base.OnHoverEnter(interactor);
        if (selection != null) return;

        if (type == CubeType.empty)
        {
            SetValidSelection();
        }
        else
        {
            SetInvalidSelection();
        }
    }
    protected override void OnHoverExit(XRBaseInteractor interactor)
    {
        base.OnHoverExit(interactor);

        if(selection != null)
        {
            Destroy(selection);
        }
    }

    protected virtual void OnCubeChanged()
    {
        CubeChanged?.Invoke();
    }

}
