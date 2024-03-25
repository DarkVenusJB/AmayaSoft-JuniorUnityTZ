using UnityEngine;

namespace Assets.Scripts.DataScripts
{
    [CreateAssetMenu(fileName = "NewGridData", menuName = "Data/GridData", order = 0)]
    public class GridData : ScriptableObject
    {
        [SerializeField] private int _gridRows;
        [SerializeField] private int _gridColumns;
        [SerializeField] private float xOffset;
        [SerializeField] private float yOffset;

        [SerializeField] private GameObject _gridObject;

        public int GridRows => _gridRows;
        public int GridColumns => _gridColumns;
        public float XOffset => xOffset;
        public float YOffset => yOffset;

        public GameObject GridObject
        {
            get
            {
                if (_gridObject == null)
                {
                    throw new System.Exception("GridObject is null");
                }

                else
                {
                    return _gridObject;
                }
            }
        }
    }
}

