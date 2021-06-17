using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float _BGSpeed = 3.0f;
    

    void Start()
    {
     
    }

    void Update()
    {
        RespawnfromTop();
        transform.Translate(Vector3.down * _BGSpeed * Time.deltaTime);
    }

    void RespawnfromTop()
    {
        if(transform.position.y < -13)
        {
            transform.position = new Vector3(transform.position.x, 19.3f, 0);
        }
    }
}
