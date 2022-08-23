using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;    // Start is called before the first frame update
    public float speed;

    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;

    void SetScoreText()
    {
        scoreText.text = score.ToString("Score: " + score);
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
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
            Debug.Log("You win!");
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
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
