using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject BuildModeUI;
    [SerializeField] TrapPlacementManager TrapMan;
    [SerializeField] BuildPanel BuildPan;
    [SerializeField] LevelData LevelStartInfo;

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

    private void Start()
    {
        for (int i = 0; i < LevelStartInfo.GetTrapsAvailable().Count; i++)
        {
            for (int j = 0; j < LevelStartInfo.GetTrapsAvailable()[i].Count; j++)
            {
                BuildPan.AddTrapPanel(LevelStartInfo.GetTrapsAvailable()[i].Trap);
            }
        }
    }
}
