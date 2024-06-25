using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public GameObject deathMenu;
    public GameObject pauseMenu;

    public AudioSource music;

    public GameManager gameManager;
    public TextMeshProUGUI scoreText;

    private void FixedUpdate(){
        if(!alive) return;
        Vector3 forwardMove = -transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = -transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(transform.position.x < -30 || transform.position.x > 30){
            Die();
        }
    }

    public void Die(){
        alive = false;
        //Restart the game
        deathMenu.SetActive(true);
        Time.timeScale = 0;
        music.Stop();
        scoreText.text = "Your score:" + gameManager.score;




    //    Invoke("Restart", 0);
    }

    public void Restart()
{
    Time.timeScale = 1;
    deathMenu.SetActive(false);
    music.Play();

    
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

    public void pause () {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        music.Stop();
        // scoreText.text = "Your score:" + gameManager.score;
    }

    public void resume () {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        music.Play();
    }

     public void logout() {
    SceneManager.LoadScene(0);
  }

}
