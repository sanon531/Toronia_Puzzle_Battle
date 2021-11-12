using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    //블록 케이스 셀은 각 셀을 의미한다.
    //UI 월드로 나뉘며
    //모듈에서도 활용되며 현재는 사이즈만 조절 가능한 수준으로 만들자.
    public class BlockCaseCell : BlockCase
    {
        public Vector2Int _cellPos=new Vector2Int(-1,-1);
        public BlockCase _parentCase;
        protected Color _normalColor = new Color(1, 1, 1, 1);
        protected Color _liftColor = new Color(0.75f, 0.75f, 0.75f, 1);

        public virtual void SetParentCase(BlockCase arg_parent)
        {
            _parentCase = arg_parent;
        }
        public override BlockCase LiftBlock()
        {
            _parentCase.LiftBlock();
            return _parentCase;
        }
        public virtual void SetMaterial(Material _mat)
        {


        }


        //가시성+ 분업를 위한 분리
        public virtual void LiftCell() { }
        public virtual void ResetCell() { }




    }

}
