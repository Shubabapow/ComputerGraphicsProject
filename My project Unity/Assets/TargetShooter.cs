using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{

    [SerializeField] Camera cam;
    public int targetCount;
    public int clickCount;
    public static float hitPercentage;

    void Update(){

        if(Input.GetMouseButtonDown(0)){
            clickCount ++;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit)){

                Target target = hit.collider.gameObject.GetComponent<Target>();
                if(target != null){
                    //Destroy(target.gameObject);
                    target.Hit();
                    targetCount ++;
                } 
            }


       hitPercentage = targetCount/clickCount;
        Debug.Log("hit %");
        Debug.Log(hitPercentage);
        Debug.Log("target count");
        Debug.Log(targetCount);
        }
    }
//     public static int targetCounter{
//         get{return targetCounter;}
//     }
//     public static int targetHitPercent{
//         get{return hitPercentage;}
//     }
}
