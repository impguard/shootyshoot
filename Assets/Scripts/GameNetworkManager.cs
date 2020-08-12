using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameNetworkManager : NetworkManager
{
    public Grid grid;
    public GameObject map;

    override public void OnStartServer() {
        Instantiate(map, Vector2.zero, Quaternion.identity, grid.transform);
    }
}
