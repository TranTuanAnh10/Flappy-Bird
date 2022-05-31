using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class BirdMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpForce = 7;
    private bool levelStart = false;
    public GameObject gameController;
    public GameObject message;
    public GameObject gameOver;
    public GameObject Pipe;
    private int point = 0;
    public Text pointText;
    public AudioSource wing;
    public AudioSource audioDie;
    public AudioSource audioPoin;
    private bool checkGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        gameOver.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (levelStart == false)
                {
                    levelStart = true;
                    rb.gravityScale = 3;
                    gameController.GetComponent<PipeGenerator>().enanelPipe = true;
                    Destroy(message);
                    wing.Play();
                    BirdMove();
                }
                else
                {
                    wing.Play();
                    BirdMove();
                }
            }
        }
        
    }
    private void BirdMove()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Die");
        audioDie.Play();
        Invoke(nameof(ReloadLevel), 1.3f);
        checkGameOver = true;
        rb.gravityScale = 0;
        gameOver.GetComponent<SpriteRenderer>().enabled = true;
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        point++;
        pointText.text = point.ToString();
        audioPoin.Play();
        Debug.Log("+1");
    }
}
