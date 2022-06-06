using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int _gold;
    
    [SerializeField] private int _towerCost;
    
    [SerializeField] private int _enemyCost;
    
    [SerializeField] private int _lives;

    [SerializeField]  private GameObject _deadPanel;

    private void Start()
    {
        _deadPanel.SetActive(false);
    }

    public void MissEnemy()
    {
        _lives -= 1;
        if (_lives <= 0)
        {
            _deadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BuildTower()
    {
        _gold -= _towerCost;
    }
    
    public void EnemyKill()
    {
        _gold += _enemyCost;
    }
    
    public bool HaveResources()
    {
        return _gold >= _towerCost;
    }
}
