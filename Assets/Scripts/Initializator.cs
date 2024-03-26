using Assets.Scripts;
using Assets.Scripts.DataScripts;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private GridData[] _cellsData;
    [SerializeField] private SpawnerFactory _spawnerFactory;
    [SerializeField] private ElementBundleData _elementBundleData;

    private int _startLevelIndex;
    private int _levelIndex = 0;

    private void Awake()
    {
        _startLevelIndex = _levelIndex;
    }
    private void Start()
    {
       InitializeLevel();
    }

    private void InitializeLevel()
    {
        if (_spawnerFactory != null)
        {
            _spawnerFactory.StartCoroutine(_spawnerFactory.CreateGrid(_cellsData[_levelIndex],_elementBundleData));
            _levelIndex++;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            if (_levelIndex < _cellsData.Length)
            {
                InitializeLevel();
            }            
        }

        if (Input.GetKeyDown(KeyCode.C) )
        {           
            _spawnerFactory.ClearGrid();
            _levelIndex = _startLevelIndex;                 
        }      
    }
}
