using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWorldObject : MonoBehaviour
{
    [SerializeField] TrapObject TrapData;
    Collider2D Trigger;

    public TrapType GetTrapType() { return TrapData.GetTrapType(); }

    private void Awake()
    {
        Trigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayerOverlap(collision.gameObject);
        }
    }

    protected virtual void OnPlayerOverlap(GameObject player)  
    {

    }

    public virtual void Activate(Collider2D collider)
    { }
}
