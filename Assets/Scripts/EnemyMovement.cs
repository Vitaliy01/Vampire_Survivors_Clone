using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed, damage;
    private Transform target;

    public float hitWaitTime = 0.5f;
    private float hitCounter;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;

        moveSpeed = Random.Range(moveSpeed * 0.8f, moveSpeed * 1.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theRigidbody.velocity = (target.position - transform.position).normalized * moveSpeed;

        if(hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(PlayerHealth.instance.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealth.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }
    }
}
