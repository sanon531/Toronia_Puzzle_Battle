using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Battle_BuffShow : MonoBehaviour
    {
        [SerializeField]
        Image _thisImage;
        [SerializeField]
        TextMeshProUGUI _text;


        public void SetDataOnShow(CharBuffData _data)
        {
            Debug.Log(_data._effect.ToString());
            _thisImage.sprite = Resources.Load<Sprite>("BuffShow/"+_data._effect.ToString());
            if(_data._amount != 0)
                _text.text = _data._amount.ToString();
            else
                _text.text = "";
        }




    }
}