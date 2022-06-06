using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] public float Damage = 1f;

        private void Start()
        {
            Destroy(gameObject,2);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward *_speed * Time.deltaTime);
        }
    }
}