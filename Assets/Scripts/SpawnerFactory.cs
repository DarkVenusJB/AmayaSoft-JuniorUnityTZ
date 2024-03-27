using Assets.Scripts.DataScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnerFactory : MonoBehaviour
    {
         private ElementCreator _creator;

        private Vector3 _defaultSpawnerPosition= new Vector3(-2f,0f,0f);
        private readonly List<GameObject> _cells = new List<GameObject>();

        public IEnumerator CreateGrid(GridData _gridData, ElementBundleData bundleData)
        {
            GameObject _cellPrefab = _gridData.CellObject;
            _creator = _cellPrefab.GetComponent<ElementCreator>();

            int _gridRows = _gridData.GridRows;
            int _gridColumns = _gridData.GridColumns;
            float _spawnDelay = _gridData.Delay;

            ClearGrid();
            _creator.ClearSpritesIndexList();           

            Vector3 _cellScaleMultiplayer = _cellPrefab.transform.localScale;

            for (int i =0 ; i < _gridRows; i++)
            {
                CheckNextYPosition(_gridData);
                for (int j = 0; j < _gridColumns; j++)
                {
                    var _cell = Instantiate(_cellPrefab, new Vector3(transform.position.x + (j * _cellScaleMultiplayer.x), transform.position.y + (i * _cellScaleMultiplayer.y), 0), Quaternion.identity);
                    _cell.transform.parent = this.transform;

                    _cells.Add(_cell);
                    _creator.CreateElement(bundleData, _cell.transform);

                    if( _gridData.Delay>0)
                        yield return new WaitForSeconds(_spawnDelay);
                    else
                        yield return null;
                }
            }           
        }

        private void CheckNextYPosition(GridData _gridData)
        {
            if (_gridData.GridRows > 1)
            {
                transform.position = new Vector3(transform.position.x, -_gridData.GridRows + 1, transform.position.z);
            }

            else if (_gridData.GridRows == 1)
            {
                transform.position = _defaultSpawnerPosition;
            }
        }

        public void ClearGrid()
        {
            foreach (var cell in _cells)
            {
                cell.gameObject.SetActive(false);
                Destroy(cell,2f);

            }
            _cells.Clear();
            
        }       
    }
}