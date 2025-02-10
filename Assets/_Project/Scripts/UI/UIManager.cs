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
    private void Awake()
    {
        instance = this;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
}
