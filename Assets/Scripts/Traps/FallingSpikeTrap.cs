using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikeTrap : TrapWorldObject
{
    [SerializeField] GameObject TriggerPrefab;
    Rigidbody2D rb;

    GameObject TriggerObject;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        TriggerObject = GameObject.Instantiate(TriggerPrefab, transform.position, Quaternion.identity);
        TriggerObject.GetComponent<FallingTrigger>().SetOwningTrap(this);
    }

    private void Update()
    {
        if (TriggerObject)
            TriggerObject.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterController>().Die();
        }
    }

    public override void Activate(Collider2D collider)
    {
        base.Activate(collider);

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = rb.gravityScale * 1.1f;
        //Fall
    }
}
