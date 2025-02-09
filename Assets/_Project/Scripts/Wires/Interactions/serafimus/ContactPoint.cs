using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ContactPoint : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private Material _hoveredMaterial;
    [SerializeField] private Material _unhoveredMaterial;

    private MeshRenderer _sphereRenderer;
    private XRGrabInteractable _grabInteractable;
    private Vector3 _homePosition;
    private void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _sphereRenderer = _sphere.GetComponent<MeshRenderer>();
    }
    private void OnEnable()
    {
        _grabInteractable.hoverEntered.AddListener(OnHoverEntered);
        _grabInteractable.hoverExited.AddListener(OnHoverExited);
        _grabInteractable.focusEntered.AddListener(OnFocusEntered);
        _grabInteractable.focusExited.AddListener(OnFocusExited);
    }


    private void OnDisable()
    {
        _grabInteractable.hoverEntered.RemoveListener(OnHoverEntered);
        _grabInteractable.hoverExited.RemoveListener(OnHoverExited);
        _grabInteractable.focusEntered.RemoveListener(OnFocusEntered);
        _grabInteractable.focusExited.RemoveListener(OnFocusExited);
    }
    private void OnFocusExited(FocusExitEventArgs arg0)
    {
        transform.position = _homePosition;
    }

    private void OnFocusEntered(FocusEnterEventArgs arg0)
    {
        _homePosition = transform.position;
    }

    private void OnHoverExited(HoverExitEventArgs arg0)
    {
        _sphereRenderer.material = _unhoveredMaterial;
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
        _sphereRenderer.material = _hoveredMaterial;
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
