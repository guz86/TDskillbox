using UnityEngine;

public class Сell : MonoBehaviour
{
    [SerializeField] private Material _mainMaterial;
    [SerializeField] private Material _canMaterial;
    [SerializeField] private Material _canNotMaterial;
    [SerializeField] bool _canBuild;
    [SerializeField] GameObject _towerPrefub;

    private Renderer _renderer;
    private ResourceManager _manager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _manager = FindObjectOfType<ResourceManager>();
    }

    private void OnMouseOver()
    {
        if (_canBuild)
        {
            _renderer.material = _canMaterial;
        }
        else
        {
            _renderer.material = _canNotMaterial;
        }
    }
    
    private void OnMouseUp()
    {
        if (_canBuild && _manager.HaveResources())
        {
            Instantiate(_towerPrefub, 
                transform.position, 
                Quaternion.Euler(0,Random.Range(0, 360),0));
            _canBuild = false;
            _manager.BuildTower();
        }
    }
    
    private void OnMouseExit()
    {
        // возвращаем материал при отводе мышки от ячейки
        _renderer.material = _mainMaterial;
    }
}
