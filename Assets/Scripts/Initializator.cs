using Assets.Scripts;
using Assets.Scripts.DataScripts;
using UnityEngine;
using Zenject;

public class Initializator : MonoBehaviour
{
    [SerializeField] private GridData[] _cellsData;
    [SerializeField] private ElementBundleData[] _elementsBundleData;

    private SpawnerFactory _spawnerFactory;
    private int _startLevelIndex;
    private int _levelIndex = 0;

    public ElementBundleData currentElementData { get; private set; }

    [Inject]
    private void Construct(SpawnerFactory spawner)
    {
        _spawnerFactory = spawner;
    }

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
            _spawnerFactory.StartCoroutine(_spawnerFactory.CreateGrid(_cellsData[_levelIndex], SetRandomElementData()));
            _levelIndex++;
        }
    }

    private ElementBundleData SetRandomElementData()
    {
        int index = Random.Range(0,_elementsBundleData.Length);
        currentElementData = _elementsBundleData[index];
        return _elementsBundleData[index];
    }

    //DebugLogic
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
