using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

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
        }
    }
}
