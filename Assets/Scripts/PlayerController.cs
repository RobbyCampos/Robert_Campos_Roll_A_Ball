using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour {

    public float speed;

    public Text countText;
    public Text livesText;
    public Text winText;
    public Text gameOverText;
     
    private Rigidbody rb;

    public int lives;
    public int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        lives = 3;
        SetLivesText ();
        winText.text = "";
        gameOverText.text = "";
    }

    private void Update()
    {
        SetCountText();
        SetLivesText();

        if (count == 14)
        {
            winText.text = "You Win!";
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }

        if (lives == -1)
        {
            gameOverText.text = "You Lose!";
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            rb.detectCollisions = false;
        }
    }

    public void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString ();
    }

}
