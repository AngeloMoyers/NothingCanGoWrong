using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapBehavior : TrapWorldObject
{
    protected override void OnPlayerOverlap(GameObject player)
    {
        player.GetComponent<CharacterController>().OnTrapTriggerEnter(GetTrapType());
        player.GetComponent<CharacterController>().Die();
    }
}
