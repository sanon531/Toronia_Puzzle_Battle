using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace ToronPuzzle
{
    public enum TweenType
    {
        world_Move,
        local_Move,
        Anchor_Move
    }


    public class ObjectTweener : MonoBehaviour
    {
        public TweenType _function;
        public Transform _targetTransform;
        public Vector3 _targetpos;
        public float _duration;
        [SerializeField]
        Ease current_Ease = Ease.InSine;

        public void CallTween()
        {
            switch (_function)
            {
                case TweenType.world_Move:
                    _targetTransform.DOMove(_targetpos, _duration).SetEase(current_Ease);
                    break;
                case TweenType.local_Move:
                    _targetTransform.DOMove(_targetpos, _duration).SetEase(current_Ease);
                    break;
                case TweenType.Anchor_Move:
                    _targetTransform.GetComponent<RectTransform>().DOAnchorPos(_targetpos, _duration).SetEase(current_Ease);
                    break;
                default:
                    Debug.LogError("ObjectTweener Type Error");
                    break;
            }

        }
    }
}
