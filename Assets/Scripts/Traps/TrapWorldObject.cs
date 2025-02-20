using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWorldObject : MonoBehaviour
{
    [SerializeField] TrapObject TrapData;
    Collider2D Trigger;

    private void Awake()
    {
        Trigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayerOverlap();
        }
    }

    protected virtual void OnPlayerOverlap() { }
}
