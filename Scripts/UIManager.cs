using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public CanvasGroup Gacha;
    public CanvasGroup Map;
    public CanvasGroup Inventory;
    public CanvasGroup Store;
    public CanvasGroup Loby;
    public CanvasGroup Navegation;


    public Image blur;
    public Button butonx1;
    public Button butonx10;
    public Image currencyPanle;
    public UICharacterGacha characterGachaPreFab;

    private void Start()
    {
        CanvasGroupChanger(false, Gacha);
        CanvasGroupChanger(false, Map);
        CanvasGroupChanger(false, Inventory);
        CanvasGroupChanger(false, Store);
        CanvasGroupChanger(true, Loby);
        CanvasGroupChanger(true, Navegation);
    }

    private void Update()
    {
       
    }

    public void CanvasGroupChanger(bool x, CanvasGroup y)
    {
        if (x)
        {
            y.alpha = 1;
            y.interactable = true;
            y.blocksRaycasts = true;
        }
        else
        {
            y.alpha = 0;
            y.interactable = false;
            y.blocksRaycasts = false;

        }
    }

    public void Navegacion(string ventana)
    {
        switch (ventana)
        {
            case "Gacha":
                CanvasGroupChanger(true, Gacha);
                CanvasGroupChanger(false, Map);
                CanvasGroupChanger(false, Inventory);
                CanvasGroupChanger(false, Store);
                CanvasGroupChanger(false, Loby);
                CanvasGroupChanger(false, Navegation);
                break;
            case "Map":
                CanvasGroupChanger(false, Gacha);
                CanvasGroupChanger(true, Map);
                CanvasGroupChanger(false, Inventory);
                CanvasGroupChanger(false, Store);
                CanvasGroupChanger(false, Loby);
                CanvasGroupChanger(false, Navegation);
                break;
            case "Inventory":
                CanvasGroupChanger(false, Gacha);
                CanvasGroupChanger(false, Map);
                CanvasGroupChanger(true, Inventory);
                CanvasGroupChanger(false, Store);
                CanvasGroupChanger(false, Loby);
                CanvasGroupChanger(false, Navegation);
                break;
            case "Store":
                CanvasGroupChanger(false, Gacha);
                CanvasGroupChanger(false, Map);
                CanvasGroupChanger(false, Inventory);
                CanvasGroupChanger(true, Store);
                CanvasGroupChanger(false, Loby);
                CanvasGroupChanger(false, Navegation);
                break;
            case "Loby":
                CanvasGroupChanger(false, Gacha);
                CanvasGroupChanger(false, Map);
                CanvasGroupChanger(false, Inventory);
                CanvasGroupChanger(false, Store);
                CanvasGroupChanger(true, Loby);
                CanvasGroupChanger(true, Navegation);
                break;
        }
    }

    public void hideGacha()
    {
        
    }
}
