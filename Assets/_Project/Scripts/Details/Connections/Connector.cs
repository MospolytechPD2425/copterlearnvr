using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Details.Connections
{
    [RequireComponent(typeof(Connections))]
    public class Connector : MonoBehaviour
    {
        public static Connector Instance { get; private set; }

        [SerializeField] private Connections _correctConnections;
        private ContactPoint? _hoveredContactPoint;
        private ContactPoint? _selectedContactPoint;
        private Connections _currentConnections;
        public Connections CorrectConnection { get => _correctConnections; }
        public ContactPoint? SelectedContactPoint { get => _hoveredContactPoint; }

        private void Awake()
        {
            Instance = this;
            _currentConnections = GetComponent<Connections>();
        }
        public void SetHoveredContactPoint(ContactPoint contactPoint)
        {
            Debug.Log($"SetHoveredContactPoint{gameObject.name}: OnHoverEntered");
            _hoveredContactPoint?.SetUnhoveredMaterial();
            _hoveredContactPoint = contactPoint;
            _hoveredContactPoint.SetHoveredMaterial();
        }
        private void Connect()
        {
            if (_hoveredContactPoint.transform != _selectedContactPoint.transform &&
                (!_currentConnections.ContainsContactPoint(_hoveredContactPoint) ||
                !_currentConnections.ContainsContactPoint(_selectedContactPoint)))
            {
                _currentConnections.Add(new Connection(_selectedContactPoint, _hoveredContactPoint));
                Debug.Log("ContactPoints Connected.");
                _hoveredContactPoint = null;
                _selectedContactPoint = null;
            }
            else
            {
                Debug.Log("ContactPoints Have one parent. Connection is impossible.");
            }
        }
        public void SelectPoint()
        {
            if (_hoveredContactPoint is not null)
            {
                if (_selectedContactPoint is null)
                {
                    _selectedContactPoint = _hoveredContactPoint;
                    _selectedContactPoint.SetSelectedMaterial();
                }
                else
                {
                    Connect();
                }
            }
        }
    }
}
