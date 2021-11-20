using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ToronPuzzle.WorldMap
{
    public class BlockCase_Module_UI : BlockCase_BlockPlace
    {


        [SerializeField]
        SpriteRenderer _moduleImage;

        public void InitializeModule(BlockInfo _argInfo, float _size_x)
        {
            _blockInfo = new BlockInfo(_argInfo);
            _moduleImage = GetComponentInChildren<SpriteRenderer>();
            _moduleImage.sprite = Resources.Load<Sprite>("Module/" + _blockInfo._moduleID.ToString());
            _moduleImage.transform.localScale = new Vector3(1/_size_x, 1 / _size_x, 1 / _size_x);
        }

        public void SetSpritePos(Vector3 _vector)
        {
            _moduleImage.transform.position = _vector;
        }


    }
}