using UnityEditor;
using UnityEngine;

/// <summary>
/// Globally toggles the MeshRenderer component all GameObjects tagged as "UnplaceableArea" to be on/off.
/// </summary>
static class UnplaceableAreaToggler
{
    private static bool meshRenderersAreEnabled = false;

    [MenuItem("GameObject/Toggle Unplaceable Areas")]
    private static void ToggleUnplaceableAreas()
    {
        GameObject[] unplaceableAreas = GameObject.FindGameObjectsWithTag("UnplaceableArea");
        if (meshRenderersAreEnabled)
        {
            foreach (GameObject unplaceableArea in unplaceableAreas)
            {
                unplaceableArea.GetComponent<MeshRenderer>().enabled = false;
            }
            meshRenderersAreEnabled = false;
        }
        else
        {
            foreach (GameObject unplaceableArea in unplaceableAreas)
            {
                unplaceableArea.GetComponent<MeshRenderer>().enabled = true;
            }
            meshRenderersAreEnabled = true;
        }
    }
}