using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FurniturePlacer : MonoBehaviour
{
    public Transform placementIndicator;
    public GameObject selectionUI;

    private List<GameObject> furniture = new List<GameObject>();
    private GameObject curSelected;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        selectionUI.SetActive(false);
    }
    void Update()
    {
        if(Input.touchCount > 0 && 
            Input.touches[0].phase == TouchPhase.Began &&
            !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != null &&
                    furniture.Contains(hit.collider.gameObject))
                {
                    if (curSelected != null &&
                        hit.collider.gameObject != curSelected)
                        Select(hit.collider.gameObject);
                    else if (curSelected = null)
                    {
                        Select(hit.collider.gameObject);
                    }
                }
            }
            else Deselect();
        }
    }
    void Select (GameObject selected)
    {
        if (curSelected != null)
            ToggleSelectionVisual(curSelected, false);
        curSelected = selected;
        ToggleSelectionVisual(curSelected, true);
        selectionUI.SetActive(true);
    }
    void Deselect()
    {
        if (curSelected != null)
            ToggleSelectionVisual(curSelected, false);
        curSelected = null;
        selectionUI.SetActive(false);

    }
    void ToggleSelectionVisual(GameObject obj, bool toggle)
    {
        obj.transform.Find("Selector").gameObject.SetActive(toggle);
    }
    public void PlaceFurniture (GameObject prefab)
    {
        GameObject obj = Instantiate(prefab, placementIndicator.position, Quaternion.identity);
        furniture.Add(obj);
        //Select the Object
    }
}