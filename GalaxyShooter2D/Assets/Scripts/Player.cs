using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _score;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _TripleLaserPrefab;
    [SerializeField]
    private GameObject _ShieldVisualPrefab;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _nextFire = 0.0f;
    [SerializeField]
    private float _SpeedMultiplier = 2.0f;
    private SpawnManager spawnManager;
    private UIManager _uIManager;
    private bool _isTrippleShot = false;
    private bool _isSheildActive = false;


    void Start()
    {
        
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        transform.position = new Vector3(0, 0, 0);
        if(spawnManager == null)
        {
            Debug.Log("failed to access Spawn Manager");
        }

        if(_uIManager == null)
        {
            Debug.Log("UIManager is null");
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
        if (_isSheildActive == false)
        {
            _lives --;
            
        } else
        {
            _isSheildActive = false;
            _ShieldVisualPrefab.SetActive(false);
        }
        _uIManager.UpdateSprites(_lives);
        if (_lives < 1)
        {
            spawnManager.OnPlayerDeath();
            _uIManager.GameOver();
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

    public void SpeedPowerUpActive()
    {
        _speed = _speed * _SpeedMultiplier;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _SpeedMultiplier;
    }

    public void ShieldPowerupActive()
    {
        _isSheildActive = true;
        _ShieldVisualPrefab.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }

    IEnumerator ShieldPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSheildActive = false;
        _ShieldVisualPrefab.SetActive(false);
    }

    public void AddScore(int points)
    {
        _score += points;
        _uIManager.UpdateScore(_score);
    }


}
