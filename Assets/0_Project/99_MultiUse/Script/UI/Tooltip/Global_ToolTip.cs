using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ToronPuzzle.Event;

namespace ToronPuzzle.UI
{

    public class Global_ToolTip : UI_Object, IGameListenerUI
    {
        public static Global_ToolTip instance;
        [SerializeField]
        Camera _currentCamera;
        [SerializeField]
        GameObject _tooltipObj;
        [SerializeField]
        RectTransform _canvasRect,_tooltip_rect;
        [SerializeField]
        TextMeshProUGUI _title, _content;
        Vector3 _worldRUPos ;
        float _canvaslocalScale;

        public void BeginGlobalTooltip()
        {
        }

        //약간의 딜레이를 준채로 하고싶음.
        public void DisableTooltip()
        {
            _tooltipObj.SetActive(false);

        }

        public void SetToolTipData(string _arg_title,string _arg_Content)
        {
            _tooltipObj.SetActive(true);
            _title.SetText(_arg_title);
            _content.SetText(_arg_Content);
        }




        private void Update()
        {
            SetMousePointerPos();
        }

        void SetMousePointerPos()
        {
            Vector3 _worldMPos = _currentCamera.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = _worldMPos + new Vector3(0, 0, 10);
            Vector3 _half_Size = new Vector3(_tooltip_rect.sizeDelta.x * _canvaslocalScale * 0.5f, _tooltip_rect.sizeDelta.y * _canvaslocalScale * 0.5f);

            //툴팁 가두기 술법
            Vector3 _localpos = new Vector3(
                Mathf.Clamp(_half_Size.x + _worldMPos.x, _half_Size.x - _worldRUPos.x, _worldRUPos.x - (_half_Size.x)),
                Mathf.Clamp(_half_Size.y + _worldMPos.y, _half_Size.y - _worldRUPos.y, _worldRUPos.y - (_half_Size.y))
                );

            _tooltipObj.transform.position = _localpos;

            //Vector3 _rect_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition +new Vector3(localx, localy) ); 
            //tooltip_rect.position = _rect_Pos;


        }

        public void AssignGameListener()
        {
            instance = this;
            _worldRUPos = Global_CanvasData.CanvasData.RUAchorPos;
            _tooltip_rect = _tooltipObj.GetComponent<RectTransform>();
            _canvaslocalScale = _canvasRect.localScale.x;

        }
    }

}
