using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public bool boostMoveSpeed = false;
        public bool isMud = false;
        public float endMoveSpeedBoost;
        private int boostMoveSpeedPower = 10; // Puissance du boost de MS
        private Animator animator;
        public static bool gameIsPaused;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }



        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.Q) | Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D ) | Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.Z )| Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S )| Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            if(Input.GetKeyDown(KeyCode.Escape)){
                gameIsPaused = !gameIsPaused;
                if(GameObject.Find("Pause").GetComponent<Text>().text == ""){
                    GameObject.Find("Pause").GetComponent<Text>().text = "PAUSE";
                }
                else{
                    GameObject.Find("Pause").GetComponent<Text>().text = "";
                };
                PauseGame();
            }

            void PauseGame ()
            {
                if(gameIsPaused)
                {
                    Time.timeScale = 0f;
                }
                else 
                {
                    Time.timeScale = 1;
                }
            }


            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);


            // CHECK BOOST MS
            if (boostMoveSpeed && !isMud){
                speed = boostMoveSpeedPower;
            }

            // BOOST MS 
            if(Time.time > endMoveSpeedBoost){
                    boostMoveSpeed = false;
            }
            // BASE SPEED
            if((!boostMoveSpeed && !isMud) || (boostMoveSpeed && isMud)){
                speed = 3;
            }
            // SLOW MS
            if(!boostMoveSpeed && isMud){
                speed = 1;
            }
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
