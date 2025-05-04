using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Details
{
    public class DetailContainer : MonoBehaviour
    {
        private DetailInteract[] _items;
        private TransformData[] _itemsStartTransforms;
        private void Awake()
        {
            _items = GetComponentsInChildren<DetailInteract>();
            SaveInitialTransforms();
        }
        
        private void SaveInitialTransforms()
        {
            _itemsStartTransforms = new TransformData[_items.Length];
            
            for (int i = 0; i < _items.Length; i++)
            {
                _itemsStartTransforms[i] = new TransformData(_items[i].transform);
            }
        }
        
        public void ResetDetailsPositions()
        {
            if (_itemsStartTransforms == null || _itemsStartTransforms.Length != _items.Length)
            {
                Debug.LogWarning("Cannot reset positions: transform data is not initialized correctly");
                return;
            }
            
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i].transform.position = _itemsStartTransforms[i].Position;
                _items[i].transform.rotation = _itemsStartTransforms[i].Rotation;
                
                Rigidbody rb = _items[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
        
        /*
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
        */
    }
}