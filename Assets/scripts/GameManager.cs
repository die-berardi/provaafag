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
        scoreText.text = "ITEMS: " + score;
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
    SceneManager.LoadScene(0);
  }
}
