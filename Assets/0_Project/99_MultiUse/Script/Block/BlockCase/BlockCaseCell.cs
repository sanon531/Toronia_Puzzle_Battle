using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    //블록 케이스 셀은 각 셀을 의미한다.
    //모듈에서도 활용되며 현재는 사이즈만 조절 가능한 수준으로 만들자.


    public class BlockCaseCell : MonoBehaviour
    {
        SpriteRenderer _spriteRenderer;



        public void SetBlockSize(Vector2 arg_size)
        {
            transform.localScale = arg_size;
        }


    }

}
