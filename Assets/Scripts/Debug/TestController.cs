using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] BuildPanel BuildPanelObject;
    [SerializeField] TrapObject TestTrapData;
    [SerializeField] TrapPlacementManager TrapManager;
    [SerializeField] CharacterLoopManager LoopMan;
    CharacterController Char;

    private void Awake()
    {
    }
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            LoopMan.StartPlaying();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoopMan.StopPlaying();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoopMan.Reset();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Char = GameObject.FindObjectOfType<CharacterController>();

            Char.TestDash();
        }
    }
}
