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



    }

}
