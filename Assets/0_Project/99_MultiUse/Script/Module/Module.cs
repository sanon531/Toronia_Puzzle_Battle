using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using System;

namespace ToronPuzzle
{/// <summary>
 /// 모듈은 배틀에서 만 활용되는 것이 아니라
 /// 탐험 하면서 계속 해서 획득하고  버리고 할수있어야 한다.
 /// 유물처럼 활용되며 
 /// </summary>


    [System.Serializable]
    public class ModuleInfo : Affector
    {
        [Flags]
        public enum Property
        {
            없음 = 0,
            수치표시 = 1,
        }

        public ModuleInfo() { }

        public ModuleInfo(ModuleID moduleID)
        {
            
        }

        public void ActivateModuleEffect()
        {
            Enable();
        }
        public void DeactivateModuleEffect()
        {
            Disable();
        }


        public bool IsRightness= true;
        protected int[] _artifactEffectValues;
        [SerializeField]
        protected Property _properties;
        public Property properties { get { return _properties; } }
        [SerializeField]
        protected Rarity _rarity;
        public Rarity rarity { get { return _rarity; } }
        [SerializeField]
        protected ModuleID _artifactID;
        public ModuleID artifactID { get { return _artifactID; } }
        [SerializeField]
        protected int _value;
        public virtual int Value
        {
            get { return _value; }
            protected set { _value = value; }
        }

        public virtual int? ValueForDisplay
        {
            get
            {
                if (_properties.HasFlag(Property.수치표시))
                {
                    return Value;
                }
                else
                {
                    return null;
                }
            }
        }


    }


}
