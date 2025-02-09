using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Details
{
    public class DetailContainer : MonoBehaviour
    {
        private DetailInteract[] _items;
        private void Awake()
        {
            _items = GetComponentsInChildren<DetailInteract>();
        }
        public void ShowPossibleContactPoints(DetailInteract detail_from)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == detail_from) continue;
                _items[i].ShowContactPoints();
            }
        }
        public void HideContactPoints()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].HideContactPoints();
            }
        }
    }
}
