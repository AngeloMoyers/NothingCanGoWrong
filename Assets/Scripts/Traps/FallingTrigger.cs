using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    TrapWorldObject OwningTrap;

    public void SetOwningTrap(TrapWorldObject owner) { OwningTrap = owner; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterController>().OnTrapTriggerEnter(OwningTrap.GetTrapType());
            OwningTrap.Activate(collision);
        }
    }
}
