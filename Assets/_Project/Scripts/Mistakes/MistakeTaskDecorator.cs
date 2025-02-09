using System;
using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class MistakeTaskDecorator : MonoBehaviour
{
    [SerializeField] protected Task task;
    [SerializeField] protected int penalty;
    [SerializeField] protected bool isCritical = false;

    private bool _isMade;
    public bool IsMade => _isMade;

    private void Start()
    {
        if (task == null)
        {
            if (!TryGetComponent(out task))
            {
                throw new NullReferenceException($"GameObject {name} MistakeTaskDecorator Task is null");
            }
        }
    }

    [ProPlayButton]
    public void MakeMistake()
    {
        if (!_isMade)
        {
            _isMade = true;
            MistakesManager.SingletoneMistakesManager.Mistakes.Add(this);
            MistakesManager.SingletoneMistakesManager.TotalPenalty += penalty;
            if (isCritical && MistakesManager.SingletoneMistakesManager.AreCriticalMistakesStunning)
            {
                return;
            }
            task.Complete();
        }
    }

    [ProPlayButton]
    public void UnmakeMistake()
    {
        if (_isMade)
        {
            _isMade = false;
            MistakesManager.SingletoneMistakesManager.Mistakes.Remove(this);
            MistakesManager.SingletoneMistakesManager.TotalPenalty -= penalty;
            if (task.IsCompleted)
            {
                task.Cancel();
            }
        }
    }
}
