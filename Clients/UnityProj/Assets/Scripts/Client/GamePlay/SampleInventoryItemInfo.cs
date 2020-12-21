using System;
using UnityEngine;
using System.Collections.Generic;
using BiangLibrary.AdvancedInventory;
using BiangLibrary.GameDataFormat.Grid;

[Serializable]
public class SampleInventoryItemInfo : IInventoryItemContentInfo
{
    [SerializeField]
    private List<GridPos> originalOccupiedGridPositions = new List<GridPos>();

    [SerializeField]
    private string itemCategoryName;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private string itemQuality;

    [SerializeField]
    private string itemBasicInfo;

    [SerializeField]
    private string itemDetailedInfo;

    [SerializeField]
    private Sprite itemSprite;

    [SerializeField]
    private Color itemColor;

    #region IInventoryItemContentInfo

    public List<GridPos> IInventoryItemContentInfo_OriginalOccupiedGridPositions => originalOccupiedGridPositions;
    public string ItemCategoryName => itemCategoryName;
    public string ItemName => itemName;
    public string ItemQuality => itemQuality;
    public string ItemBasicInfo => itemBasicInfo;
    public string ItemDetailedInfo => itemDetailedInfo;
    public Sprite ItemSprite => itemSprite;
    public Color ItemColor => itemColor;

    #endregion
}