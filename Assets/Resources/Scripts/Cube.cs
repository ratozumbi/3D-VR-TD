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
        base.OnHoverEnter(interactor);

        if (selection != null)
        {
            Destroy(selection);
        }
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);

        if (type == CubeType.empty)
        {
            Vector3 myPosition = Util.ToGridPosition(gameObject);
            
            var goBlock = Instantiate(Resources.Load<GameObject>("Prefabs/CubeBlock"), transform.position, transform.rotation, transform.parent);
            cubeGrid.grid[Util.toInt(myPosition.x), Util.toInt(myPosition.y), Util.toInt(myPosition.z)] = goBlock;
            var goStart = cubeGrid.grid[Util.toInt(cubeGrid.cubeStart_Position.x), Util.toInt(cubeGrid.cubeStart_Position.y), Util.toInt(cubeGrid.cubeStart_Position.z)];
            goStart.GetComponent<CubeStart>().UpdatePath();
            Destroy(gameObject);
        }
    }

}
