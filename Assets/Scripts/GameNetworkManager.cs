using UnityEngine;
using Mirror;
using UnityEngine.Tilemaps;

public class GameNetworkManager : NetworkManager
{
    public Grid grid;
    public GameObject mapPrefab;

    GameObject map;

    override public void OnStartServer() {
        // Create the map
        map = Instantiate(mapPrefab, Vector2.zero, Quaternion.identity, grid.transform);

        // Initialize the camera
        Util.GetCameraController().Init(map);
    }

    override public void OnStopServer() {
        // Clean up map
        Destroy(map);

        // Reset the camera
        Util.GetCameraController().Reset();
    }
}
