using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{

    public string theName;
    public GameObject inputField;

void Start(){
   theName = PlayerController.playerName;
   //inputField = PlayerController.playerName;
}

  public void SaveName(){
    theName = inputField.GetComponent<Text>().text;
    PlayerController.playerName = theName;
  }
}
