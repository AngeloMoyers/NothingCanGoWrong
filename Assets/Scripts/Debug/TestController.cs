using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] BuildPanel BuildPanelObject;
    [SerializeField] TrapObject TestTrapData;
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
    }
}
