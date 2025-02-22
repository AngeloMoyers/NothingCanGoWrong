using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapBehavior : TrapWorldObject
{
    protected override void OnPlayerOverlap(GameObject player)
    {
        player.GetComponent<CharacterController>().Die();
    }
}
