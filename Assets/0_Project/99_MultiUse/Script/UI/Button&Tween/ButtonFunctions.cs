﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace ToronPuzzle
{
    public enum BtnType
    {
        None,
        disableTarget,
        enableTarget,
        pauseGame,
        unPauseGame,
        showMenu,
        hideMenu,
        fadeInMenu,
        fadeOutMenu,
        setSizeBigMenu,
        setSizeSmallMenu

    }
}

namespace ToronPuzzle.UI
{

    public class ButtonFunctions : MonoBehaviour
    {

        [SerializeField]
        bool _onButton = false;

      
        public BtnType function;

        public float _fadeInAmount = 0;
        public float _waitTime = 0;

        // Dotween 적용
        public RectTransform arg_RectTransform;
        [SerializeField]
        Ease current_Ease = Ease.InSine;
        [SerializeField]
        Vector3 _targetPos;
        [SerializeField]
        List<Image> _targetImages = new List<Image>();
        [SerializeField]
        List<TextMeshProUGUI> _targetTexts = new List<TextMeshProUGUI>();
        public void Start()
        {
            if (_onButton)
                GetComponent<Button>().onClick.AddListener(() => OnClick());
        }

        public void OnClick()
        {
            Global_CoroutineManager.Run(ClickCoroutine());
        }
        IEnumerator ClickCoroutine()
        {
            yield return new WaitForSeconds(_waitTime);
            switch (function)
            {
                case BtnType.disableTarget:
                    arg_RectTransform.gameObject.SetActive(false);
                    break;
                case BtnType.enableTarget:
                    arg_RectTransform.gameObject.SetActive(true);
                    break;
                case BtnType.showMenu:
                    arg_RectTransform.DOAnchorPos(_targetPos, 0.5f).SetEase(current_Ease);
                    break;
                case BtnType.hideMenu:
                    arg_RectTransform.DOAnchorPos(_targetPos, 0.5f).SetEase(current_Ease);
                    //Debug.Log(TargetPos);
                    //arg_transform.localPosition = new Vector3(0, 9999, 0);
                    break;
                case BtnType.pauseGame:
                    //BeatManager.Instance.mp.Paused = true;
                    break;
                case BtnType.unPauseGame:
                    //BeatManager.Instance.mp.Paused = false;
                    Time.timeScale = 1f;
                    break;
                case BtnType.fadeInMenu:
                    foreach (Image _image in _targetImages)
                        _image.DOFade(_fadeInAmount, 0.5f).SetEase(current_Ease);
                    foreach (TextMeshProUGUI _tmp in _targetTexts)
                        _tmp.DOFade(1, 0.5f).SetEase(current_Ease);
                    break;
                case BtnType.fadeOutMenu:
                    foreach (Image _image in _targetImages)
                        _image.DOFade(0, 0.5f).SetEase(current_Ease);
                    foreach (TextMeshProUGUI _tmp in _targetTexts)
                        _tmp.DOFade(0, 0.5f).SetEase(current_Ease);
                    break;
                case BtnType.setSizeBigMenu:
                    arg_RectTransform.DOScale(_targetPos, 0.5f).SetEase(current_Ease);
                    break;
                case BtnType.setSizeSmallMenu:
                    arg_RectTransform.DOScale(_targetPos, 0.5f).SetEase(current_Ease);
                    break;
                case BtnType.None:
                    break;
                default:
                    Debug.LogError("Button Function Not Setted");
                    break;
            }



        }


    }

}