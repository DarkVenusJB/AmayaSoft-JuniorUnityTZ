using System.Collections.Generic;
using Assets.Scripts.DataScripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class ElementCreator : MonoBehaviour
    {
        [SerializeField] private Vector3 _colliderSize;
        [SerializeField] private Vector3 _elementSize;
        
        private readonly List<int> _usedSpritesIndex = new List<int>();

        public void CreateElement(ElementBundleData _bundleData, Transform _cell)
        {
            var _element = new GameObject();
            int _bundleDataIndex = GenerateRandomIndex(_bundleData);

            ConfigureElement(_bundleData, _cell, _element, _bundleDataIndex);
        }

        private void ConfigureElement(ElementBundleData _bundleData, Transform _cell, GameObject _element, int _bundleDataIndex)
        {
            _element.name = _bundleData.ElementData[_bundleDataIndex].Name;

            CreateSpriteComponent(_bundleData, _element, _bundleDataIndex);
            CreateColliderComponent(_element);
            CreateClickerComponent(_element, _bundleDataIndex);

            SetElementTransform(_cell, _element);
        }

        private static void CreateClickerComponent(GameObject _element, int _bundleDataIndex)
        {
            _element.AddComponent<ElementClicker>();
            _element.GetComponent<ElementClicker>().ElementIndex = _bundleDataIndex;
        }

        private void SetElementTransform(Transform _cell, GameObject _element)
        {
            Transform _elementTransform = _element.transform;

            _elementTransform.parent = _cell;
            _elementTransform.position = _cell.position;
            _elementTransform.localScale = _elementSize;
        }

        private void CreateColliderComponent(GameObject _element)
        {
            _element.AddComponent<BoxCollider2D>();
            BoxCollider2D _elementCollider = _element.GetComponent<BoxCollider2D>();

            _elementCollider.isTrigger = true;
            _elementCollider.size = _colliderSize;
        }

        private static void CreateSpriteComponent(ElementBundleData _bundleData, GameObject _element, int _bundleDataIndex)
        {
            _element.AddComponent<SpriteRenderer>();
            _element.GetComponent<SpriteRenderer>().sprite = _bundleData.ElementData[_bundleDataIndex].Sprite;
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

        public List<int> GetUsedElements()
        {
            return _usedSpritesIndex;
        }
    }
}