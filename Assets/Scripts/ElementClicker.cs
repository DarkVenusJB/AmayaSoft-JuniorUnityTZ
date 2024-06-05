using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ElementClicker : MonoBehaviour
    { private int _elementIndex=0;
        
        private WinElementFinder _winElementFinder;

        public int ElementIndex
        {
            get
            {
                return _elementIndex;
            }

            set
            {
                if (_elementIndex == 0)
                {
                    _elementIndex = value;
                }
            }
        }

        private void Start()
        {
            _winElementFinder = GetComponent<WinElementFinder>();
        }

        private void OnMouseDown()
        {
            _winElementFinder.CheckWin(_elementIndex);
            
        }
    }
}

