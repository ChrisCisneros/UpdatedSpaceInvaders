using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float moveTimer = 3f;
    public float baseTime = 3f;
    public float secret = 10f;
    bool moveActive;

    bool secretActive = true;

    public GameObject startScreen;
    public GameObject gameScreen;
    public GameObject game;
    public GameObject enemies;
    public GameObject ship;

    int score = 100000000;
    int highscore = 100000000;
    public Text scoreText;
    public Text highText;
    public Text win;
    public Text lose;
    bool stop;

    int alive = 48;
    int sets = 0;

    public float shipTimer = .2f;

    //to track enemies movement
    public int movement = 0;
    public int position = 1;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        game.SetActive(false);
        gameScreen.SetActive(false);
        win.enabled = false;
        lose.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (secretActive)
        {
            secret -= Time.deltaTime;
        }

        if (secret < 0)
        {
            
            if(Random.Range(1, 6) == 5)
                secretActive = false;
            secret = 10f;
        }

        if (moveActive)
        {
            moveTimer -= Time.deltaTime;

        }

        if(secretActive == false)
        {
            shipTimer -= Time.deltaTime;

        }

        if(shipTimer < 0)
        {
            ship.transform.Translate(1f, 0, 0);
            sets++;
            if(sets == 70)
            {
                sets = 0;
                secretActive = true;
            }
            shipTimer = 1;
        }

        if (moveTimer < 0)
        {
            moveTimer = baseTime;

            if (enemies.transform.position.x > 16 && position == 1)
            {
                enemies.transform.Translate(0, -.5f, 0);
                position = -1;
            }
            else if (enemies.transform.position.x < -9 && position == -1)
            {
                enemies.transform.Translate(0, -.5f, 0);
                position = 1;
            }
            else if (position == -1)
            {
                enemies.transform.Translate(-.5f, 0, 0);
                
            }
            else
            {
                enemies.transform.Translate(.5f, 0, 0);
                
            }


            
        }

      

       


    }

    public void begin()
    {
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
        game.SetActive(true);
        moveActive = true;
    }
    public void updateScore(string enemy)
    {
        if (enemy.Equals("Small"))
            score += 10;
        if (enemy.Equals("Medium"))
            score += 20;
        if (enemy.Equals("Large"))
            score += 30;
        if (enemy.Equals("Secret"))
            score += Random.Range(100, 150);
        string amount = score.ToString();
        scoreText.text = amount.Substring(1, 8);
    }

    public void kill()
    {
        alive--;
        if (alive == 0)
        {

        }
        else if (alive % 10 == 0 && alive != 1)
        {
            baseTime -= .7f;
        }
        else if (alive == 1)
        {
            baseTime = .2f;
        }
        else if (alive == 0)
        {
            game.SetActive(false);
            win.enabled = true;
            stop = true;
            if(highscore < score)
            {
                string amount = score.ToString();
                highText.text = amount.Substring(1, 8);
            }
        }
    }

    void activate()
    {

    }

    public void gameOver()
    {
        stop = true;
        game.SetActive(false);
        
        lose.enabled = true;
        if (highscore < score)
        {
            string amount = score.ToString();
            highText.text = amount.Substring(1, 8);
        }
    }

}
