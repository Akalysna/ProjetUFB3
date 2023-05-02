using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mud : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){ // Change la vitesse de déplacement
            GameObject.Find("PF Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().isMud = true;
    }
    private void OnTriggerExit2D(Collider2D other){// Change la vitesse de déplacement
            GameObject.Find("PF Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().isMud = false;
    }
}
