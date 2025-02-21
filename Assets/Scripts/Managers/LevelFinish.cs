using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    private CharacterLoopManager LoopMan;

    private void Awake()
    {
        LoopMan = GameObject.FindObjectOfType<CharacterLoopManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Character won!");
        
            LoopMan.CharacterWon();
        }
    }
}
