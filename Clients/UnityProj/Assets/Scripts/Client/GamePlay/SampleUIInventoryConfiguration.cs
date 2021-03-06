﻿using System.Collections.Generic;
using BiangLibrary.AdvancedInventory;
using BiangLibrary.AdvancedInventory.UIInventory;
using BiangLibrary.DragHover;
using BiangLibrary.GameDataFormat.Grid;
using UnityEngine;

public class SampleUIInventoryConfiguration : MonoBehaviour
{
    public GameObject UIInventoryGridPrefab;
    public GameObject UIInventoryItemPrefab;
    public GameObject UIInventoryItemGridPrefab;
    public GameObject UIInventoryVirtualOccupationQuadPrefab;

    private UIInventory UIInventory;
    private UIInventoryPanel UIInventory_Panel;
    private DragProcessor<UIInventoryItem> DragProcessor_UIInventoryItem;

    public List<SampleUIInventoryItem> ItemDataList = new List<SampleUIInventoryItem>();

    public string InventoryName;
    public KeyCode ToggleKey;
    public int GridSize;
    public int Rows;
    public int Columns;
    public bool X_Mirror;
    public bool Z_Mirror;
    public bool UnlockPartialGrids;
    public int UnlockedGridCount;
    public bool DragOutDrop;
    public bool EnableScreenClamp;

    private void Start()
    {
        UIInventory_Panel = GetComponent<UIInventoryPanel>();
        InitDragProcessor();
        InitUIInventory();
        foreach (SampleUIInventoryItem UIItem in ItemDataList)
        {
            InventoryItem item = new InventoryItem(UIItem.ItemInfo, UIInventory, GridPosR.Zero);
            UIInventory.TryAddItem(item);
        }
    }

    private void InitDragProcessor()
    {
        DragProcessor_UIInventoryItem = new DragProcessor<UIInventoryItem>();
        DragProcessor_UIInventoryItem.Init(
            camera: GameManager.Instance.UICamera,
            layerMask: 1 << UIInventoryItemGridPrefab.layer,
            getScreenMousePositionHandler: (out Vector2 mouseScreenPos) =>
            {
                mouseScreenPos = Input.mousePosition;
                return true;
            },
            screenMousePositionToWorldHandler: UIInventory_Panel.UIInventoryDragAreaIndicator.GetMousePosOnThisArea,
            onBeginDrag: null,
            onCancelDrag: null);
    }

    private void InitUIInventory()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        UIInventory = new UIInventory(
            inventoryName: InventoryName,
            dragAreaIndicator: UIInventory_Panel.UIInventoryDragAreaIndicator,
            dragProcessor: DragProcessor_UIInventoryItem,
            canvasDistance: canvas.planeDistance,
            gridSize: GridSize, // UI units
            rows: Rows,
            columns: Columns,
            x_Mirror: X_Mirror,
            z_Mirror: Z_Mirror,
            unlockedPartialGrids: UnlockPartialGrids,
            unlockedGridCount: UnlockedGridCount,
            dragOutDrop: DragOutDrop,
            enableScreenClamp: EnableScreenClamp,
            enableLog: false,
            toggleUIInventoryKeyDownHandler: () => Input.GetKeyDown(ToggleKey), // Toggle uiInventory
            rotateItemKeyDownHandler: () => Input.GetKeyDown(KeyCode.R), // Rotate uiInventory item
            instantiateUIInventoryGridHandler: (parent) => Instantiate(UIInventoryGridPrefab, parent).GetComponent<UIInventoryGrid>(),
            instantiateUIInventoryItemHandler: (parent) => Instantiate(UIInventoryItemPrefab, parent).GetComponent<UIInventoryItem>(),
            instantiateUIInventoryItemGridHandler: (parent) => Instantiate(UIInventoryItemGridPrefab, parent).GetComponent<UIInventoryItemGrid>(),
            instantiateUIInventoryItemVirtualOccupationQuadHandler: (parent) => Instantiate(UIInventoryVirtualOccupationQuadPrefab, parent).GetComponent<UIInventoryVirtualOccupationQuad>()
        );

        UIInventory.ToggleDebugKeyDownHandler = () => Input.GetKeyDown(KeyCode.BackQuote); // Toggle debug log
        UIInventory.ToggleUIInventoryCallback = ToggleUIInventory; // toggle uiInventory callback
        UIInventory.ToggleDebugCallback = null;

        UIInventory_Panel.Init(UIInventory,
            delegate(UIInventoryItem item)
            {
                //Debug.Log($"On Mouse Hover UIInventoryItem {item.name}");
                UIInventory_Panel.UIInventoryItemInfoPanel.Show();
                UIInventory_Panel.UIInventoryItemInfoPanel.Initialize(item.InventoryItem.ItemContentInfo);
            },
            delegate(UIInventoryItem item)
            {
                //Debug.Log($"On Mouse Leave UIInventoryItem {item.name}");
                UIInventory_Panel.UIInventoryItemInfoPanel.Hide();
            });
        UIInventory_Panel.gameObject.SetActive(false);
        UIInventoryManager.Instance.AddInventory(UIInventory);
    }

    private void ToggleUIInventory(bool open)
    {
        UIInventory_Panel.gameObject.SetActive(open);
        if (open)
        {
            MouseHoverManager.Instance.M_StateMachine.SetState(MouseHoverManager.StateMachine.States.Inventory);
        }
        else
        {
            MouseHoverManager.Instance.M_StateMachine.ReturnToPreviousState();
        }
    }
}