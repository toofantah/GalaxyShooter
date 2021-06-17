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
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {

                switch (_powerupID)
                {
                    case 0:
                        player.TrippleShotPowerupActive();
                        Destroy(gameObject);
                        break;
                    case 1:
                        player.SpeedPowerUpActive();
                        Destroy(gameObject);
                        break;
                    case 2:
                        player.ShieldPowerupActive();
                        Destroy(gameObject);
                        break;
                    default:
                        Debug.Log("No cases to pursue");
                        break;


                }


            }
        }
      
    }
}
