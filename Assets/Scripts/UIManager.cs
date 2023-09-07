using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas; 
    [SerializeField] private GameObject ItemsMenuCanvas; 
    [SerializeField] private GameObject ARPositionCanvas;


    private void Start()
    {
        GameManager.Instance.OnMainMenu += ActivateMainMenu;
        GameManager.Instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.Instance.OnARPosition += ActivateARPosition;
    }


    private void ActivateMainMenu()
    {
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        MainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        MainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(1, 1, 1), 0.3f);

        ItemsMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, .3f);

        ARPositionCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        ARPositionCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
    }

    private void ActivateItemsMenu()
    {
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        MainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        MainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        ItemsMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(300, .3f);

    }

    private void ActivateARPosition()
    {
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        MainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        MainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.5f);

        ItemsMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, .3f);

        ARPositionCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ARPositionCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }
}
