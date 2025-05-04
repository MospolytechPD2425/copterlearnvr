using UnityEditor;
using UnityEngine;

namespace Assets._Project.Scripts.DifficultyLevels
{
    public class DifficultyLevel
    {
        public bool HideAffordances { get; private set; }
        public bool HideColliderAffordances { get; private set; }
        public bool HideCopterScheme { get; private set; }
        public DifficultyLevel(bool hideAffordances, bool hideColliderAffordances, bool hideCopterScheme)
        {
            HideAffordances = hideAffordances;
            HideColliderAffordances = hideColliderAffordances;
            HideCopterScheme = hideCopterScheme;
        }
        public static DifficultyLevel CreateEasy()
        {
            return new DifficultyLevel(true, false, false);
        }
        public static DifficultyLevel CreateMedium()
        {
            return new DifficultyLevel(false, true, true);
        }
        public static DifficultyLevel CreateHard()
        {
            return new DifficultyLevel(true, true, true);
        }
        public static DifficultyLevel CreateDefault()
        {
            return new DifficultyLevel(true, false, true);
        }
    }
}