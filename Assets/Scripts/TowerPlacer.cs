using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GhostTowerPlacer))]
public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
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
        Vector3 yLock = new Vector3(worldPosition.x,0.3f,worldPosition.z);
        print(worldPosition);
        
        if (Input.GetButtonDown("Placer"))
        {
            GhostTowerPlacer ghostTowerPlacer = GetComponent<GhostTowerPlacer>();
            if (ghostTowerPlacer.isShowingGhostTower)
            {
                Instantiate(towerPrefab, yLock, Quaternion.identity);
                ghostTowerPlacer.isShowingGhostTower = false;
            }
        }
        
        
              
    }
}
