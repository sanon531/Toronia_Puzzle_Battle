using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    //��� ���̽� ���� �� ���� �ǹ��Ѵ�.
    //UI ����� ������
    //��⿡���� Ȱ��Ǹ� ����� ����� ���� ������ �������� ������.
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
        //���ü�+ �о��� ���� �и�
        public virtual void LiftCell() { }
        public virtual void ResetCell() { }




    }

}
