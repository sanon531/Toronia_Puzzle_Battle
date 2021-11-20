using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ToronPuzzle.Battle;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle
{
    public enum BlockType
    {
        Block,Module
    }
    public class Global_DragDropManager : MonoBehaviour
    {
        
        public static Global_DragDropManager instance;
        /// <summary>
        /// 맵에서는 모듈을 만들고. 모듈의 저장과 분리가 가능해지도록, 
        /// </summary>
        BlockType _genBlockType;
        bool _isPicked;

        [SerializeField]
        Camera _inputCamera;
        [SerializeField]
        Canvas _canvas;
        Transform _dragPointer;

        GameObject _HoldingObject;

        List<GameObject> _current_Blocks = new List<GameObject>();
        //saved는 틀릭한 순간 복사된 데이터, _pickedorigin은 클릭해서 가져온 데이터
        [SerializeField]
        BlockCase _savedCase, _pickOriginCase = null;
        BlockCase _hoveredCase;



        public void BeginDragDrap()
        {
            if (_inputCamera == null)
                _inputCamera = Camera.main;

            if (_dragPointer == null)
                _dragPointer = GameObject.Find("Global_DragPointer").transform;

            if(_canvas==null)
                _canvas = GameObject.Find("Global_Canvas").GetComponent<Canvas>();
            instance = this;

        }


        SceneType _sceneType;
        public void SetCurrentSceneData(SceneType _argType){ _sceneType = _argType; }


        void Update()
        {
            SetMousePointerPos();
            FullMethod();
        }



        void SetMousePointerPos()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            _mouseWorldPos += new Vector3(0, 0, 20);
            _dragPointer.transform.position = _mouseWorldPos;

        }

        //배틀일 시 클릭 루틴.
        #region
        void FullMethod()
        {
            if (_isPicked && Input.GetMouseButton(0))
                HoldingBlock_Common();

            if (Input.GetMouseButtonDown(0))
                OnClicked_Common();

            if (Input.GetMouseButtonUp(0))
                UnClicked_Battle();
            
            //시계방향.
            if (Input.GetKeyDown(KeyCode.E))
                RotateProtocol(true);
            //반시계방향.
            if (Input.GetKeyDown(KeyCode.Q))
                RotateProtocol(false);

        }


        //클릭관련
        #region
        void OnClicked_Common()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseWorldPos, Vector3.forward,200f);

            Debug.DrawRay(_mouseWorldPos, Vector3.forward *15f,Color.cyan,0.5f);
            if (hit)
            {
                if (hit.transform.GetComponent<BlockCase>())
                {
                    //Debug.Log(hit.transform.gameObject.name);
                    BlockCase temptCase = hit.transform.GetComponent<BlockCase>();
                    //TestCaller.instance.DebugArrayShape(temptCase._blockInfo._blockShapeArr);
                    //Debug.Log("Clicked Case" + hit.collider.name);

                    if (temptCase.CheckLiftable())
                    {
                        //Debug.Log("isLiftable");
                        _pickOriginCase = temptCase.LiftBlock();
                        SetBlockOnPointer(_pickOriginCase);
                        Global_SoundManager.Instance.PlaySFX(SFXName.BlockLift);
                        Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블럭집은후UI);
                    }
                }
            }

        }
        //저장한다음 손으로 올림.
        void SetBlockOnPointer(BlockCase _argCase)
        {
            _isPicked = true;
            //Debug.Log("Preserved FroM"+_argCase.transform.name);
            //TestCaller.instance.DebugArrayShape(_pickOriginCase._blockInfo._blockShapeArr);
            _HoldingObject = Global_BlockGenerator.instance.GenerateOnPointer(_argCase._blockInfo,_dragPointer);
            _savedCase = _HoldingObject.GetComponent<BlockCase>();
            _savedCase._blockInfo = new BlockInfo(_argCase._blockInfo);
            //TestCaller.instance.DebugArrayShape(_argCase._blockInfo._blockShapeArr);
        }
        #endregion

        //블록을 들고 있을 때의 액션
        //여기서는 이제 블록들이 판에 올라갔을 때 배치 그림자를 보여줄 것.
        //모듈의 경우 기본 블럭의 배치 색이 완전히 바뀌도록 해야할듯.
        #region
        void HoldingBlock_Common()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseWorldPos, Vector3.forward, 200f);
            //Debug.DrawRay(_mouseWorldPos, Vector3.forward *15f,Color.cyan,0.5f);
            if (hit)
            {
                if (hit.transform.GetComponent<BlockCase>())
                {
                    BlockCase temptCase = hit.transform.GetComponent<BlockCase>();
                    //이미 체킹 한거면 그냥 스킵
                    if (temptCase == _hoveredCase)
                        return;
                    else
                        _hoveredCase = temptCase;
                    temptCase.CheckPlaceable(_savedCase._blockInfo);

                    if(!temptCase.IsOnBlockPlace)
                        Global_BlockPlaceMaster.instance.ResetPreview();


                }
            }

        }
        void RotateProtocol(bool spindirr)
        {
            if (_savedCase != null)
            {
                //Debug.Log(_isPicked);
                //모듈이면 못한다고 선언 
                if (_savedCase._blockInfo._type == BlockType.Module){ CantRotateAlert(); return; }

                int[,] temptRotate = (int[,])_savedCase._blockInfo._blockShapeArr.Clone();
                int XLength = temptRotate.GetLength(0);
                int YLength = temptRotate.GetLength(1);
                int[,] temptTarget = new int[XLength, YLength];
                int[,] FinalTarget = new int[YLength, XLength];

                if (spindirr)
                {
                    int[,] ArrForMakeRotate = new int[YLength, YLength];
                    for (int i = 0; i < YLength; i++)
                        ArrForMakeRotate[i, (YLength - i - 1)] = 1;

                    //역대각 행렬을 앞에 곱해줌
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            for (int k = 0; k < YLength; k++)
                                temptTarget[Col, Row] += ArrForMakeRotate[k, Row] * temptRotate[Col, k];

                    //전치
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            FinalTarget[Row, Col] = temptTarget[Col, Row];
                    //시계방향 회전의 알고리즘.


                }
                else
                {
                    int[,] ArrForMakeRotate = new int[XLength, XLength];
                    for (int i = 0; i < XLength; i++)
                        ArrForMakeRotate[i, (XLength - i - 1)] = 1;

                    //역대각 행렬을 뒤에 곱해줌
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            for (int k = 0; k < XLength; k++)
                                temptTarget[Col, Row] += ArrForMakeRotate[Col, k] * temptRotate[k, Row];

                    //전치
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            FinalTarget[Row, Col] = temptTarget[Col, Row];
                    //시계반대방향회전의 알고리즘.

                }
                //_pickOriginCase._blockInfo._blockShapeArr = (int[,])FinalTarget.Clone();
                _savedCase._blockInfo._blockShapeArr = (int[,])FinalTarget.Clone();
                // 이부분 트위닝으로 바꾸기
                //m_cursor.RotateTween(spindirr);

                // 기존의 블럭들의 초기화
                Destroy(_HoldingObject);
                SetBlockOnPointer(_savedCase);
                Global_SoundManager.Instance.PlaySFX(SFXName.BlockRotate);

            }
        }
        // 맵에서 모듈은 돌릴수 없다고 하는 것.
        void CantRotateAlert()
        {

        }

        #endregion


        //클릭을 풀었을때의 행동
        #region
        void UnClicked_Battle()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseWorldPos, Vector3.forward, 200f);
            //Debug.DrawRay(_mouseWorldPos, Vector3.forward *15f,Color.cyan,0.5f);
            if (hit)
            {
                //불가함.
                if (hit.transform.GetComponent<BlockCase>() == null || hit.transform.GetComponent<BlockCase>() == _pickOriginCase)
                {
                    OriginBlockReset();
                }
                else if (hit.transform.GetComponent<BlockCase>())
                {
                    if (_isPicked) // 세팅할지 말지정함
                    {
                        BlockCase targetCase = hit.transform.GetComponent<BlockCase>();

                        //세팅 가능하면 바로 세팅함.
                        if (targetCase.CheckPlaceable(_savedCase._blockInfo))
                        {
                            //먼저 지우고 그다음에 설치 한다. 배치의 문제 때문에
                            OriginBlockDelete();
                            targetCase.PlaceBlock(_savedCase._blockInfo);

                            //Debug.Log("Placable :"+targetCase.CheckPlaceable(_savedCase._blockInfo));
                        }
                        else
                        {
                            OriginBlockReset();
                        }

                    }


                }


            }
            else
                OriginBlockReset();

            FinishClick();
        }

        private void FinishClick()
        {
            //놓은 순간 부터 들고있는건 더이상 쓸모 없어.
            _isPicked = false;
            _pickOriginCase = null;
            if (_savedCase != null)
            {
                _savedCase.DeleteBlock();
                Destroy(_HoldingObject);

            }
            if (Global_BlockPlaceMaster.instance != null)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블럭놓은후UI);
                Global_BlockPlaceMaster.instance.ResetPreview();
            }
            //if (m_blockInventoryCase != null)
            //m_blockInventoryCase.ActivateInventoryPlace(false);

        }

        void OriginBlockReset()
        {
            if (_pickOriginCase != null )// 엄한데 타겟팅 + 케이스가 비어있을 경우.
            {
                //Debug.Log("BlockReset"+ _pickOriginCase.IsOnBlockPlace);

                if (_pickOriginCase.IsOnBlockPlace)
                    _pickOriginCase.ResetBlock(_pickOriginCase._blockInfo);
                else
                    _pickOriginCase.ResetBlock(_savedCase._blockInfo);
            }
        }
        
        void OriginBlockDelete()
        {
            //다음에 재활용할 때 다른 케이스가 들면 비어있게 만들고 비었으면 삭제 하고 안비었으면 그대로 냅둔다이.
            if (_pickOriginCase != null )
            {
                if (_pickOriginCase.IsOnBlockPlace && Global_BlockPlaceMaster.instance != null)
                {
                    //Debug.Log("+"+ _pickOriginCase._blockInfo._type);

                    if (_pickOriginCase._blockInfo._type == BlockType.Block)
                        Global_BlockPlaceMaster.instance.RemoveBlockOnPlace((BlockCase_BlockPlace)_pickOriginCase);
                    else
                        Global_BlockPlaceMaster.instance.RemoveModuleOnPlace((BlockCase_Module)_pickOriginCase);
                }

                _pickOriginCase.DeleteBlock();

            }

        }

        #endregion

        //컨베이어 케이스 관련
        #region
        public void ConveyerIsPickedOriginCase(Battle_Conveyer_Case _compare)
        {
            if (_pickOriginCase == null)
                return;

            if (_pickOriginCase == _compare)
                _pickOriginCase = null;

            return;
        }
        #endregion

        #endregion
    }

}
