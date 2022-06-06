using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _fireDelay;
    [SerializeField] private Transform _bulletPrefub;
    [SerializeField] private LayerMask _enemyLayer;
     
    private float _timeToFire;
    private Transform _gun;
    private Transform _enemy;
    private Transform _firePoint;
    private Transform _gunPoint;


    private void Start()
    {
        _timeToFire = _fireDelay;
        _gun = transform.GetChild(0);
        _gunPoint = _gun.GetChild(0);
        _firePoint = _gunPoint.GetChild(0);
    }

    private void Update()
    {
        if (_timeToFire > 0)
        {
            _timeToFire-=Time.deltaTime;
            
        }
        else if (_enemy)
        {
            Fire();
        }

        if (_enemy)
        {
            var lookAt = _enemy.position;
            
            // на одном уровне
            lookAt.y = _gun.position.y;
            
            _gun.LookAt(lookAt);
            
            // подсчет дистанции
            if (Vector3.Distance(transform.position, _enemy.position) > _radius)
            {
                _enemy = null;
            }
        }
        else
        {
            // массив коллайдеров          // где находится башня, 
            var colls = Physics.OverlapSphere(transform.position, _radius, _enemyLayer);
            if (colls.Length > 0)
            {
                _enemy = colls[0].transform;
            }
        }
    }

    private void Fire()
    {
        // что где
        var bullet = Instantiate(_bulletPrefub, _firePoint.position, Quaternion.identity);
        
        bullet.LookAt(_enemy.GetChild(0));
        

        _timeToFire = _fireDelay;
        
    }
}
