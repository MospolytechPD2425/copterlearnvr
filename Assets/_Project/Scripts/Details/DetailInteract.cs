using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Monitors;

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
            Debug.Log("Hide ContactPoints");
            HideContactPoints();
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
            ShowContactPoints();
        }
        private void OnFocusExited(FocusExitEventArgs arg0)
        {
            HideContactPoints();
        }

        private void OnHoverEntered(HoverEnterEventArgs arg0)
        {
            MonitorManager.instance.SetDetail(_info);
        }

        private void OnHoverExited(HoverExitEventArgs arg0)
        {

        }
        public void ShowContactPoints()
        {
            for (int i = 0; i < _contactPoints.Length; i++)
                _contactPoints[i].Show();
        }
        public void HideContactPoints()
        {
            for (int i = 0; i < _contactPoints.Length; i++)
                _contactPoints[i].Hide();
        }
    }
}
