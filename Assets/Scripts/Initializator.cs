using Assets.Scripts;
using Assets.Scripts.DataScripts;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private GridData[] _cellsData;
    [SerializeField] private SpawnerFactory _spawnerFactory;

    private int _levelIndex = 0;

    private void Start()
    {
       InitializeLevel();
    }

    private void InitializeLevel()
    {
        if (_spawnerFactory != null)
        {
            _spawnerFactory.StartCoroutine(_spawnerFactory.CreateGrid(_cellsData[_levelIndex]));
            _levelIndex++;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            InitializeLevel();
        }
    }
}
