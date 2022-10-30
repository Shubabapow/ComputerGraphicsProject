using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensDisplay : MonoBehaviour
{

    public Text mouseSensText;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseSensText.text = PlayerController.mouseSensitivity.ToString();
    }
}
