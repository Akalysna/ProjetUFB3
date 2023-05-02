using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollider : MonoBehaviour
{
    public float boostMoveSpeedDuration = 5.0f;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Gold")){ // Ramasse une pièce et met à jour le compteur
            Score.goldAmount += 1;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("SilverKey")){ // Ramasse une clef et met à jour le compteur
            Score.silverKey += 1;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("ClosedDoor")){ // Ouvre la porte si on a une clef
            if(Score.silverKey >= 1){
                Score.silverKey --;
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                other.gameObject.transform.gameObject.tag = "OpenedDoor";
            }
        }
        else if(other.gameObject.CompareTag("UpSpeed")){ // Change la vitesse de déplacement
            Destroy(other.gameObject);
            GameObject.Find("PF Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().boostMoveSpeed = true;
            GameObject.Find("PF Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().endMoveSpeedBoost = Time.time + boostMoveSpeedDuration;
        }
    }
}
