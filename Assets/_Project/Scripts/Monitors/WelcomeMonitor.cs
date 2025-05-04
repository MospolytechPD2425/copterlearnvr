using Assets._Project.Scripts.Monitors;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMonitor : MonoBehaviour
{
    [SerializeField] private MonitorPage[] _pages;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private GameObject _startBuildButton;
    private int _currentPage;
    private void Start()
    {
        SetPage(0);
    }
    public void SetPage(int page)
    {
        _currentPage = page;
        _image.sprite = _pages[_currentPage].Sprite;
        _image.SetNativeSize();
        _textComponent.text = _pages[_currentPage].Text;

        if (_currentPage == _pages.Length - 1)
        {
            _startBuildButton.SetActive(true);
        }
        else
        {
            _startBuildButton.SetActive(false);
        }
    }
    public void Next()
    {
        if (_currentPage < _pages.Length - 1)
        {
            SetPage(++_currentPage);
        }
    }
    public void Back()
    {
        if (_currentPage > 0)
        {
            SetPage(--_currentPage);
        }
    }
}
