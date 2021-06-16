using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float _PowerupSpeed = 3;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * _PowerupSpeed * Time.deltaTime);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.transform.GetComponent<Player>();
        if(player != null)
        {
            player.TrippleShotPowerupActive();
            Destroy(gameObject);
        }
    }
}
