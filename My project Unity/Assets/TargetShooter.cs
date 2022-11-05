using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{

    [SerializeField] Camera cam;
    public static int targetCount;
    public static int clickCount;
    public static float hitPercentage;

    public GameObject waitingToStart;
    public int start = 0;

    PlayerController controller = new PlayerController();

    void Update(){

        
        if(Input.GetKeyDown(KeyCode.Space)){
            start = 1;
        } 
        if(start == 1){
            GameStart();
            start = 2;
        }else if(start == 0){
            GameWaiting();
        }

        if(Input.GetMouseButtonDown(0) && start >= 1){
            clickCount ++;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit)){

                Target target = hit.collider.gameObject.GetComponent<Target>();
                if(target != null){
                    target.Hit();
                    targetCount ++;
                } 
            }


       hitPercentage = targetCount/clickCount;
        //Debug.Log("hit %");
        //Debug.Log(hitPercentage);
       // Debug.Log("target count");
       // Debug.Log(targetCount);
        }
    }

        public void GameWaiting(){
            Time.timeScale = 0f;
            waitingToStart.SetActive(true);
            PlayerController.pause = true;
        }

        public void GameStart(){
            Time.timeScale = 1f;
            waitingToStart.SetActive(false);
            PlayerController.pause = false;
        }
}
