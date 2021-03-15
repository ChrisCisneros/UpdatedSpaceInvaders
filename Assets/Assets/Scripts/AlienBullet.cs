using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class AlienBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    Collider bullet;

    public Barrier reference;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        reference = GetComponent<Barrier>();
        bullet = GetComponent<Collider>();
        Fire();
        

    }
    private void Update()
    {
        if (bullet.transform.position.y < -4)
        {
            bullet.enabled = true;
            Debug.Log("Activated");
        }
    }

    // Update is called once per frame
    private void Fire()
    { 
        myRigidbody2D.velocity = Vector2.down * speed;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            Destroy(gameObject);
        }

        if (collision.tag == "Barrier")
        {
            Destroy(gameObject);
            reference.hit();
            Debug.Log("hit");
            
        }
    }

}