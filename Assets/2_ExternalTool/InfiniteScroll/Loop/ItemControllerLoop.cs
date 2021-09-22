using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(InfiniteScroll))]
public class ItemControllerLoop : UIBehaviour, IInfiniteScrollSetup
{
    [SerializeField]
    ScrollRect m_scrollRect;
 


    protected override void Start()
    {
       
    }

    private bool isSetuped = false;

	public void OnPostSetupItems()
	{
		GetComponentInParent<ScrollRect>().movementType = ScrollRect.MovementType.Unrestricted;
		isSetuped = true;
	}

	public void OnUpdateItem(int itemCount, GameObject obj)
	{
		if(isSetuped == true) return;

		//var item = obj.GetComponentInChildren<BlockConveyCase>();
		//item.UpdateItem(itemCount);
	}

    
}
