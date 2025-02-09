using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using WSWhitehouse.TagSelector;

namespace Details
{
    [RequireComponent(typeof(XRSocketInteractor))]
    public class DetailSocket : MonoBehaviour
    {
        private XRSocketInteractor _interactor;
        [TagSelector] [SerializeField] private string _detailTag;
        
        private void Awake()
        {
            _interactor = GetComponent<XRSocketInteractor>();
            _interactor.selectEntered.AddListener(OnSelectEntered);
            _interactor.selectExited.AddListener(OnSelectExited);
            //_interactor.socketActive = false;
        }

        private void OnSelectExited(SelectExitEventArgs arg0)
        {
            _interactor.allowHover = true;
        }

        private void OnSelectEntered(SelectEnterEventArgs arg0)
        {
            _interactor.allowHover = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (CheckDetailOnCollider(other))
            {
                //_interactor.allowHover = true;
                _interactor.socketActive = true;
            }
            else
            {
                _interactor.socketActive = false;
                //_interactor.allowHover = false;
            }
        }
        /*
        private void OnTriggerExit(Collider other)
        {
            if (CheckDetailOnCollider(other))
            {
                _interactor.allowHover = false;
                //_interactor.socketActive = false;
            }
        }
        */
        private bool CheckDetailOnCollider(Collider collider)
        {
            Debug.Log($"collider: {collider.name}; bool: {collider.CompareTag("detail_fpv_goggles")}");
            return collider.CompareTag(_detailTag);
            //return collider.GetComponent<DetailInteract>().Info == _detailInteract.Info;
        }
        
    }
}
