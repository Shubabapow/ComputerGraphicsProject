using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform cameraHolder;
    public static string playerName;
    public static float mouseSensitivity = 1;
    float verticalLookRotation;
    public static bool pause = false;

    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
         //Debug.Log(pause);
        if(pause == false){
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
            verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        }
            // transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
            // verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            // verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            // cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }
}
