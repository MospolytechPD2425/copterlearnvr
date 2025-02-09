using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Details;

namespace Monitors
{
    public class MonitorManager : MonoBehaviour
    {
        public static MonitorManager instance { get; private set; }

        [SerializeField] private bool _useBigMonitor;
        [SerializeField] private bool _useSmallMonitor;

        [SerializeField] private Monitor _bigMonitor;
        [SerializeField] private Monitor _smallMonitor;
        private void Awake()
        {
            instance = this;
        }
        public void SetDetail(Detail detail)
        {
            if (_useBigMonitor) _bigMonitor.SetDetail(detail);
            if (_useSmallMonitor) _smallMonitor.SetDetail(detail);
        }
        public void Clear()
        {
            if (_useBigMonitor) _bigMonitor.Clear();
            if (_useSmallMonitor) _smallMonitor.Clear();
        }
    }
}
