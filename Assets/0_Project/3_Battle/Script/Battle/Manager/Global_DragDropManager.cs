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
        [SerializeField]
        GameObject _mousePointer;


        //saved�� Ʋ���� ���� ����� ������, _pickedorigin�� Ŭ���ؼ� ������ ������
        [SerializeField]
        BlockCase _savedCase, _pickOriginCase;


        public void BeginDragDrap()
        {
            if (_inputCamera == null)
                _inputCamera = Camera.main;
            if (_mousePointer == null)
                _mousePointer = GameObject.Find("Global_MousePointer") as GameObject;
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
                //�ð����.
                RotateProtocol(true);
                //HoldlingBlock();

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //�ݽð����.
                RotateProtocol(false);
                //HoldlingBlock();
            }


        }
        void SetMousePointerPos()
        {
            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            _mouseWorldPos += new Vector3(0, 0, 10);
            _mousePointer.transform.position = _mouseWorldPos;

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
                        PreserveData(temptCase);
                }
            }

        }
        //�����Ѵ��� ������ �ø�.
        void PreserveData(BlockCase _argCase)
        {
            _isPicked = true;
            Debug.Log(_isPicked);

            _savedCase = new BlockCase();
            _savedCase._blockInfo = new BlockInfo(_savedCase._blockInfo);
            _pickOriginCase = _argCase;

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

                    //���밢 ����� �տ� ������
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            for (int k = 0; k < YLength; k++)
                                temptTarget[Col, Row] += ArrForMakeRotate[k, Row] * temptRotate[Col, k];

                    //��ġ
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            FinalTarget[Row, Col] = temptTarget[Col, Row];
                    //�ð���� ȸ���� �˰�����.


                }
                else
                {
                    int[,] ArrForMakeRotate = new int[XLength, XLength];
                    for (int i = 0; i < XLength; i++)
                        ArrForMakeRotate[i, (XLength - i - 1)] = 1;

                    //���밢 ����� �ڿ� ������
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            for (int k = 0; k < XLength; k++)
                                temptTarget[Col, Row] += ArrForMakeRotate[Col, k] * temptRotate[k, Row];

                    //��ġ
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            FinalTarget[Row, Col] = temptTarget[Col, Row];
                    //�ð�ݴ����ȸ���� �˰�����.

                }
                FormerBlockcase = null;
                PickedBlockArr = (int[,])FinalTarget.Clone();
                // �̺κ� Ʈ�������� �ٲٱ�
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
                //�Ұ���.
                if (hit.transform.GetComponent<BlockCase>() == null || hit.transform.GetComponent<BlockCase>() == _pickOriginCase)
                {
                    BlockReset();
                }
                else if (hit.transform.GetComponent<BlockCase>())
                {
                    if (_isPicked) // �������� ��������
                    {
                        BlockCase targetCase = hit.transform.GetComponent<BlockCase>();

                        //���� �����ϸ� �ٷ� ������.
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
            if (_pickOriginCase != null && _pickOriginCase.IsEmpty)// ���ѵ� Ÿ���� + ���̽��� ������� ���.
            {
                _pickOriginCase.ResetBlock();
                _pickOriginCase.PlaceBlock();
            }
        }


    }

}