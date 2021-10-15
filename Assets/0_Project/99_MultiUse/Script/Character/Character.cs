using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    public class Character : MonoBehaviour
    {
        public float _health = 100; 
        protected Material _character_material = default;
        protected SkeletonAnimation _spine_Animation = default;
        protected List<CharStatusEffects> _status_Effects = new List<CharStatusEffects>();

        public virtual void SetMaterialTweenAll()
        {

        }



        public virtual void SetSpineAnimation()
        {

        }
    }
}
