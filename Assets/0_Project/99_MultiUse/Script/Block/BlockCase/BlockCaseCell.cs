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
        

        public BlockCase _parentCase;


        public void initializeCell(BlockCase arg_parent)
        {
            _parentCase = arg_parent;


        }




    }

}
