using Assets.Scripts.DataScripts;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ElementCreator : MonoBehaviour
    {
        private readonly List<int> _usedSpritesIndex = new List<int>();
        public void CreateElement(ElementBundleData _bundleData, Transform _cell)
        {
            var _element = new GameObject();
            Transform _elementTransform = _element.transform;

            _element.AddComponent<SpriteRenderer>();
            _element.GetComponent<SpriteRenderer>().sprite = _bundleData.ElementData[GenerateRandomIndex(_bundleData)].Sprite;
            _elementTransform.parent = _cell;
            _elementTransform.position = _cell.position;
            _elementTransform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        private int GenerateRandomIndex(ElementBundleData _bundleData)
        {
            System.Random random = new System.Random();

            int _maxRange = _bundleData.ElementData.Length;
            int randomIndex = random.Next(0, _maxRange);

            while (_usedSpritesIndex.Contains(randomIndex))
            {
                randomIndex = random.Next(0, _maxRange);
            }

            _usedSpritesIndex.Add(randomIndex);
            return randomIndex;
        }

        public void ClearSpritesIndexList()
        {
            _usedSpritesIndex.Clear();
        }


    }
}