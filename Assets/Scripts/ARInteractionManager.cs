using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARInteractionManager : MonoBehaviour
{
    [SerializeField] private Camera ARCamera;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject item3dModel;
    private bool isOverUI;

    private bool isInitPosition;

    private void Update()
    {
        if (isInitPosition)
        {
            Vector2 middelPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            aRRaycastManager.Raycast(middelPoint, hits, TrackableType.Planes);
            if (hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive(true);
                isInitPosition = false;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);
            if (touchOne.phase == TouchPhase.Began)
            {
                var touchPosition = touchOne.position;
                isOverUI = isTapOverUi(touchPosition);
            }

            if (touchOne.phase == TouchPhase.Moved) 
            {
                if (aRRaycastManager.Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    if (!isOverUI)
                    {
                        transform.position = hitPose.position;
                    }
                }
            }
        }
    }

    private bool isTapOverUi(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPosition.x, touchPosition.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);
        return result.Count > 0;
    }

    public GameObject Item3dModel
    {
        set
        {
            item3dModel = value;
            item3dModel.transform.position = aRPointer.transform.position;
            item3dModel.transform.parent = aRPointer.transform;
            isInitPosition = true;
        }
    }

    private void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.Instance.OnMainMenu += SetItemPosition;
    }

    private void SetItemPosition()
    {
        if (item3dModel)
        {
            item3dModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3dModel = null;
        }
    }

    public void DeleteItem()
    {
        Destroy(item3dModel);
        aRPointer.SetActive(false);
        GameManager.Instance.MainMenu();
    }
}
