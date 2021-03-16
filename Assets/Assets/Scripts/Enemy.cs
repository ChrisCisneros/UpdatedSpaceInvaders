using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject alienBullet;
    public Transform alien;
    public Game reference;
    ParticleSystem blast;

    float Killtimer = -1f;

    public float timer;

    private void Start()
    {
        //reference = GetComponent<Game>();
        timer = Random.Range(5f, 8f);
        alien = GetComponent<Transform>();
        blast = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = Random.Range(5f, 8f);
            if (Random.Range(0, 30) == 1)
                fire();
        }

        if(Killtimer > 0)
        {
            Killtimer -= Time.deltaTime;
        }

        if (Killtimer < 0 && Killtimer != -1)
        {
            Destroy(gameObject);
        }


    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        string variable = gameObject.tag.ToString();
        reference.updateScore(variable);
        Destroy(gameObject);
        reference.kill();
        if (gameObject.tag.ToString() == "Bullet")
        {
            
        }


        

    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        bool alien = false;
        
        if (collision.tag == "Bullet")
        {
            blast.Play();
            reference.updateScore(gameObject.tag);
            reference.kill();
            blast.Play();
            Killtimer = .5f;
            Destroy(collision.gameObject);
            reference.Hit.Play();
        }

        if (alien)
        {
            
            
        }
        alien = false;
    }

    

    void fire()
    {
        GameObject shot = Instantiate(alienBullet, alien.position, Quaternion.identity);
        //Debug.Log("Bang!");

        Destroy(shot, 6f);
    }
}
