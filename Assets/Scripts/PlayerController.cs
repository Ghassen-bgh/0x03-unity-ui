using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;    // Start is called before the first frame update
    public float speed;

    private int score = 0;
    public int health = 5;
    public Text scoreText, healthText, winloseText;
    public Image winloseBG;
    void SetScoreText()
    {
        scoreText.text = score.ToString("Score: " + score);
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    void win()
    {
        winloseBG.gameObject.SetActive(true);
        winloseText.text = "You Win!";
        winloseBG.color = Color.green;
        winloseText.color = Color.black;
        StartCoroutine(LoadScene(3));
    }

    void lose()
    {
        winloseBG.gameObject.SetActive(true);
        winloseText.text = "Game Over!";
        winloseBG.color = Color.red;
        winloseText.color = Color.white;
        StartCoroutine(LoadScene(3));
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            win();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    
    }
        IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Maze");
    }
    void Update()
    {
        if (health == 0)
        {
            lose();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
