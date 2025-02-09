using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TransformChildrenControllerExtensions
{
    /// <summary>
    /// search works only in one in depth level
    /// </summary>
    /// <param name="transform"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> CollectChildren<T>(this Transform transform)
    {
        var result = new List<T>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            result.Add(child.GetComponent<T>());
        }
        return result;
    }
}
