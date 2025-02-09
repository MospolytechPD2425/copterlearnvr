using UnityEngine;
using NaughtyAttributes;

namespace HInteractions
{
    [DisallowMultipleComponent]
    public class Interactable : MonoBehaviour
    {
        public static Interactable SelectedInteractable;
        
        [field: SerializeField] public bool ShowPointerOnInterract { get; private set; } = true;

        [field: SerializeField, ReadOnly] public bool IsSelected { get; private set; }

        protected virtual void Awake()
        {
            Deselect();
        }

        public virtual void Select()
        {
            IsSelected = true;
            SelectedInteractable = this;
        }

        public virtual void Deselect()
        {
            IsSelected = false;
            SelectedInteractable = null;
        }
    }
}