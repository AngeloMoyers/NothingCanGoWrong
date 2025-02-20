using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] BuildPanel BuildPanelObject;
    [SerializeField] TrapObject TestTrapData;
    [SerializeField] TrapPlacementManager TrapManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BuildPanelObject.AddTrapPanel(TestTrapData);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            BuildPanelObject.RemoveTrap(TestTrapData);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TrapManager.BeginPlacement(TestTrapData, null);
        }
    }
}
