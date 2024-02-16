using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D theRigidbody;
    public float moveSpeed, damage;
    private GameObject player;
    private Transform target;

    public float hitWaitTime = 0.5f;
    private float hitCounter;

    public float health = 10f;

    public float knockBackTime = 0.5f;
    private float knockBackCounter;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.GetComponent<Transform>();
        }

        moveSpeed = Random.Range(moveSpeed * 0.8f, moveSpeed * 1.2f);
    }

    private void Update()
    {
        if(knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if(moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 2f;
            }

            if(knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
            }
        }
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
        var player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player)
        {
            player.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }

        /*if (PlayerHealth.instance.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealth.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }*/
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);

        if (shouldKnockBack)
        {
            knockBackCounter = knockBackTime;
        }
    }
}
