using BiangLibrary.AdvancedInventory.UIInventory;
using BiangLibrary.DragHover;
using BiangLibrary.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public Camera MainCamera;
    public Camera UICamera;

    public LayerMask DragAreaMask;

    private void Awake()
    {
        DragManager.Instance.Awake();
        MouseHoverManager.Instance.Awake();
        DragManager.Instance.Init(
            dragKeyDownHandler: () => Input.GetMouseButtonDown(0),
            dragKeyUpHandler: () => Input.GetMouseButtonUp(0),
            logErrorHandler: Debug.LogError,
            dragAreaLayerMask: DragAreaMask.value);
        MouseHoverManager.Instance.Init(
            hoverKeyDownHandler: () => Input.GetMouseButtonDown(0),
            hoverKeyUpHandler: () => Input.GetMouseButtonUp(0),
            getMousePositionHandler: () => Input.mousePosition
        );
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F10))
        {
            ReloadGame();
            return;
        }

        UIInventoryManager.Instance.Update(Time.deltaTime);
        DragManager.Instance.Update(Time.deltaTime);
        MouseHoverManager.Instance.Update(Time.deltaTime);
    }

    void LateUpdate()
    {
    }

    void FixedUpdate()
    {
    }

    void ShutDown()
    {
        UIInventoryManager.Instance.ShutDown();
    }

    public void ReloadGame()
    {
        UIInventoryManager.Instance.ShutDown();
        DragManager.Instance.ShutDown();
        SceneManager.LoadScene("MainScene");
    }
}