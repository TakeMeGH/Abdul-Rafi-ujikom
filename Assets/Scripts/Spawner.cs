using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _intervalTime;
    [SerializeField] GameObject[] _enemies;
    [SerializeField] Transform _leftBound;
    [SerializeField] Transform _rightBound;
    [SerializeField] VoidEventChannel _onGameFinished;
    float _currentTime = 0;
    bool stopSpawn = false;

    private void OnEnable()
    {
        _onGameFinished.OnEventRaised += StopSpawn;
    }

    private void OnDisable()
    {
        _onGameFinished.OnEventRaised -= StopSpawn;

    }

    private void Update()
    {
        if(stopSpawn) return;
        _currentTime += Time.deltaTime;
        if (_currentTime >= _intervalTime)
        {
            _currentTime = 0;
            SpawnEnemy();

        }
    }

    void SpawnEnemy()
    {
        Vector3 position = GetRandomPos();
        int randomEnemy = Random.Range(0, _enemies.Length - 1);
        Instantiate(_enemies[randomEnemy], position, _leftBound.rotation);
    }

    Vector3 GetRandomPos()
    {
        Vector3 pos = new Vector3(Random.Range(_leftBound.position.x, _rightBound.position.x), 0, _leftBound.position.z);
        return pos;
    }

    void StopSpawn()
    {
        stopSpawn = true;
    }


}
