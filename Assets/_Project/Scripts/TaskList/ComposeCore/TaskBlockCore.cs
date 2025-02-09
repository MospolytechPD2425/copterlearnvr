using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class TaskBlockCore : MonoBehaviour
{
    protected Transform taskViewPrefabsParent;
    protected GameObject taskViewPrefab;

    [SerializeField] protected TaskViewCore currentTaskView;
    
    public UnityEvent OnComplete;
    public UnityEvent OnCancel;
    
    [SerializeField] protected string taskBlockName;

    public string TaskBlockName => taskBlockName;

    protected bool isCompleted { get; set; }

    public bool IsCompleted => isCompleted;

    public virtual void SetUp(Transform viewPrefabsParent, GameObject viewPrefab)
    {
        taskViewPrefabsParent = viewPrefabsParent;
        taskViewPrefab = viewPrefab;
    }
    
    [ProPlayButton]
    public virtual void Complete()
    {
        isCompleted = true;
        OnComplete?.Invoke();
    }
    
    [ProPlayButton]
    public virtual void Cancel()
    {
        isCompleted = false;
        OnCancel?.Invoke();
    }

    public virtual void Display()
    {
        DisplayView();
    }

    public virtual void Hide()
    {
        HideView();
    }

    protected virtual void DisplayView()
    {
        if (currentTaskView != null)
        {
            currentTaskView.gameObject.SetActive(true);
        }
        else
        {
            currentTaskView = Instantiate(taskViewPrefab).GetComponent<TaskViewCore>();
            currentTaskView.transform.SetParent(taskViewPrefabsParent);
            currentTaskView.SetUp(this);
        }
    }

    protected virtual void HideView()
    {
        if (currentTaskView != null)
        {
            currentTaskView.gameObject.SetActive(false);
        }
    }
}
