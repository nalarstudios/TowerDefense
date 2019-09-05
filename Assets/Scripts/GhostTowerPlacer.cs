using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerPlacer : MonoBehaviour
{
    public GameObject transparentTowerPrefab;
    private bool isPlacing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenSpaceMousePosition = Input.mousePosition;
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(screenSpaceMousePosition);
        RaycastHit hit;
        Vector3 worldPosition = new Vector3(0, 0, 0);
        if (Physics.Raycast(ray, out hit))
        {
            worldPosition = hit.point;
        }

        if (Input.GetButtonDown("SelectTest") && !isPlacing)
        {
            Instantiate(transparentTowerPrefab, worldPosition, Quaternion.identity);
            isPlacing = true;
        }
    }

    public void Toggle()
    {
        if (!isPlacing)
        {
            isPlacing = true;
        }
        else
        {
            isPlacing = false;
        }
    }
}
