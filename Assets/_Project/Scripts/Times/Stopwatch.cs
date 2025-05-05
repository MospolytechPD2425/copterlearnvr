using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;
using Assets.Scripts.Times;

namespace Assets.Scripts.Times
{
    public class Stopwatch : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;
        private float _tickFrequency = 0.01f;
        private bool _isTicking = false;

        public double TimeInSeconds { get; private set; }
        public void StartTick()
        {
            TimeInSeconds = 0;
            _isTicking = true;
            StartCoroutine(Tick());
            _text.color = Color.white;
        }
        
        public void StopTick()
        {
            _isTicking = false;
            StopAllCoroutines();
            _text.color = Color.gray;
            _text.text = "00:00:00";
        }
        
        private IEnumerator Tick()
        {
            while (_isTicking)
            {
                _text.text = TimeConverter.ConvertToMinSecs(TimeInSeconds);
                yield return new WaitForSeconds(_tickFrequency);
                TimeInSeconds += _tickFrequency;
            }
        }
    }
}
