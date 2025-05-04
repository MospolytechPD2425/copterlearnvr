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
        private DetailInteract? _currentDetail = null;
        [TagSelector] [SerializeField] private string _detailTag;
        
        private void Awake()
        {
            _interactor = GetComponent<XRSocketInteractor>();
        }
        private void OnEnable()
        {
            _interactor.selectEntered.AddListener(OnSelectEntered);
            _interactor.selectExited.AddListener(OnSelectExited);
        }
        private void OnDisable()
        {
            _interactor.selectEntered.RemoveListener(OnSelectEntered);
            _interactor.selectExited.RemoveListener(OnSelectExited);
        }
        private void OnSelectExited(SelectExitEventArgs arg0)
        {
            Debug.Log($"Detail Socket Selected {gameObject.name}");
            //_interactor.allowHover = true;
            if ( _currentDetail != null )
            {
                _currentDetail.HideContactPoints();
                _currentDetail.SetActiveContactPoints(false);
                _currentDetail = null;
            }
        }

        private void OnSelectEntered(SelectEnterEventArgs arg0)
        {
            Debug.Log($"Detail Socket Deselected {gameObject.name}");
            Debug.Log($"current Detail is null: {_currentDetail is null}");
            if (_currentDetail is not null)
            {
                _currentDetail.SetActiveContactPoints(true);
                _currentDetail.ShowContactPoints();
            }
            else
            {
                _interactor.interactionManager.SelectExit(_interactor, arg0.interactableObject);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (CheckDetailOnCollider(other))
            {
                //_interactor.socketActive = true;
                //_interactor.allowSelect = true;
                _interactor.allowHover = true;
                _currentDetail = other.GetComponent<DetailInteract>();
            }
            else
            {
                //_interactor.socketActive = false;
                //_interactor.allowSelect = false;
                _interactor.allowHover = false;
            }
        }
        
        private bool CheckDetailOnCollider(Collider collider)
        {
            return collider.CompareTag(_detailTag);
        }
    }
}
