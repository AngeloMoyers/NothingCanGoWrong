using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject BuildModeUI;
    [SerializeField] TrapPlacementManager TrapMan;
    [SerializeField] BuildPanel BuildPan;

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

    public void SetBuildPanelShowing(bool show)
    {
        BuildModeUI.SetActive(show);
    }

    private void Start()
    {
        
    }

    public void LoadLevelData(LevelData data)
    {
        for (int i = 0; i < data.GetTrapsAvailable().Count; i++)
        {
            for (int j = 0; j < data.GetTrapsAvailable()[i].Count; j++)
            {
                BuildPan.AddTrapPanel(data.GetTrapsAvailable()[i].Trap);
            }
        }
    }

    public void BeginLevel()
    {
        TrapMan.BeginLevel();
    }
}
