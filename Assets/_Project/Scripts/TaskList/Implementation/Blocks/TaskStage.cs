using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TaskStage : TaskBlockCore
{
    [SerializeField] protected Transform childTaskViewPrefabsParent;
    [SerializeField] protected GameObject childTaskViewPrefab;
    
    public List<TaskBlockCore> ChildTaskBlocks;

    public override void SetUp(Transform viewPrefabsParent, GameObject viewPrefab)
    {
        base.SetUp(viewPrefabsParent, viewPrefab);
        ChildTaskBlocks = transform.CollectChildren<TaskBlockCore>();
        foreach (var children in ChildTaskBlocks)
        {
            children.SetUp(childTaskViewPrefabsParent, childTaskViewPrefab);
            children.OnComplete.AddListener(OnChildTaskBlockComplete);
            children.OnCancel.AddListener(OnChildTaskBlockCancel);
        }
    }

    public override void Display()
    {
        base.Display();
        foreach (var children in ChildTaskBlocks)
        {
            children.Display();
        }
    }

    public override void Hide()
    {
        base.Hide();
        foreach (var children in ChildTaskBlocks)
        {
            children.Hide();
        }
    }

    protected virtual void OnChildTaskBlockComplete()
    {
        int completedChildBlocksNumber = 0;
        foreach (var childTaskBlock in ChildTaskBlocks)
        {
            if (childTaskBlock.IsCompleted)
            {
                completedChildBlocksNumber++;
            }
        }

        if (completedChildBlocksNumber == ChildTaskBlocks.Count)
        {
            Complete();
        }
    }
    
    protected virtual void OnChildTaskBlockCancel()
    {
        if (isCompleted)
        {
            Cancel();
        }
    }
}
