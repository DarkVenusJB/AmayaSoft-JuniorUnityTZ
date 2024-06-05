using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

namespace Assets.Scripts
{
    public class WinElementFinder : MonoBehaviour
    {
        [SerializeField] private List<int> _previousWinElements = new List<int>();
        [SerializeField] private TMP_Text _win;

        private Initializator _initializator;
        private int _winIndex;

        [Inject]
        private void Construct(Initializator initializator)
        {
            _initializator = initializator;
        }

        public void FindWinIndex(List<int> currentLevelElements)
        {
            int index = Random.Range(0, currentLevelElements.Count);
            int winElement = currentLevelElements[index];

            for (int i = 0; i < currentLevelElements.Count; i++)
            {
                if (_previousWinElements.Contains(winElement))
                {
                    if (i + 1 == currentLevelElements.Count)
                    {
                        _previousWinElements.Clear();
                    }
                    index = Random.Range(0, currentLevelElements.Count);
                    winElement = currentLevelElements[index];
                }

                else
                {
                    break;
                }
            }

            _previousWinElements.Add(winElement);
            _winIndex = winElement;
            Debug.Log(winElement);
            Debug.Log(_initializator.currentElementData.ElementData[winElement].Name);
            _win.text = string.Format("Find: {0}", _initializator.currentElementData.ElementData[winElement].Name);
        }

        public void CheckWin(int _elementIndex)
        {
            if (_elementIndex == _winIndex)
            {
                Debug.Log("win");
            }
        }

    }
}

