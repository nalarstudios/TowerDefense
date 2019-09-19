using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTowerPlacer : MonoBehaviour
{
    public GameObject transparentTowerPrefab;
    private bool isPlacing = false;
    public GameObject[] rend;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rend = GameObject.FindGameObjectsWithTag("UnplaceableArea");
        if (rend == null)
        {
            Debug.LogError("You can place anywhere. xD Pft, you need some unplaceable areas.");
        }
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
            foreach (GameObject renderer in rend)
            {
                renderer.GetComponent<MeshRenderer>().enabled = true;
            }
            Vector3 yLock = new Vector3(worldPosition.x, 0.3f, worldPosition.z);
            Instantiate(transparentTowerPrefab, yLock, Quaternion.identity);
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
