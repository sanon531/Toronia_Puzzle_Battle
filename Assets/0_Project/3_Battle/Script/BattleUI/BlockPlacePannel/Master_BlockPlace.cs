using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Master_BlockPlace : MonoBehaviour
    {
        public static Master_BlockPlace instance;

        public int _maxX = 4;
        public int _maxY = 6;
        float _currentHeigth, _occupyHeigth, _widthInterval, _heightInterval = 0;
        float _cellSizeY = 0;
        Vector3 _showPos, _hidePos = new Vector3();
        GameObject Dot,_placeCellPrefab;

        [SerializeField] SpriteRenderer _placingSprite;
        [SerializeField] Transform _cellHolder;
        [SerializeField] Vector2 _screenSize;

        Battle_PlacingCell[,] placingCellArray;


        private void Awake()
        {
            instance = this;

        }
        void Start()
        {
            SetBlockPlacePos();
            SetBlockCellOnPannel();
        }



        private void SetBlockPlacePos()
        {
            if (Master_Battle.CanvasData._screenWorldSize != null)
            {
                Dot = Resources.Load("Debug/Dot") as GameObject;
                _placeCellPrefab = Resources.Load("BlockPlace/PlacingCell") as GameObject;
                //배치 판의 사이즈 조절 및 위치 설정
                Vector2 LUAnchor = Master_Battle.CanvasData.LDAchorPos;

                _screenSize = Master_Battle.CanvasData._screenWorldSize;
                _currentHeigth = _screenSize.y / 2;
                _occupyHeigth = _currentHeigth * 0.9f;
                _heightInterval = _occupyHeigth / (2 * _maxY);
                _cellSizeY = 2 * _heightInterval;
                _showPos = new Vector3(LUAnchor.x + (_maxX + 1) * _cellSizeY * 0.5f, LUAnchor.y + _currentHeigth * 0.5f);
                _hidePos = new Vector3(LUAnchor.x - (_maxX + 1) * _cellSizeY * 0.5f, LUAnchor.y + _currentHeigth * 0.5f);

                transform.position = _showPos;
                _placingSprite.transform.localScale = new Vector2((-LUAnchor.x + _showPos.x)*2, _screenSize.y/2);

            }
            else
                Debug.LogError("BattleUIAnchor Didn't Setted");

        }



        /// <summary>
        /// 3
        /// 2
        /// 1
        /// 0 123 
        /// 과 같은 순서로 작동한다.
        /// </summary>
        public void SetBlockCellOnPannel()
        {
            Vector2 LUAnchor = Master_Battle.CanvasData.LDAchorPos;
            Vector2 firstSpot = new Vector3(LUAnchor.x + (_cellSizeY ), LUAnchor.y + (_heightInterval *1.5f));
            placingCellArray = new Battle_PlacingCell[_maxX, _maxY];

            for (int i_y = 0; i_y < _maxY; i_y++)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    Vector2 targetpos = firstSpot + new Vector2(j_x* _cellSizeY, i_y* _cellSizeY);
                    GameObject temptPlacingCell = Instantiate(_placeCellPrefab, targetpos, Quaternion.identity, _cellHolder);
                    temptPlacingCell.transform.localScale = new Vector2(_cellSizeY, _cellSizeY);
                    //temptPlacingCell.GetComponent<Battle_PlacingCell>().SetInitialData();
                    placingCellArray[j_x, i_y] = temptPlacingCell.GetComponent<Battle_PlacingCell>();

                }
            }



        }


        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {

        }
    }

}
