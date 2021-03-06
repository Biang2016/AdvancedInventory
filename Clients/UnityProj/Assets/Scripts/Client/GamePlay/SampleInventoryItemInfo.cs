﻿using System;
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
    private Sprite itemSprite_1x1;

    [SerializeField]
    private Color itemColor;

    [SerializeField]
    private bool rotatable;

    #region IInventoryItemContentInfo

    public List<GridPos> IInventoryItemContentInfo_OriginalOccupiedGridPositions => originalOccupiedGridPositions;
    public string ItemCategoryName => itemCategoryName;
    public string ItemName => itemName;
    public string ItemQuality => itemQuality;
    public string ItemBasicInfo => itemBasicInfo;
    public string ItemDetailedInfo => itemDetailedInfo;
    public Sprite ItemSprite => itemSprite;
    public Sprite ItemSprite_1x1 => itemSprite_1x1;
    public Color ItemColor => itemColor;
    public bool Rotatable => rotatable;

    #endregion
}