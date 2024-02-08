using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        theRigidbody.velocity = (target.position - transform.position).normalized * moveSpeed;
    }
}
