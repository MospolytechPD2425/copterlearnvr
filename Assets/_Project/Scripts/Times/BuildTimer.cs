using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;
using Assets.Scripts.Times;

namespace Assets.Scripts.Times
{
    public class BuildTimer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;
        private float _tickFrequency = 0.1f;
        private bool _isTicking = false;

        public double TimeInSeconds { get; private set; }
        public void StartTimer()
        {
            TimeInSeconds = 0;
            StartCoroutine(Tick());
        }
        public void StopTimer()
        {
            StopCoroutine(Tick());
        }
        private IEnumerator Tick()
        {
            while (true)
            {
                _text.text = TimeConverter.ConvertToMinSecs(TimeInSeconds);
                yield return new WaitForSeconds(_tickFrequency);
                TimeInSeconds += _tickFrequency;
            }
        }
    }
}
