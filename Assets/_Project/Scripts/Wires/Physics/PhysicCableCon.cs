using System.Collections;
using UnityEngine;
using HInteractions;

namespace HPhysic
{
    [RequireComponent(typeof(Connector))]
    public class PhysicCableCon : Interactable
    {
        private Connector _connector;

        protected override void Awake()
        {
            base.Awake();

            _connector = gameObject.GetComponent<Connector>();
        }

        public void PickUp()
        {
            if (_connector.ConnectedTo)
                _connector.Disconnect();
        }

        public void Drop()
        {
            if (SelectedInteractable && SelectedInteractable.TryGetComponent(out Connector secondConnector))
            {
                if (_connector.CanConnect(secondConnector))
                    secondConnector.Connect(_connector);
                else if (!secondConnector.IsConnected)
                {
                    transform.rotation = secondConnector.ConnectionRotation * _connector.RotationOffset;
                    transform.position = (secondConnector.ConnectionPosition + secondConnector.ConnectedOutOffset * 0.2f) - (_connector.ConnectionPosition - _connector.transform.position);
                }
            }
        }
    }
}