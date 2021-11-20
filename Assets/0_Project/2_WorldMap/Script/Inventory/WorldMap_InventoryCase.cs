using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
namespace ToronPuzzle.WorldMap
{
    public class WorldMap_InventoryCase : BlockCase
    {
        Transform _setttingTranfrom;
        WorldMap_Inventory _worldmap_Inventory;
        RectTransform _thisRect;
        float _rectWidth;

        public void BeginInventoryCase(WorldMap_Inventory _arginventory, float _argWidth)
        {
            _worldmap_Inventory = _arginventory;
            _setttingTranfrom = GameObject.Find("WorldMap_Inventory_Content").transform;
            _rectWidth = _argWidth;
            _thisRect = GetComponent<RectTransform>();

            GetComponent<BoxCollider2D>().size = _thisRect.rect.size;
            Transform _Mask = GameObject.Find("WorldMap_Inventory_SpriteMask").transform;
            _Mask.transform.localScale = _thisRect.rect.size;
            _Mask.localPosition = new Vector2(_thisRect.rect.width * 0.5f, -_thisRect.rect.width * 0.5f);

            foreach (ModuleID _info in _worldmap_Inventory.GetModuleList())
                PlaceBlock(ModuleDic._IDModuleBlockDic[_info]);

        }

        public override bool CheckLiftable() { return true; }

        public override bool CheckPlaceable(BlockInfo blockinfo)
        {

            Debug.Log(_InfoCaseList.ContainsKey(blockinfo));
            if (blockinfo._type == BlockType.Block|| _InfoCaseList.ContainsKey(blockinfo))
                return false;
            else
                return true;
        }


        Dictionary<BlockInfo, GameObject> _InfoCaseList = new Dictionary<BlockInfo, GameObject>();

        public override void PlaceBlock(BlockInfo _argInfo)
        {
            _InfoCaseList.Add(_argInfo, 
                Global_BlockGenerator.instance.GenerateModuleOnUI(_argInfo, _setttingTranfrom, _rectWidth));

            RefreshInventory();
        }

        public void DeleteDataOnInventory(BlockInfo _argInfo)
        {
            _InfoCaseList.Remove(_argInfo);

            RefreshInventory();
        }

        void RefreshInventory()
        {

        }



    }
}