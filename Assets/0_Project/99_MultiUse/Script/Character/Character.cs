using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    public class Character : MonoBehaviour
    {
        public Data_Character _characterData;

        public float _health = 100;
        [SerializeField]
        protected Material _character_material = default;
        [SerializeField]
        protected SkeletonAnimation _skeletonAnimation = default;
        [SerializeField]
        protected List<CharBuff> _status_Effects = new List<CharBuff>();

        public virtual void BeginCharactor()
        {

        }


        public virtual void SetMaterialTweenAll()
        {

        }



        public virtual void SetSpineAnimation(string _name)
        {

        }
    }
}
