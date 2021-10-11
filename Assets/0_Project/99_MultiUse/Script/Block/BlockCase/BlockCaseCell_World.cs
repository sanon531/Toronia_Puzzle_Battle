using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace ToronPuzzle
{
    public class BlockCaseCell_World : BlockCaseCell
    {
        SpriteRenderer _spriteRenderer;
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public override bool CheckLiftable()
        {
            return base.CheckLiftable();
        }
        public override void SetMaterial(Material _mat)
        {
            //Debug.Log("SetMaterial on "+gameObject.name);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.material = _mat;

        }
        public override void LiftCell()
        {
            _spriteRenderer.color = _liftColor;
        }

        public override void ResetCell()
        {

            _spriteRenderer.color = _normalColor;
        }

    }

}
