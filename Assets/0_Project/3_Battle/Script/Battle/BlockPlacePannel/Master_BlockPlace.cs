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
        [ReadOnly] [SerializeField] int _maxX = 4;
        [ReadOnly] [SerializeField] int _maxY = 6;
        float _currentHeigth, _occupyHeigth, _widthInterval, _heightInterval = 0;
        float _cellSizeY = 0;
        Vector3 _showPos, _hidePos = new Vector3();
        GameObject Dot, _placeCellPrefab,_bonusLine,_bonusFull;
        string _placingCellAddress = "BlockPlace/";
        string _placingCellSkin , _bonusSkin;

        [SerializeField] SpriteRenderer _placingSprite = default;
        public Transform _cellHolder;
        public Transform _blockHolder;
        public Transform _bonusHolder;

        Battle_BlockCalculator _blockCalculator;

        Vector2 _screenSize;
        Battle_PlacingCell[,] placingCellArray;

        List<BlockCase_BlockPlace> _placedBlocks = new List<BlockCase_BlockPlace>();

        //시작 초기화 관련
        #region
        //BattleInitialtor 에 의해 선언된다.
        public void BeginBlockPlace(int argX, int argY, string argCellSkin,string argBnsSkin)
        {
            _blockCalculator = GetComponent<Battle_BlockCalculator>();
            _placingCellSkin = _placingCellAddress;
            _placingCellSkin += argCellSkin;
            _bonusSkin = _placingCellAddress; ;
            _bonusSkin += argBnsSkin;

            _maxX = argX;
            _maxY = argY;
            instance = this;
            SetBlockPlacePos();
            SetBlockCellOnPannel();
            SetBonusOnPannel();
            Dot = Resources.Load("Debug/Dot") as GameObject;

        }

        private void SetBlockPlacePos()
        {
            if (Master_Battle.CanvasData._screenWorldSize != null)
            {
                _placeCellPrefab = Resources.Load(_placingCellSkin) as GameObject;
                //배치 판의 사이즈 조절 및 위치 설정
                Vector2 LDAnchor = Master_Battle.CanvasData.LDAchorPos;

                _screenSize = Master_Battle.CanvasData._screenWorldSize;
                _currentHeigth = _screenSize.y / 2;
                _occupyHeigth = _currentHeigth * 0.9f;
                _heightInterval = _occupyHeigth / (2 * _maxY);
                _cellSizeY = 2 * _heightInterval;
                _showPos = new Vector3(LDAnchor.x + (_maxX + 1) * _cellSizeY * 0.5f, LDAnchor.y + _currentHeigth * 0.5f);
                _hidePos = new Vector3(LDAnchor.x - (_maxX + 1) * _cellSizeY * 0.5f, LDAnchor.y + _currentHeigth * 0.5f);

                Master_Battle.Data_OnlyInBattle._cellsize = new Vector2(_cellSizeY, _cellSizeY);

                transform.position = _showPos;
                _placingSprite.transform.localScale = new Vector2((-LDAnchor.x + _showPos.x) * 2, _screenSize.y / 2);

            }
            else
                Debug.LogError("BattleUIAnchor Didn't Setted");

        }
        public Vector3 GetCellPosByOrder(Vector2Int _pos)
        {
            //Debug.Log(placingCellArray[_pos.x, _pos.y].transform.position);
            return placingCellArray[_pos.x, _pos.y].transform.position;
        }

        /// <summary>
        /// 3
        /// 2
        /// 1
        /// 0 123 
        /// 과 같은 순서로 작동한다.
        /// </summary>
        void SetBlockCellOnPannel()
        {
            Vector2 LUAnchor = Master_Battle.CanvasData.LDAchorPos;
            Vector2 firstSpot = new Vector3(LUAnchor.x + (_cellSizeY), LUAnchor.y + (_heightInterval * 1.5f));
            placingCellArray = new Battle_PlacingCell[_maxX, _maxY];

            for (int i_y = 0; i_y < _maxY; i_y++)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    Vector2 targetpos = firstSpot + new Vector2(j_x * _cellSizeY, i_y * _cellSizeY);
                    GameObject temptPlacingCell = Instantiate(_placeCellPrefab, targetpos, Quaternion.identity, _cellHolder);
                    string _name = j_x.ToString();
                    _name += i_y.ToString();
                    temptPlacingCell.name = _name;
                    temptPlacingCell.transform.localScale = new Vector2(_cellSizeY, _cellSizeY);
                    temptPlacingCell.GetComponent<Battle_PlacingCell>().SetInitialData(new Vector2Int(j_x, i_y));
                    placingCellArray[j_x, i_y] = temptPlacingCell.GetComponent<Battle_PlacingCell>();

                }
            }



        }

        void SetBonusOnPannel()
        {
            Vector2 LUAnchor = Master_Battle.CanvasData.LDAchorPos;
            Vector2 firstSpot = new Vector3(LUAnchor.x + (_cellSizeY), LUAnchor.y + (_heightInterval * 1.5f));
            _bonusLine = Resources.Load(_bonusSkin+"Line") as GameObject;
            _bonusFull = Resources.Load(_bonusSkin + "Full") as GameObject;

            //x축(세로보너스들)의 보너스 블럭 세팅.
            for (int i_x = 0; i_x < _maxX; i_x++)
            {
                Vector2 targetpos = new Vector3(firstSpot.x + i_x* _cellSizeY, firstSpot.y - 1.25f* _heightInterval, -1);
                GameObject bnsLine= Instantiate(_bonusLine, targetpos, Quaternion.identity, _bonusHolder);
                _blockCalculator._bonusXColumnLines.Add(bnsLine);
                bnsLine.transform.localScale = new Vector2(_cellSizeY * 1f, _cellSizeY * 0.5f);
                Transform bns_child = bnsLine.transform.GetChild(0);
                bns_child.localPosition = new Vector2(0, 2 * (_cellSizeY * (_maxY + 2.4f)));
            }

            for (int i_y = 0; i_y < _maxY; i_y++)
            {
                Vector2 targetpos = new Vector3(firstSpot.x - 0.75f * _cellSizeY, firstSpot.y + (_cellSizeY * i_y), -1);
                GameObject bnsLine = Instantiate(_bonusLine, targetpos, Quaternion.identity, _bonusHolder);
                _blockCalculator._bonusYRowLines.Add(bnsLine);
                bnsLine.transform.rotation = Quaternion.Euler(0, 0, -90);
                bnsLine.transform.localScale = new Vector2(_cellSizeY * 1f, _cellSizeY * 0.5f);
                Transform bns_child = bnsLine.transform.GetChild(0);
                bns_child.localPosition = new Vector2(0, 2 * (_cellSizeY * (_maxX + 2f)));

            }

            firstSpot = new Vector3(LUAnchor.x + (_cellSizeY * 0.25f), LUAnchor.y + (_heightInterval * 0.25f));
            GameObject bnsFull = Instantiate(_bonusFull, firstSpot, Quaternion.identity, _bonusHolder);
            _blockCalculator.PerfectSetting = bnsFull;
            bnsFull.transform.localScale = new Vector2(_cellSizeY*0.5f, _cellSizeY * 0.5f);
            Transform bns_LU = bnsFull.transform.GetChild(1);
            bns_LU.localPosition = new Vector2(0, 2 * (_cellSizeY * (_maxY + 2.4f)));
            Transform bns_RD = bnsFull.transform.GetChild(2);
            bns_RD.localPosition = new Vector2(2 * (_cellSizeY * (_maxX + 2f)),0);
            Transform bns_RU = bnsFull.transform.GetChild(3);
            bns_RU.localPosition = new Vector2(2 * (_cellSizeY * (_maxX + 2f)), 2 * (_cellSizeY * (_maxY + 2.4f)));
            _blockCalculator._fullFXpos = ((Vector3)firstSpot + bns_LU.position + bns_RD.position + bns_RU.position)/4;

        }

        #endregion



        public void AddBlockOnPlace(BlockCase_BlockPlace _Block)
        {
            _placedBlocks.Add(_Block);
        }
        public void RemoveBlockOnPlace(BlockCase_BlockPlace _Block)
        {
            _placedBlocks.Remove(_Block);
        }
        public void ActivateHoldingPanel(bool turnOn)
        {
            if (turnOn)
                foreach (BlockCase_BlockPlace _Block in _placedBlocks)
                    _Block.ResetBlock();
            else
                foreach (BlockCase_BlockPlace _Block in _placedBlocks)
                    _Block.LiftBlock();

        }

        
    }

}
