using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    //��� ���̽� ���� �� ���� �ǹ��Ѵ�.
    //��⿡���� Ȱ��Ǹ� ����� ����� ���� ������ �������� ������.


    public class BlockCaseCell : MonoBehaviour
    {
        SpriteRenderer _spriteRenderer;



        public void SetBlockSize(Vector2 arg_size)
        {
            transform.localScale = arg_size;
        }


    }

}
