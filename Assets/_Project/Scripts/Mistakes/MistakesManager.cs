using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MistakesManager : MonoBehaviour, IInitializable
{
    private static MistakesManager s_mistakesManager;
    public static MistakesManager SingletoneMistakesManager => s_mistakesManager;

    [SerializeField] private UnityEvent onInitialized;
    public UnityEvent OnInitialized => onInitialized;
    
    public bool IsInitializationOnStartRequired => true;
    public bool AreCriticalMistakesStunning = true;

    public int TotalPenalty;
    public List<MistakeTaskDecorator> Mistakes = new List<MistakeTaskDecorator>();

    public void Initialize()
    {
        s_mistakesManager = this;
    }
}
