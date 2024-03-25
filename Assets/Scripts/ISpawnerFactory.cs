using Assets.Scripts.DataScripts;
using UnityEngine;

namespace Assets.Scripts
{
    public interface ISpawnerFactory
    {
        public void CreateGrid(GridData gridData, GameObject cellPrefab);

        public void CreateSymbol();

    }
}
