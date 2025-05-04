using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.UI;

namespace Assets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance { get; private set; }

        

        [SerializeField] private GameObject _taskListGameObject;
        private void Awake()
        {
            instance = this;
        }
        public void ShowOrHideTaskList()
        {
            _taskListGameObject.SetActive(!_taskListGameObject.activeSelf);
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}
