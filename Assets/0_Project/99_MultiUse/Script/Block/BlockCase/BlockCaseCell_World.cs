using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace ToronPuzzle
{
    public class BlockCaseCell_World : BlockCaseCell
    {
        SpriteRenderer _spriteRenderer;
        public override bool CheckLiftable()
        {
            return base.CheckLiftable();
        }
        public override void SetMaterial(Material _mat)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.material = _mat;
        }


    }

}
