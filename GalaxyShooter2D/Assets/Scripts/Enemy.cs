using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4.0f;
    private Player _player;
    private int _scoreRange;
  
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    
        transform.position = new Vector3(0, 8, 0);

        _scoreRange = Random.Range(5, 13);
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
        

        if (other.transform.tag == "Player")
        {
            if(_player != null)
            {
                _player.Damage();
                Destroy(this.gameObject);
            }
            
        }
        else if (other.transform.tag == "Laser")
        {
            Destroy(other.gameObject);
            _player.AddScore(_scoreRange);
            Destroy(gameObject);
            
        }
    }

}
