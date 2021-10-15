using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� FX�� UI�� ���Ǵ� FX �� �����ϴ� �� �Դϴ�.
namespace ToronPuzzle
{
    public class Global_FXPlayer : MonoBehaviour
    {
        public static Global_FXPlayer Instance;
        public FXObjectDictionary _FXDictionary;


        public virtual void BeginFXPlayer()
        {
            Instance = this;
        }

        public static void PlayFX(Data.FXKind _kind, Vector3 _pos)
        {
            Instantiate(Instance._FXDictionary[_kind], _pos, Quaternion.identity, Instance.transform);
        }


        public static void PlayFX(Data.FXKind _kind, Vector3 _pos,Transform _transform)
        {
            Instantiate(Instance._FXDictionary[_kind], _pos,Quaternion.identity, _transform);
        }

    }

}
