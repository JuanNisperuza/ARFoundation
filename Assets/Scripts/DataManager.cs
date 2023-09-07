using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject ButtonContainer;
    [SerializeField] private ItemButtonManager itemButtonManager;
    [SerializeField] private List<Item> items = new List<Item>();

    private void Start()
    {
        GameManager.Instance.OnItemsMenu += CreateButtons;
    }

    private void CreateButtons()
    {
        foreach (var item in items)
        {
            ItemButtonManager itemButton;
            itemButton = Instantiate(itemButtonManager, ButtonContainer.transform);
            itemButton.ItemName = item.name;
            itemButton.ItemDescription = item.Description;
            itemButton.ItemImage = item.Image;
            itemButton.Item3dModel = item.Item3DModel;
        }

        GameManager.Instance.OnItemsMenu -= CreateButtons;
    }
}
