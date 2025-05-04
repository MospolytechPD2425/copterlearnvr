using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.Monitors
{
    [Serializable]
    public class MonitorPage
    {
        [SerializeField] private Sprite _image;

        [TextArea] [SerializeField] private string _text;
        public Sprite Sprite { get => _image; }
        public string Text { get => _text; }
    }
}