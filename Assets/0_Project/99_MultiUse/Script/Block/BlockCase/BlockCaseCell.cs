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
        

        public BlockCase _parentCase;


        public void initializeCell(BlockCase arg_parent)
        {
            _parentCase = arg_parent;


        }




    }

}
