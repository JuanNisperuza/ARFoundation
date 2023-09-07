using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemButtonManager : MonoBehaviour
{

    private ARInteractionManager interactionManager;
    private string itemName;
    public string ItemName
    {
        set
        {
            itemName = value;
        }
    }

    private string itemDescription;

    public string ItemDescription
    {
        set => itemDescription = value;
    }

    private GameObject item3dmodel;

    public GameObject Item3dModel
    {
        set => item3dmodel = value;
    }

    private Sprite itemImage;

    public Sprite ItemImage
    {
        set => itemImage = value;
    }

    private void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemDescription;

        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.Instance.ARPosition);
        button.onClick.AddListener(Create3dModel);

        interactionManager = FindAnyObjectByType<ARInteractionManager>();
    }

    private void Create3dModel()
    {
       interactionManager.Item3dModel = Instantiate(item3dmodel);
    }
}
