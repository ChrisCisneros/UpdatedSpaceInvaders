using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
    public GameObject player;
    public Game reference;
    public Animator blast;
    public ParticleSystem dead;

  public Transform shottingOffset;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            //Debug.Log("Bang!");
            GetComponent<ParticleSystem>().Play();
            reference.Fire.Play();

            Destroy(shot, 6f);

      }
      
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-.05f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(.05f, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        reference.gameOver();
        Destroy(gameObject);
    }
}
