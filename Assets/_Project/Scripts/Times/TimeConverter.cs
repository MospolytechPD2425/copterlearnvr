using System;
using System.Security;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Times
{
    public class TimeConverter
    {
        public static string ConvertToMinSecs(double seconds)
        {
            int minutes = (int)(seconds / 60);
            int remainingSeconds = (int)(seconds % 60);
            int hundredths = (int)((seconds * 100) % 100);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, remainingSeconds, hundredths);
        }
    }
}
