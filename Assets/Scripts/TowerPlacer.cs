using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;
    public bool canPlaceTower = true;
    public GameObject wallet;
    // Use this for initialization
    void Start ()
    {
        wallet = GameObject.FindWithTag("Wallet");
        if (wallet == null)
        {
            Debug.LogError("You forgot wallet you Dingus!");
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
        if (Physics.Raycast(ray, out hit))
        {
            worldPosition = hit.point;
        }
        Vector3 yLock = new Vector3(worldPosition.x,0.3f,worldPosition.z);
        
        if (Input.GetButtonDown("Placer"))
        {
            Wallet walletComponent = wallet.GetComponent<Wallet>();
            if (canPlaceTower && walletComponent.currency >= 1)
            {
                Instantiate(towerPrefab, yLock, Quaternion.identity);
                walletComponent.currency--;
                Destroy(gameObject);
            }
        }
        
        
              
    }
}
