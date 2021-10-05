using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


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
        GameObject _mousePointer;

        GraphicRaycaster m_raycaster;
        PointerEventData m_pointerData;



        public void BeginDragDrap()
        {
            if (_inputCamera == null)
                _inputCamera = Camera.main;
            if (_mousePointer == null)
                _mousePointer = GameObject.Find("MousePointer") as GameObject;

            m_raycaster = _mousePointer.GetComponent<GraphicRaycaster>();
            m_pointerData = _mousePointer.GetComponent<PointerEventData>();

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
            m_pointerData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_raycaster.Raycast(m_pointerData, results);
            if (results.Count > 0)
            {
                GameObject choosed = results[0].gameObject;
                if (choosed.GetComponent<BlockCase>() != null)
                {
                    BlockCase temptCase = choosed.GetComponent<BlockCase>();

                    if (choosed.GetComponent<BlockCase>().CheckLiftable())
                        PreserveData(temptCase);
                }

            }


        }
        void PreserveData(BlockCase target)
        {
            _isPicked = true;

        }

        void HoldingBlock()
        {


        }

        void RotateProtocol(bool spindirr)
        {
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
                FormerBlockcase = null;
                PickedBlockArr = (int[,])FinalTarget.Clone();
                // �̺κ� Ʈ�������� �ٲٱ�
                //m_cursor.RotateTween(spindirr);
                m_cursor.blockData.blockGenerator.GeneratingBlockOnCursor(PickedBlockElement, PickedBlockArr, BlockPerSize);
            }
        }
    }

}
