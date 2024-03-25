using Assets.Scripts.DataScripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnerFactory : MonoBehaviour, ISpawnerFactory
    {
        public void CreateGrid(GridData _gridData, GameObject _cellPrefab)
        {
            Vector3 _cellScaleMultiplayer = _cellPrefab.transform.localScale;

            for(int i = 0; i < _gridData.GridRows; i++)
            {
                for(int j = 0; j < _gridData.GridColumns; j++)
                {
                   var _cell = Instantiate(_cellPrefab, new Vector3(transform.position.x+(j*_cellScaleMultiplayer.x), transform.position.y+(i * _cellScaleMultiplayer.y), 0), Quaternion.identity);
                   _cell.transform.parent = this.transform;
                }

                transform.position = new Vector3(transform.position.x,-i ,transform.position.z); // -i необходим для того, чтобы сетка всегда оставалась по центру экрана
            }
        }

        public void CreateSymbol()
        {
            throw new System.NotImplementedException();
        }
    }
}