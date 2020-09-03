﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
public abstract class Cube : XRBaseInteractable
{
    public GameGrid cubeGrid;

    private GameObject selection;

    public enum CubeType
    {
        empty,
        start,
        end,
        block
    }
    public CubeType type;

    private void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
    }

    public void SetValidSelection()
    {
        selection = Instantiate(Resources.Load<GameObject>("Prefabs/ValidGridSelection"), transform.position, Quaternion.identity, transform.parent);
    }

    public void SetInvalidSelection()
    {
        selection = Instantiate(Resources.Load<GameObject>("Prefabs/InvalidGridSelection"), transform.position, Quaternion.identity, transform.parent);
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
        base.OnHoverEnter(interactor);

        if(selection != null)
        {
            Destroy(selection);
        }
    }

}
