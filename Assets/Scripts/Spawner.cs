using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefub;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _timeToSpawn = 0.5f;
    [SerializeField] private int countEnemyLeft;
    [SerializeField] private float _waitTime = 10f;

    private float _timer;
    private int countEnemy;
    private float _waitTimeLeft;
    private int _iteration = 1;
    
    private void Start()
    {
        countEnemy = countEnemyLeft;
        _timer = _timeToSpawn;
        _waitTimeLeft = _waitTime;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0 && countEnemy > 0)
        {
            //          создаем объект   префаб,    позиция,           базовое вращение
            var enemy = Instantiate(_enemyPrefub, transform.position, Quaternion.identity);
            // моршрут
            enemy.Points = _points;
            // увеличиваем здоровье с каждой итерацией
            enemy.Health += _iteration;
            _timer = _timeToSpawn;
            countEnemy--;
        }
        else
        {
            _waitTimeLeft -= Time.deltaTime;
        }

        if (_waitTimeLeft < 0)
        {
            _iteration++;
            countEnemy = countEnemyLeft * _iteration;
            _timer = _timeToSpawn;
            _waitTimeLeft = _waitTime;
        }
    }
}
