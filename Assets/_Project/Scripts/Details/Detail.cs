using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Details
{
    [CreateAssetMenu(fileName = "Detail", menuName = "ScriptableObjects/Detail")]
    public class Detail : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;

        public string Title { get => _title; }
        public string Description { get => _description; }
        public Sprite Sprite { get => _sprite; }
    }
}
