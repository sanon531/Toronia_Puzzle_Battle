using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{

    public class Affector
    {
        public bool IsEnabled { get; private set; } = false;
        protected virtual void Enable() { IsEnabled = true; }
        protected virtual void Disable() { IsEnabled = false; }
    }
    public class SkillPassive : Affector
    {
        protected int[] _skillValues;

        public void SetSkillValues(int[] skillValues)
        {
            _skillValues = skillValues;
        }

        public void OnTrain()
        {
            Enable();
        }
        public void OnObsolete()
        {
            Disable();
        }
    }





}

