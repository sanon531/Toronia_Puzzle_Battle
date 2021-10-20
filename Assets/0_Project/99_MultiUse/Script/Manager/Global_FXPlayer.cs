using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//블럭 FX와 UI에 사용되는 FX 를 저장하는 곳 입니다.
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


        public static void PlayFX(Data.FXKind _kind, Vector3 _pos,float _delayTime)
        {
            Instance.DelayedFX(_kind, _pos, _delayTime);
        }
        public static void PlayFX(Data.FXKind _kind, Vector3 _pos,Vector2 _size, float _delayTime)
        {
            Instance.DelayedFX(_kind, _pos, _size, _delayTime);
        }

        public static void PlayFX(Data.FXKind _kind, Vector3 _pos,Transform _transform)
        {
            Instantiate(Instance._FXDictionary[_kind], _pos,Quaternion.identity, _transform);
        }

        private void DelayedFX(Data.FXKind _kind, Vector3 _pos, float _delayTime)
        {
            StartCoroutine(DelayedInstantiate( Instance._FXDictionary[_kind], _pos, Instance.transform, new Vector2(1,1),_delayTime));
        }
        private void DelayedFX(Data.FXKind _kind, Vector3 _pos,Vector2 _size, float _delayTime)
        {
            StartCoroutine(DelayedInstantiate(Instance._FXDictionary[_kind], _pos, Instance.transform, _size, _delayTime));
        }


        IEnumerator DelayedInstantiate(GameObject transferedEX, Vector3 fXPos, Transform fXTransform, Vector2 Argsize, float delayedtime)
        {
            yield return new WaitForSecondsRealtime(delayedtime);
            GameObject FXObj = Instantiate(transferedEX, fXPos, Quaternion.identity, fXTransform);
            FXObj.transform.localScale = new Vector3(12.5f * Argsize.x, 12.5f * Argsize.y, 0);
        }
    }

}
