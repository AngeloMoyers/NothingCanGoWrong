using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    CharacterController CharController;

    private void Awake()
    {
        CharController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        CharController.SetMoveInput(new Vector2(1, 0));
    }
    void Update()
    {
        
    }
}
