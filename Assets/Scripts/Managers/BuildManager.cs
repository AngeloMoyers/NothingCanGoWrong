using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject BuildModeUI;
    [SerializeField] TrapPlacementManager TrapMan; 

    private BuildPanel BuildPanelScript;

    private bool IsBuildModeActive = false;
    public void SetBuildModeActive(bool active)
    {
        IsBuildModeActive = active;
        TrapMan.SetBuildModeActive(active);
        if (BuildModeUI != null )
        {
            BuildModeUI.SetActive(active);
        }
    }
}
