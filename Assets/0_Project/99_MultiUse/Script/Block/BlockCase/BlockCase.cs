using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    //��ϵ��� �Ѵ�� ���� ���̽� ����� ������ ����ִ�.
    public class BlockCase : MonoBehaviour
    {
        public bool IsEmpty=false;
        public int _maxBlockX, _maxBlockY = 1;
        public BlockInfo _blockInfo= new BlockInfo();
        public Vector2 BlockSize = new Vector2(180, 180);
        // Start is called before the first frame update

        public virtual bool CheckLiftable()
        {
            return IsEmpty;
        }

        //���̽��� ��������� ����.
        public virtual BlockCase LiftBlock()
        {
            return this;
        }
        public virtual bool CheckPlaceable(BlockInfo blockInfo, int[,] Arg_IntArr)
        {
            return false;
        }
        public virtual bool CheckPlaceable(BlockInfo blockinfo)
        {
            return false;
        }

        public virtual void PlaceBlock(BlockInfo  blockInfo, int[,] Arg_IntArr)
        {
        }

        public virtual void PlaceBlock(BlockInfo blockInfo)
        {
        }
        public virtual void PlaceBlock()
        {
        }

        public virtual void ResetBlock()
        {
        }

        public virtual void DeleteBlock()
        {

        }


    }
}
