using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [Header("Baloon Swap")]
    public Sprite[] sprites = new Sprite[3];
    [SerializeField]
    int spriteIndex = 0;

    [Header("Texts")]
    public Text point_text;
    public Text life_text;
    public Text time_text;
    public Text final_text_go;
    public Text final_text_tu;
    public Text highScGO;
    public Text highScTU;


    [Header("Particles")]
    public ParticleSystem enemy_particle;

    [Header("--------------")]
    [SerializeField]
    int speed = 5;
    [SerializeField]
    float point = 0;
    [SerializeField]
    float time = 50;
    public int playerLife = 3;


    int fruitPoint = 10;
    private bool checkForTime = true;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject timesUpPanel;


    public float highScore;

    [Header("Audio")]
    public AudioSource game_sound;
    public AudioSource baloon_hit;
    public AudioSource balloon_pop;
    public AudioSource game_over;
    public AudioSource timesUp;
    public AudioSource time_sound;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        timesUpPanel.SetActive(false);
        Time.timeScale = 1;
        spriteIndex = 0;
        playerLife = 3;
        this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        life_text.text = "Lives: " + playerLife.ToString();

        getHighScore();

        game_sound.Play();
    }


    private void getHighScore()
    {
        highScore = PlayerPrefs.GetFloat("Highscore");
        highScGO.text = "Highscore: " + highScore.ToString("0");
        highScTU.text = "Highscore: " + highScore.ToString("0");
    }

    private void Update()
    {
        getHighScore();

        if (checkForTime == false)
        {
            Time.timeScale = 0;
            final_text_tu.text = "Score: " + point.ToString("0");
            game_sound.Stop();
            timesUp.Play();
            timesUpPanel.SetActive(true);
        }

        time -= Time.deltaTime;

        point += Time.deltaTime;

        if(point > highScore)
        {
            PlayerPrefs.SetFloat("Highscore", point);
        }

        time_text.text = "Time: " + time.ToString("0") + "s";
        point_text.text = "Points: " + point.ToString("0");

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Controller();    
    }

    void Controller()
    {
        var movementH = Input.GetAxis("Horizontal");
        var movementV = Input.GetAxis("Vertical");
        transform.position += new Vector3(movementH, movementV, 0) * speed * Time.deltaTime;


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "fruit")
        {
            time += fruitPoint;
            time_sound.Play();
            Destroy(other.gameObject);
        }else if(other.gameObject.tag == "enemy")
        {
            balloon_pop.Play();
            spriteIndex++;
            enemy_particle.Play();
            
            if (playerLife > 1)
            {
                playerLife--;
                life_text.text = "Lives: " + playerLife.ToString();

                this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
                Destroy(other.gameObject);
            }
            else
            {
                playerLife--;
                life_text.text = "Lives: " + playerLife.ToString();

                final_text_go.text = "Score: " + point.ToString("0");
                game_sound.Stop();
                game_over.Play();
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;
                this.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "wall")
        {
            baloon_hit.Play();
        }

        void CheckTime()
        {
            if(time == 0)
            {
                checkForTime= false;
            }
            checkForTime = true;
        }

    }


}
