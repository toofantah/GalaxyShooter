using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _PowerupSpeed = 3;
    [SerializeField]
    private int _powerupID;
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
            if(_powerupID == 0)
            {
                player.TrippleShotPowerupActive();
                Destroy(gameObject);
            }else if (_powerupID == 1)
            {
                player.SpeedPowerUpActive();
                Destroy(gameObject);
            }else if (_powerupID == 2)
            {
                player.ShieldPowerupActive();
                Destroy(gameObject);
            }
            
           
        } 
    }
}
