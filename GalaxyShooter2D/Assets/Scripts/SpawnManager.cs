using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _TrippleShotPrefab;
    [SerializeField]
    private GameObject _speedPowerupPrefab;
    [SerializeField]
    private GameObject _enemayContainer;
    private bool _stopSpawning = false;
    


    void Start()
    {
       
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnTrippleShotRoutine());
        StartCoroutine(SpawnSpeedPowerupRoutine());
    }


    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn;
            posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemayContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnTrippleShotRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn;
            posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_TrippleShotPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));
        }
      
    }

    IEnumerator SpawnSpeedPowerupRoutine()
    {
      while(_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_speedPowerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }
    }


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
