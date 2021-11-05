using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ToronPuzzle.Battle;
using ToronPuzzle.Data;

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
        /// �ʿ����� ����� �����. ����� ����� �и��� ������������, 
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
        //saved�� Ʋ���� ���� ����� ������, _pickedorigin�� Ŭ���ؼ� ������ ������
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
        public void SetCurrentSceneData(BlockType _type)
        {
            _genBlockType = _type;

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
            _mouseWorldPos += new Vector3(0, 0, 20);
            _dragPointer.transform.position = _mouseWorldPos;

        }
        void OnClicked()
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
                        _pickOriginCase = temptCase.LiftBlock();
                        SetBlockOnPointer(_pickOriginCase);
                        Global_SoundManager.Instance.PlaySFX(SFXName.BlockLift);
                        Global_BlockPlaceMaster.instance.ActivateHoldingPanel(false);
                    }
                }
            }

        }
        //�����Ѵ��� ������ �ø�.
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



        BlockCase _hoveredCase;
        //���⼭�� ���� ��ϵ��� �ǿ� �ö��� �� ��ġ �׸��ڸ� ������ ��.
        void HoldingBlock()
        {

            Vector3 _mouseWorldPos = _inputCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseWorldPos, Vector3.forward, 200f);
            //Debug.DrawRay(_mouseWorldPos, Vector3.forward *15f,Color.cyan,0.5f);
            if (hit)
            {
                if (hit.transform.GetComponent<BlockCase>())
                {
                    BlockCase temptCase = hit.transform.GetComponent<BlockCase>();
                    //�̹� üŷ �ѰŸ� �׳� ��ŵ
                    if (temptCase == _hoveredCase)
                        return;
                    else
                        _hoveredCase = temptCase;

                    if (temptCase.CheckPlaceable(_savedCase._blockInfo))
                    {
                        //Global_SoundManager.Instance.PlaySFX(SFXName.BlockLift);
                        //Global_BlockPlaceMaster.instance.ActivateHoldingPanel(false);
                    }

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

                    //���밢 ����� �տ� ������
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            for (int k = 0; k < YLength; k++)
                                temptTarget[Col, Row] += ArrForMakeRotate[k, Row] * temptRotate[Col, k];

                    //��ġ
                    for (int Row = 0; Row < YLength; Row++)
                        for (int Col = 0; Col < XLength; Col++)
                            FinalTarget[Row, Col] = temptTarget[Col, Row];
                    //�ð���� ȸ���� �˰���.


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
                    //�ð�ݴ����ȸ���� �˰���.

                }
                //_pickOriginCase._blockInfo._blockShapeArr = (int[,])FinalTarget.Clone();
                _savedCase._blockInfo._blockShapeArr = (int[,])FinalTarget.Clone();
                // �̺κ� Ʈ�������� �ٲٱ�
                //m_cursor.RotateTween(spindirr);

                // ������ ������ �ʱ�ȭ
                Destroy(_HoldingObject);
                SetBlockOnPointer(_savedCase);
                Global_SoundManager.Instance.PlaySFX(SFXName.BlockRotate);

            }
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
                    OriginBlockReset();
                }
                else if (hit.transform.GetComponent<BlockCase>())
                {
                    if (_isPicked) // �������� ��������
                    {
                        BlockCase targetCase = hit.transform.GetComponent<BlockCase>();

                        //���� �����ϸ� �ٷ� ������.
                        if (targetCase.CheckPlaceable(_savedCase._blockInfo))
                        {
                            //���� ����� �״����� ��ġ �Ѵ�. ��ġ�� ���� ������
                            targetCase.PlaceBlock(_savedCase._blockInfo);
                            OriginBlockDelete();

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
            //���� ���� ���� ����ִ°� ���̻� ���� ����.
            _isPicked = false;
            _pickOriginCase = null;
            if (_savedCase != null)
            {
                _savedCase.DeleteBlock();
                Destroy(_HoldingObject);

            }
            if (Global_BlockPlaceMaster.instance != null)
            {
                Global_BlockPlaceMaster.instance.ActivateHoldingPanel(true);
                Global_BlockPlaceMaster.instance.ResetPreview();
            }
            //if (m_blockInventoryCase != null)
            //m_blockInventoryCase.ActivateInventoryPlace(false);

        }

        void OriginBlockReset()
        {
            if (_pickOriginCase != null )// ���ѵ� Ÿ���� + ���̽��� ������� ���.
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
            //������ ��Ȱ���� �� �ٸ� ���̽��� ��� ����ְ� ����� ������� ���� �ϰ� �Ⱥ������ �״�� ���д���.
            Debug.Log(_pickOriginCase.IsOnBlockPlace);

            if (_pickOriginCase != null )
            {
                if (_pickOriginCase.IsOnBlockPlace && Global_BlockPlaceMaster.instance != null)
                {
                    Global_BlockPlaceMaster.instance.RemoveBlockOnPlace((BlockCase_BlockPlace)_pickOriginCase);

                }

                _pickOriginCase.DeleteBlock();

            }

        }

    }

}
