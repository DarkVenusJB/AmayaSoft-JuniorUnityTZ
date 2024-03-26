using System;
using UnityEngine;

namespace Assets.Scripts.DataScripts
{
    [Serializable]
    public class ElementData
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;

        public string Name => _name;
        public Sprite Sprite => _sprite;
    }

    [CreateAssetMenu(fileName = "NewLetterData", menuName = "Data/ElementData", order = 0)]
    public class ElementBundleData : ScriptableObject
    {
        [SerializeField] private ElementData[] _elementData;

        public ElementData[] ElementData => _elementData;
    }
}