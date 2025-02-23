using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoopManager : MonoBehaviour
{
    [SerializeField] GameObject CharacterPrefab;
    Transform SpawnPoint;
    [SerializeField] BuildManager BuildMan;
    [SerializeField] UIManager UIMan;

    private GameObject Character;
    private CharacterController CharacterControl;

    bool IsPlaying = false;


    public void Reset()
    {
        if (Character)
        {
            Character.transform.position = SpawnPoint.position;
        }
        else
        {
            SpawnPoint = GameObject.FindObjectOfType<SpawnPoint>().transform;

            Character = GameObject.Instantiate(CharacterPrefab, SpawnPoint.transform.position, Quaternion.identity);
            CharacterControl = Character.GetComponent<CharacterController>();
        }
    }

    public void StopPlaying()
    {
        //enter build mode
        Reset();
        UIMan.CloseWinScreen();
        IsPlaying = false;
        if (CharacterControl != null)
        {
            CharacterControl.SetPlaying(IsPlaying);
        }
        if (BuildMan != null)
        {
            BuildMan.SetBuildModeActive(!IsPlaying);
        }
    }

    public void StartPlaying()
    {
        // do ai shit
        Reset();
        IsPlaying = true;
        if ( CharacterControl != null )
        {
            CharacterControl.SetPlaying(IsPlaying);
        }
        if (BuildMan != null)
        {
            BuildMan.SetBuildModeActive(!IsPlaying);
        }
    }

    public void TogglePlay()
    {
        if (IsPlaying)
            StopPlaying();
        else
            StartPlaying();
    }

    public void CharacterWon()
    {
        UIMan.ShowWinScreen();
        BuildMan.SetBuildModeActive(false);
        CharacterControl.SetPlaying(false);
    }    
}
