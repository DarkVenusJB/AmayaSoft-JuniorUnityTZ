using Assets.Scripts.DataScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnerFactory : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _cells = new List<GameObject>();
        
        public IEnumerator CreateGrid(GridData _gridData)
        {
            GameObject _cellPrefab = _gridData.CellObject;
            int _gridRows = _gridData.GridRows;
            int _gridColumns = _gridData.GridColumns;
            float _spawnDelay = _gridData.Delay;

            Vector3 _cellScaleMultiplayer = _cellPrefab.transform.localScale;

            for (int i = _gridRows - 1; i < _gridData.GridRows; i++)
            {
                for (int j = 0; j < _gridData.GridColumns; j++)
                {
                    var _cell = Instantiate(_cellPrefab, new Vector3(transform.position.x + (j * _cellScaleMultiplayer.x), transform.position.y + (i * _cellScaleMultiplayer.y), 0), Quaternion.identity);
                    _cell.transform.parent = this.transform;
                    _cells.Add(_cell);
                    yield return new WaitForSeconds(_spawnDelay);
                }
            }
            Debug.Log(_cells.Count);
            CheckNextYPosition(_gridData);
        }

        private void CheckNextYPosition(GridData _gridData)
        {
            if (_gridData.GridRows > 1)
            {
                transform.position = new Vector3(transform.position.x, -_gridData.GridRows + 1, transform.position.z);
            }
        }

        public void CreateSymbol()
        {
            throw new System.NotImplementedException();
        }
    }
}