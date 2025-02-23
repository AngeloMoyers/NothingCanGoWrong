using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacementManager : MonoBehaviour
{
    [SerializeField] Grid PlacementGrid;
    GameObject GhostGO;
    TrapObject CurrentPlacementTrapData;

    private bool IsPlacing = false;
    private Action CurrentCompletePlacementCallback;

    private bool IsBuildModeActive = false;
    public void SetBuildModeActive(bool active)
    {
        IsBuildModeActive = active;
    }    

    public void BeginPlacement(TrapObject trapData, Action CompletePlacementCallback)
    {
        if (GhostGO != null)
        {
            Destroy(GhostGO);
            GhostGO = null;
        }

        //Create ghost
        GhostGO = new GameObject(gameObject.name + "ghost");

        GameObject originalGameObjectPrefab = trapData.GetObjectPrefab();
        GhostGO.transform.position = originalGameObjectPrefab.transform.position;
        GhostGO.transform.localScale = originalGameObjectPrefab.transform.localScale;
        GhostGO.transform.rotation = originalGameObjectPrefab.transform.rotation;

        SpriteRenderer originalSpriteRenderer = originalGameObjectPrefab.GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer ghostRenderer = GhostGO.AddComponent<SpriteRenderer>();
        ghostRenderer.sprite = originalSpriteRenderer.sprite;
        ghostRenderer.material = originalSpriteRenderer.sharedMaterial;
        ghostRenderer.color = new Color(originalSpriteRenderer.color.r, originalSpriteRenderer.color.g, originalSpriteRenderer.color.b, 100f/255f);

        GhostGO.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GhostGO.transform.position = new Vector3(GhostGO.transform.position.x, GhostGO.transform.position.y, -1);

        if (GhostGO)
        {
            IsPlacing = true;
            CurrentPlacementTrapData = trapData;
            CurrentCompletePlacementCallback = CompletePlacementCallback;
        }
    }

    public void UpdatePlacement()
    {
        if (GhostGO != null && IsPlacing)
        {
            Vector3 WorldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 TargetCellCenterWorld = PlacementGrid.GetCellCenterWorld(PlacementGrid.WorldToCell(WorldMousePosition));
            Vector2Int trapDimensions = CurrentPlacementTrapData.GetTileDimensions();
            float xPos = TargetCellCenterWorld.x;
            float yPos = TargetCellCenterWorld.y;
            if (trapDimensions.x % 2 == 0)
            {
                xPos += (PlacementGrid.cellSize.x / 2);
            }
            if (trapDimensions.y % 2 == 0)
            {
                yPos += (PlacementGrid.cellSize.y / 2);
            }

            GhostGO.transform.position = new Vector3(xPos, yPos, -1);
        }
    }

    //TODO: Allow removal, Check for valid placement against trap block tilemap
    public void CompletePlacement()
    {
        if (CurrentPlacementTrapData && GhostGO != null && IsPlacing)
        {
            GameObject.Instantiate(CurrentPlacementTrapData.GetObjectPrefab(), GhostGO.transform.position, GhostGO.transform.rotation);
            if (CurrentCompletePlacementCallback != null)
                CurrentCompletePlacementCallback.Invoke();


            Destroy(GhostGO);
            GhostGO = null;
            CurrentPlacementTrapData = null;
            IsPlacing = false;
            CurrentCompletePlacementCallback = null;
        }
    }

    public void CancelPlacement()
    {
        if (CurrentPlacementTrapData && GhostGO != null && IsPlacing)
        {
            Destroy(GhostGO);
            GhostGO = null;
            CurrentPlacementTrapData = null;
            IsPlacing = false;
            CurrentCompletePlacementCallback = null;
        }
    }

    public void Update()
    {
        if (!IsBuildModeActive)
        {
            CancelPlacement();
            return;
        }

        UpdatePlacement();

        if (Input.GetMouseButton(0))
        {
            CompletePlacement();
        }
        if (Input.GetMouseButton(1))
        {
            CancelPlacement();
        }
    }
}
