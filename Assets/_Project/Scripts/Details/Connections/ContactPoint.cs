using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Details.Connections
{
    public class ContactPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _sphere;
        [SerializeField] private Material _hoveredMaterial;
        [SerializeField] private Material _selectedMaterial;
        [SerializeField] private Material _unhoveredMaterial;

        private ContactPointMatState _matState;
        private MeshRenderer _sphereRenderer;
        private XRSimpleInteractable _interactable;
        private Vector3 _homePosition;

        public ContactPointMatState MatState { get => _matState; }
        private void Awake()
        {
            _interactable = GetComponent<XRSimpleInteractable>();
            _sphereRenderer = _sphere.GetComponent<MeshRenderer>();
        }
        private void OnEnable()
        {
            Debug.Log("Подписываю на события.");
            _interactable.hoverEntered.AddListener(OnHoverEntered);
            _interactable.hoverExited.AddListener(OnHoverExited);
            _interactable.selectEntered.AddListener(OnSelectEntered);
            _interactable.selectExited.AddListener(OnSelectExited);

        }
        private void OnDisable()
        {
            _interactable.hoverEntered.RemoveListener(OnHoverEntered);
            _interactable.hoverExited.RemoveListener(OnHoverExited);
            _interactable.selectEntered.RemoveListener(OnSelectEntered);
            _interactable.selectExited.RemoveListener(OnSelectExited);
        }

        private void OnSelectExited(SelectExitEventArgs arg0)
        {
            
        }

        private void OnSelectEntered(SelectEnterEventArgs arg0)
        {

        }
        private void OnHoverExited(HoverExitEventArgs arg0)
        {
            Debug.Log($"ContactPoint: OnHoverExited");
            if (_sphereRenderer.material == _hoveredMaterial)
            {
                SetUnhoveredMaterial();
            }
        }

        private void OnHoverEntered(HoverEnterEventArgs arg0)
        {
            Debug.Log($"ContactPoint{gameObject.name}: OnHoverEntered");
            if (Connector.Instance)
            {
                Connector.Instance.SetHoveredContactPoint(this);
            }
        }
        public void SetHoveredMaterial()
        {
            _sphereRenderer.material = _hoveredMaterial;
        }
        public void SetUnhoveredMaterial()
        {
            _sphereRenderer.material = _unhoveredMaterial;
        }
        public void SetSelectedMaterial()
        {
            _sphereRenderer.material = _selectedMaterial;
        }
          
        public void Show()
        {
            _sphere.SetActive(true);
        }
        public void Hide()
        {
            _sphere.SetActive(false);
        }
    }
}