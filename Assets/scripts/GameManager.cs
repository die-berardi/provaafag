using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
  public int score;
  public static GameManager inst;

    public TextMeshProUGUI scoreText;
    public void IncrementScore(){
        score++;
        scoreText.text = "Score: " + score;
    }
  private void Awake(){
    inst = this;
  }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void IniziaGioco() {
    Time.timeScale = 1f; 
    SceneManager.LoadScene(1);
  }

  public void logout() {
    SceneManager.LoadScene(0);
  }

}
