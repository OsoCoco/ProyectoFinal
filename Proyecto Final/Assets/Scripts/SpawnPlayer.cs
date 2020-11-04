using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnPlayer : NetworkBehaviour
{
    NetworkManager networkManager;


    Vector3 startPos = new Vector3(0, 1, 0);

    private void Start()
    {
        networkManager = GetComponent<NetworkManager>();
       //networkManager.playerSpawnMethod = Spawn();
    }

    void Spawn()
    {
        GameObject player = Instantiate(networkManager.playerPrefab, startPos, Quaternion.identity);

        //NetworkServer.SpawnWithClientAuthority();

    }
}
