using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4.0f;
  
    void Start()
    {
    
        transform.position = new Vector3(0, 8, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        
        if (transform.position.y < -5)
        {
            float xSpawnPoint = Random.Range(-10f, 10f);
            transform.position = new Vector3(xSpawnPoint, 8, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
