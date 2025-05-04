using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using ContactPoint = Details.Connections.ContactPoint;

namespace Details
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class DetailInteract : MonoBehaviour
    {
        [SerializeField] private Detail _info;

        public Detail Info { get { return _info; } }

        private ContactPoint[] _contactPoints;
        private void Awake()
        {
            _contactPoints = GetComponentsInChildren<ContactPoint>();
        }
        private void Start()
        {
            HideContactPoints();
            SetActiveContactPoints(false);
        }
        private void OnEnable()
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.hoverEntered.AddListener(OnHoverEntered);
            grabInteractable.hoverExited.AddListener(OnHoverExited);
            grabInteractable.focusEntered.AddListener(OnFocusEntered);
            grabInteractable.focusExited.AddListener(OnFocusExited);
        }
        private void OnDisable()
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.hoverEntered.RemoveListener(OnHoverEntered);
            grabInteractable.hoverExited.RemoveListener(OnHoverExited);
            grabInteractable.focusEntered.RemoveListener(OnFocusEntered);
            grabInteractable.focusExited.RemoveListener(OnFocusExited);
        }

        private void OnFocusEntered(FocusEnterEventArgs arg0)
        {
            //ShowContactPoints();
        }
        private void OnFocusExited(FocusExitEventArgs arg0)
        {
            //HideContactPoints();
        }

        private void OnHoverEntered(HoverEnterEventArgs arg0)
        {
            
            
        }

        private void OnHoverExited(HoverExitEventArgs arg0)
        {
            
        }
        public void ShowContactPoints()
        {
            Debug.Log($"ShowContactPoints {_info.Title}");
            for (int i = 0; i < _contactPoints.Length; i++)
                _contactPoints[i].Show();
        }
        public void HideContactPoints()
        {
            Debug.Log($"HideContactPoints {_info.Title}");
            for (int i = 0; i < _contactPoints.Length; i++)
                if (_contactPoints[i].MatState != Connections.ContactPointMatState.Selected)
                    _contactPoints[i].Hide();
        }
        public void SetActiveContactPoints(bool active)
        {
            for (int i = 0; i < _contactPoints.Length; i++)
                _contactPoints[i].gameObject.SetActive(active);
        }
    }
}
