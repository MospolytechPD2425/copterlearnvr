using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Details;
using Monitors;

public class TestMonitor : MonoBehaviour
{
    [SerializeField] private Monitor _monitor;
    [SerializeField] private Detail _detail;
    [SerializeField] private int _timeout = 5;
    private void Start()
    {
        StartCoroutine(TestDataShow());
    }
    private IEnumerator TestDataShow()
    {
        yield return new WaitForSeconds(_timeout);
        _monitor.Clear();
        yield return new WaitForSeconds(_timeout);
        _monitor.SetDetail(_detail);
    }
}
