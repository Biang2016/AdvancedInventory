using BiangLibrary.AdvancedInventory;
using UnityEngine;

public class SampleUIInventoryItem : MonoBehaviour
{
    [SerializeField]
    private SampleInventoryItemInfo SampleItemInfo;

    public IInventoryItemContentInfo ItemInfo => SampleItemInfo;
}