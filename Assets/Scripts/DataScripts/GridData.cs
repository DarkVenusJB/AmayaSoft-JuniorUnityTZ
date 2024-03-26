using UnityEngine;

namespace Assets.Scripts.DataScripts
{
    [CreateAssetMenu(fileName = "NewGridData", menuName = "Data/GridData", order = 0)]
    public class GridData : ScriptableObject
    {
        [Header("Grid Parametres:")]
        [SerializeField] private int _gridRows;
        [SerializeField] private int _gridColumns;
        [Header("Animation dalay:")]
        [SerializeField][Min(0f)] private float _delay;
        [Header("Object:")]
        [SerializeField] private GameObject _cellObject;

        public int GridRows => _gridRows;
        public int GridColumns => _gridColumns;
        public float Delay => _delay;   
       
        public GameObject CellObject
        {
            get
            {
                if (_cellObject == null)
                {
                    throw new System.Exception("GridObject is null");
                }

                else
                {
                    return _cellObject;
                }
            }
        }
    }
}

