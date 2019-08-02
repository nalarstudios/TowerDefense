using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {
    public GameObject towerPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Placer"))
        {
            Vector3 screenSpaceMousePosition = Input.mousePosition;
            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(screenSpaceMousePosition);
            RaycastHit hit;
            Vector3 worldPosition = new Vector3(0,0,0);
            if (Physics.Raycast(ray, out hit))
            {
                worldPosition = hit.point;
            }
            print(worldPosition);

            GameObject aTower = new GameObject();

            GameObject bTower = new GameObject();
            Instantiate(towerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
