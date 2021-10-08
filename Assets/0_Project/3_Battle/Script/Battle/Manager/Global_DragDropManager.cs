using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ToronPuzzle.Battle;

namespace ToronPuzzle
{
    public class Global_DragDropManager : MonoBehaviour
    {
        // Update is called once per frame
        public static Global_DragDropManager instance;
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
        BlockCase _savedCase, _pickOriginCase;


        public void BeginDragDrap()
        {
            if (_inputCamera == null)
                _inputCamera = Camera.main;

            if (_dragPointer == null)
                _dragPointer = GameObject.Find("Global_DragPointer").transform;

            if(_canvas==null)
                _canvas = GameObject.Find("Global_Canvas").GetComponent<Canvas>();


        }


        void Update()
        {
            SetMousePointerPos();


            if (_isPicked && Input.GetMouseButton(0))
            {
                HoldingBlock();
            }

            if (Input.GetMouseButtonDown(0))
                OnClicked();
            if (Input.GetMouseButtonUp(0))
                UnClicked();

            if (Input.GetKeyDown(KeyCode.E))
            {
                //시계방향.
                RotateProtocol(true);
                //HoldlingBlock();

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //반시계방향.
                RotateProtocol(false);
                //HoldlingBlock();
            }


        }
        void SetMousePointerPos()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            _mouseWorldPos += new Vector3(0, 0, 20);
            _dragPointer.transform.position = _mouseWorldPos;

        }
        void OnClicked()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseWorldPos, Vector3.forward,200f);

            //Debug.DrawRay(_mouseWorldPos, Vector3.forward *15f,Color.cyan,0.5f);
            if (hit)
            {
                if (hit.transform.GetComponent<BlockCase>())
                {
                    Debug.Log(hit.transform.gameObject.name);
                    BlockCase temptCase = hit.transform.GetComponent<BlockCase>();

                    Debug.Log(temptCase.gameObject.transform.position);

                    if (temptCase.CheckLiftable())
                        PreserveData(temptCase.LiftBlock());
                }
            }

        }
        //저장한다음 손으로 올림.
        void PreserveData(BlockCase _argCase)
        {
            _isPicked = true;
            //Debug.Log(_isPicked);
            _pickOriginCase = _argCase;
            _HoldingObject = Global_BlockGenerator.instance.GenerateOnPointer(_argCase._blockInfo,_dragPointer);
            _savedCase = _HoldingObject.GetComponent<BlockCase>();
        }

        void HoldingBlock()
        {


        }

        void RotateProtocol(bool spindirr)
        {/*
            if (PickedBlockcase != null)
            {
                int[,] temptRotate = (int[,])PickedBlockArr.Clone();
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
                FormerBlockcase = null;
                PickedBlockArr = (int[,])FinalTarget.Clone();
                // 이부분 트위닝으로 바꾸기
                //m_cursor.RotateTween(spindirr);
                m_cursor.blockData.blockGenerator.GeneratingBlockOnCursor(PickedBlockElement, PickedBlockArr, BlockPerSize);
            }*/
        }

        void UnClicked()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseWorldPos, Vector3.forward, 200f);
            //Debug.DrawRay(_mouseWorldPos, Vector3.forward *15f,Color.cyan,0.5f);
            if (hit)
            {
                //불가함.
                if (hit.transform.GetComponent<BlockCase>() == null || hit.transform.GetComponent<BlockCase>() == _pickOriginCase)
                {
                    BlockReset();
                }
                else if (hit.transform.GetComponent<BlockCase>())
                {
                    if (_isPicked) // 세팅할지 말지정함
                    {
                        BlockCase targetCase = hit.transform.GetComponent<BlockCase>();

                        //세팅 가능하면 바로 세팅함.
                        if (targetCase.CheckPlaceable(_savedCase._blockInfo))
                        {
                            targetCase.PlaceBlock(_savedCase._blockInfo);
                        }
                        else
                        {
                            BlockReset();
                        }
                        
                    }


                }


            }


            //Destroy(_HoldingObject);
        }

        private void FinishClick()
        {
            _isPicked = false;
            _savedCase.DeleteBlock();
            //m_cursor.OnOffBlock(false);
            //PickedBlockArr = null;
            if (Master_BlockPlace.instance != null)
                Master_BlockPlace.instance.ActivateHoldingPanel(true);
            //if (m_blockInventoryCase != null)
                //m_blockInventoryCase.ActivateInventoryPlace(false);

        }

        void BlockReset()
        {
            if (_pickOriginCase != null && _pickOriginCase.IsEmpty)// 엄한데 타겟팅 + 케이스가 비어있을 경우.
            {
                _pickOriginCase.ResetBlock();
                _pickOriginCase.PlaceBlock();
            }
            

        }


    }

}
