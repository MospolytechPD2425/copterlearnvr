using Assets._Project.Scripts.DifficultyLevels;
using Assets.Scripts.Times;
using Details;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Scripts.Build
{
    public class BuildController : MonoBehaviour
    {
        [SerializeField] private GameObject _affordances;
        [SerializeField] private GameObject _copterScheme;
        [SerializeField] private GameObject _sockets;
        [SerializeField] private DetailContainer _detailContainer;
        [SerializeField] private Stopwatch _stopwatch;
        private DifficultyLevel _difficultyLevel;
        public static bool IsBuilding { get; private set; }
        private void Awake()
        {
            IsBuilding = false;
        }
        public void SetDifficult(DifficultyLevel difficultyLevel)
        {
            _difficultyLevel = difficultyLevel;
        }
        public void StartBuild()
        {
            SetDifficult(DifficultyLevel.CreateDefault());
            if (!_difficultyLevel.HideAffordances)
                _affordances.SetActive(true);
            if (_difficultyLevel.HideCopterScheme)
                _copterScheme.SetActive(false);
            _sockets.SetActive(true);
            _detailContainer.ResetDetailsTransforms();
            _stopwatch.StartTick();
            IsBuilding = true;
        }
        public void StopBuild()
        {
            if (!_difficultyLevel.HideAffordances)
                _affordances.SetActive(false);
            if (_difficultyLevel.HideCopterScheme)
                _copterScheme.SetActive(true);
            _sockets.SetActive(false);
            _stopwatch.StopTick();
            IsBuilding = false;
        }
    }
}