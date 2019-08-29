using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacerCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        TowerPlacer towerPlacer = other.GetComponent<TowerPlacer>();
        towerPlacer.canPlaceTower = false;
    }

    void OnTriggerExit(Collider other)
    {
        TowerPlacer towerPlacer = other.GetComponent<TowerPlacer>();
        towerPlacer.canPlaceTower = true;
    }
  
}
