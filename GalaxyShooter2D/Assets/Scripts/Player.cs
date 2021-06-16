using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _TripleLaserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = 0.0f;
    private SpawnManager spawnManager;
    private bool _isTrippleShot = false;

    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        transform.position = new Vector3(0, 0, 0);
        if(spawnManager == null)
        {
            Debug.Log("failed to access Spawn Manager");
        }

    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)              // cool down method for shooting
        {
            FireLaser();
        }
       
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, VerticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 1), 0);

        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireRate;
        if (_isTrippleShot)
        {
            Instantiate(_TripleLaserPrefab, new Vector3(transform.position.x, transform.position.y , 0), Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.2f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        _lives -= 1;

        if(_lives == 0)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TrippleShotPowerupActive()
    {
        _isTrippleShot = true;
        StartCoroutine(TrippleShotPowerDownRoutine());
    }

    IEnumerator TrippleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTrippleShot = false;
    }
}
