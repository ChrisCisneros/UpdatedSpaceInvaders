using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    int health = 3;
    GameObject barrier;
    Renderer colorRender;

    [SerializeField] private Renderer set;
    
    // Start is called before the first frame update
    void Start()
    {
        colorRender = barrier.GetComponent<Renderer>();
        colorRender.material.SetColor("_Color", new Color(.6f, 0f, .9f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        hit();
    }

    public void hit()
    {
        health--;
        if (health == 2)
        {
            set.material.color = new Color(.6f, 0f, .8f);
        }
        else if (health == 1)
        {
            set.material.color = new Color(.3f, 0f, .6f);
        }
        else if (health == 0)
            Destroy(gameObject);
    }
}
