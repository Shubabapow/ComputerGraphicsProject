using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    public static float targetsHit;
    public static float totalShots;
    public static float accuracy;
    public Text score;
    public Text percentage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Targets Shot: " + targetsHit.ToString();
        accuracy = targetsHit/totalShots*100;
        percentage.text = "Accuracy: " + accuracy.ToString("F2") + "%";
    }
}
