using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randompos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
}
