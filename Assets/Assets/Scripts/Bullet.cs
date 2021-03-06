using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;
    public Barrier reference;
    public Game gReference;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        reference = GetComponent<Barrier>();
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed; 
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrier")
        {
            Debug.Log("Hit");
            reference.hit();
            Destroy(gameObject);


        }
        if (collision.tag == "Small" || collision.tag == "Medium" || collision.tag == "Large")
        {
            GetComponent<ParticleSystem>().Play();
        }
        
    }

}
