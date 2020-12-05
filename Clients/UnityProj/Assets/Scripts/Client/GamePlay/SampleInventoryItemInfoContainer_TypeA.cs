using BiangStudio.AdvancedInventory;
using UnityEngine;

public class SampleInventoryItemInfoContainer_TypeA : InventoryItemInfoContainer
{
    [SerializeField]
    private SampleInventoryItemInfo SampleItemInfo;

    public override IInventoryItemContentInfo ItemInfo => SampleItemInfo;
}