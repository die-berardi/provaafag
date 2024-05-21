using UnityEngine;
using UnityEngine.SceneManagement;



public class TouchMovement : MonoBehaviour
{

    private Touch touch;
    
    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    private void FixedUpdate(){

        if(!alive) return;

        if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Stationary ){
                Vector3 forwardMove = -transform.forward * speed * Time.fixedDeltaTime;
                Vector3 horizontalMove = -transform.right * (1) * speed * Time.fixedDeltaTime * horizontalMultiplier;
                if(touch.position.x > (Screen.width/2)+((Screen.width/3)/2)){
                     horizontalMove = -transform.right * (1) * speed * Time.fixedDeltaTime * horizontalMultiplier;
                }
                if(touch.position.x < (Screen.width/2)-((Screen.width/3)/2)){
                     horizontalMove = -transform.right * (-1) * speed * Time.fixedDeltaTime * horizontalMultiplier;
                }
                rb.MovePosition(rb.position  + horizontalMove);
            }
            if(touch.phase == TouchPhase.Moved){
                Vector3 forwardMove = -transform.forward * speed * Time.fixedDeltaTime;
                Vector3 horizontalMove =  -transform.right * (1) * speed * Time.fixedDeltaTime * horizontalMultiplier;
                if(touch.position.x > (Screen.width/2)+((Screen.width/3)/2)){
                    horizontalMove = -transform.right * (1) * speed * Time.fixedDeltaTime * horizontalMultiplier;
                }
                if(touch.position.x < (Screen.width/2)-((Screen.width/3)/2)){
                    horizontalMove = -transform.right * (-1) * speed * Time.fixedDeltaTime * horizontalMultiplier;
                }
                rb.MovePosition(rb.position  + horizontalMove);
            }
        }

        // if(!alive) return;
        // Vector3 forwardMove = -transform.forward * speed * Time.fixedDeltaTime;
        // Vector3 horizontalMove = -transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        
        // rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // // Update is called once per frame
    // private void Update()
    // {
    //     horizontalInput = Input.GetAxis("Horizontal");
    //     if(transform.position.x < -30 || transform.position.x > 30){
    //         Die();
    //     }
    // }

    // public void Die(){
    //     alive = false;
    //     //Restart the game
    //    Invoke("Restart", 1);
    // }

    // void Restart()
// {
//      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
// }
}
