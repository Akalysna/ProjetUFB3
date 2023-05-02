using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public static int goldAmount = 0;
    public static int silverKey = 0;
    Text scoreText;
    Text keyText;
    void Start(){
        scoreText = GameObject.Find("GoldsText").GetComponent<Text>();
        keyText = GameObject.Find("KeysText").GetComponent<Text>();
    }

    void Update(){
        scoreText.text = goldAmount.ToString();
        keyText.text = silverKey.ToString();
    }

}   