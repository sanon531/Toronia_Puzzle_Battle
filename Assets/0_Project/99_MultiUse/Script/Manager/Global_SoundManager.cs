using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Data;
using ToronPuzzle.Battle;
using UnityEngine.Audio;

namespace ToronPuzzle
{
    public class Global_SoundManager : SoundManager
    {
        [SerializeField]
        AudioMixer _masterMixer;
        public static Global_SoundManager Instance;

        [SerializeField]
        Slider _masterVolSlider, _bgmVolSlider, _fxVolSlider;
        [SerializeField]
        Toggle _masterToggle, _bgmToggle, _fxToggle;

        float multiplier =30f;



        public void BeginSoundManager()
        {
            //여기서 원래 데이터랑 대조해본 뒤 배경음을 깐다.  
            Instance = this;
            _masterMixer = Resources.Load("Master") as AudioMixer;
            SetVolumeDataOnSlider();
        }

        public void SetSoundMute()
        {

        }

        void SetVolumeDataOnSlider()
        {
            float _out;
            _masterMixer.GetFloat("_masterVolume", out _out);
            _masterVolSlider.value = Mathf.Exp(_out / multiplier) ;
            _masterVolSlider.onValueChanged.AddListener(Set_MasterVolume);
            _masterToggle.onValueChanged.AddListener(Set_MasterToggle);


            _masterMixer.GetFloat("_bgmVolume", out _out);
            _bgmVolSlider.value = Mathf.Exp(_out/ multiplier)  ;
            _bgmVolSlider.onValueChanged.AddListener(Set_BGMVolume);
            _bgmToggle.onValueChanged.AddListener(Set_BGMToggle);


            _masterMixer.GetFloat("_fxVolume", out _out);
            _fxVolSlider.value = Mathf.Exp(_out / multiplier);
            _fxVolSlider.onValueChanged.AddListener(Set_FXVolume);
            _fxToggle.onValueChanged.AddListener(Set_FXToggle);



        }

        private void Set_MasterToggle(bool _isOn)
        {
            if (_isOn)
                _masterVolSlider.value = _masterVolSlider.maxValue;
            else
                _masterVolSlider.value = _masterVolSlider.minValue;
        }
        private void Set_MasterVolume(float _changedval)
        {
            _masterMixer.SetFloat("_masterVolume",Mathf.Log10(_changedval) * multiplier);
            _masterToggle.isOn = _masterVolSlider.value> _masterVolSlider.minValue;
        }
        private void Set_BGMToggle(bool _isOn)
        {
            if (_isOn)
                _bgmVolSlider.value = _bgmVolSlider.maxValue;
            else
                _bgmVolSlider.value = _bgmVolSlider.minValue;
        }
        private void Set_BGMVolume(float _changedval)
        {
            _masterMixer.SetFloat("_bgmVolume", Mathf.Log10(_changedval) * multiplier);
            _bgmToggle.isOn = _bgmVolSlider.value > _bgmVolSlider.minValue;

        }

        private void Set_FXToggle(bool _isOn)
        {
            if (_isOn)
                _fxVolSlider.value = _fxVolSlider.maxValue;
            else
                _fxVolSlider.value = _fxVolSlider.minValue;
        }

        private void Set_FXVolume(float _changedval)
        {
            _masterMixer.SetFloat("_fxVolume", Mathf.Log10(_changedval) * multiplier);
            _fxToggle.isOn = _fxVolSlider.value > _fxVolSlider.minValue;

        }


    }
}