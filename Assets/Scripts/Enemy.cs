using System;
using DefaultNamespace;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] public float Health;

    public Transform[] Points;
    
    private int _index;
    private Transform _currentPoint;
    private Vector3 _direction;
    private ResourceManager _manager;
   
    private void Start()
    {
        _index = 0;
        _currentPoint = Points[_index];
        _manager = FindObjectOfType<ResourceManager>();
    }

    private void Update()
    {
        _direction = _currentPoint.position - transform.position;

        // для постепенного поворота
        var newDirection = Vector3.RotateTowards(transform.forward, 
            _direction, // куда повернуться
            _rotationSpeed * Time.deltaTime, 
            0);
        //transform.rotation = Quaternion.LookRotation(_direction);
        // поворот в сторону newDirection
        transform.rotation = Quaternion.LookRotation(newDirection);
        
        // линейное движение MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, 
            _currentPoint.position, 
            _speed * Time.deltaTime);
 
        if (transform.position == _currentPoint.position)
        {
            _index++;
            
            if (_index >= Points.Length)
            {
                _manager.MissEnemy();
                Destroy(gameObject);
            }
            else
            {
                _currentPoint = Points[_index];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Health -= other.GetComponent<Bullet>().Damage;
            if (Health <= 0 )
            {
                Destroy(gameObject);
                _manager.EnemyKill();
            }
            Destroy(other.gameObject);
        }
    }
}
