using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine;
using Details.Connections;
using Assets.Scripts.UI;

namespace Assets._Project.Scripts
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private InputActionProperty _primaryButton;
        [SerializeField] private InputActionProperty _secondaryButton;
        [SerializeField] private InputActionProperty _stickPress;

        private void OnEnable()
        {
            _primaryButton.action.performed += OnPrimaryButtonPressed;
            _secondaryButton.action.performed += OnSecondaryButtonPressed;
            _stickPress.action.performed += OnStickPressed;
        }


        private void OnDisable()
        {
            _primaryButton.action.performed -= OnPrimaryButtonPressed;
            _primaryButton.action.performed -= OnSecondaryButtonPressed;
            _stickPress.action.performed -= OnStickPressed;
        }

        private void OnStickPressed(InputAction.CallbackContext context)
        {
            UIManager.instance.ShowOrHideTaskList();
        }
        private void OnPrimaryButtonPressed(InputAction.CallbackContext obj)
        {
            Connector.Instance.SelectPoint();
        }
        private void OnSecondaryButtonPressed(InputAction.CallbackContext obj)
        {
            Connector.Instance.SelectPoint();
        }
    }
}
