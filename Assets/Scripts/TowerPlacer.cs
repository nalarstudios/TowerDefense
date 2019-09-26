﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    private bool canPlaceTower = true;
    public GameObject wallet;
    public GameObject ghostTowerPlacer;
    public GameObject[] rend;
    // Use this for initialization
    void Start ()
    {
        wallet = GameObject.FindWithTag("Wallet");
        if (wallet == null)
        {
            Debug.LogError("You forgot wallet you Dingus!");
        }
        ghostTowerPlacer = GameObject.FindWithTag("GhostTowerPlacer");
        if (ghostTowerPlacer == null)
        {
            Debug.LogError("You forgot the GhostTowerPlacer tag ya Dingus!");
        }
        rend = GameObject.FindGameObjectsWithTag("UnplaceableArea");
        if (rend == null)
        {
            Debug.LogError("You can place anywhere. xD Pft, you need some unplaceable areas.");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 screenSpaceMousePosition = Input.mousePosition;
        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(screenSpaceMousePosition);
        RaycastHit hit;
        Vector3 worldPosition = new Vector3(0, 0, 0);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            worldPosition = hit.point;
        }
        Vector3 yLock = new Vector3(worldPosition.x,0.3f,worldPosition.z);
        
        if (Input.GetButtonDown("Placer"))
        {
            Wallet walletComponent = wallet.GetComponent<Wallet>();
            GhostTowerPlacer setGhostTower = ghostTowerPlacer.GetComponent<GhostTowerPlacer>();
            if (canPlaceTower && walletComponent.currency >= 1)
            {
                foreach (GameObject renderer in rend)
                {
                    renderer.GetComponent<MeshRenderer>().enabled = false;
                }
                Instantiate(towerPrefab, yLock, Quaternion.identity);
                walletComponent.currency--;
                Destroy(gameObject);
                setGhostTower.Toggle();
            }
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            foreach (GameObject renderer in rend)
            {
                renderer.GetComponent<MeshRenderer>().enabled = false;
            }
            Destroy(gameObject);
            GhostTowerPlacer setGhostTower = ghostTowerPlacer.GetComponent<GhostTowerPlacer>();
            setGhostTower.Toggle();
        }
        
              
    }
    private void OnTriggerEnter(Collider other)
    {
        canPlaceTower = false;
        print(other.name + " Entered " + gameObject.name);
    }
    private void OnTriggerStay(Collider other)
    {
        canPlaceTower = false;
    }
    private void OnTriggerExit(Collider other)
    {
        canPlaceTower = true;
        print(other.name + " Left " + gameObject.name);
    }
}
