using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace ToronPuzzle
{
    public class BlockCaseCell_World : BlockCaseCell
    {
        SpriteRenderer _spriteRenderer;
        BoxCollider2D _boxCollider;
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        public override bool CheckLiftable()
        {
            return _blockInfo.IsLiftable;
        }
        public override BlockCase LiftBlock()
        {
            _parentCase.LiftBlock();
            return _parentCase;
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
            if(_boxCollider != null)
                _boxCollider.enabled = false;
        }

        public override void ResetCell()
        {
            _spriteRenderer.color = _normalColor;
            if (_boxCollider != null)
                _boxCollider.enabled = true;

        }

    }

}
