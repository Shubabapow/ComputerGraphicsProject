using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{

    [SerializeField] Camera cam;

    public GameObject waitingToStart;
    public int start = 0;
    public ParticleSystem muzzleFlash;

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

        if(Input.GetMouseButtonDown(0) && start >= 1 && PauseMenu.GameIsPaused == false && PauseMenu.mGameOver == false){
            GameStats.totalShots += 1;
            muzzleFlash.Play();
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit)){

                Target target = hit.collider.gameObject.GetComponent<Target>();
                if(target != null){
                    target.Hit();
                    GameStats.targetsHit += 1;
                } 
            }

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
