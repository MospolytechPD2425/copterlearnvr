using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
