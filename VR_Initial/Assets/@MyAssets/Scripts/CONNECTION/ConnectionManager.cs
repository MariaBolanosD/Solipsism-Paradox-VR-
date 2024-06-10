using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ConnectionManager : NetworkBehaviour
{
    public Transform startPositionHost;
    public Transform startPositionClient;
    public GameObject lobbyPlayer;
    public GameObject canvas;
    public GameObject suelo;
    public GameObject player_prefab;
    private bool started = false;

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        SetupGameObjects();

        GameObject playerGO = Instantiate(player_prefab, startPositionHost.position, startPositionHost.rotation);
        playerGO.GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        SetupGameObjects();
    }

    private void SetupGameObjects()
    {
        Destroy(lobbyPlayer);
        canvas.SetActive(false);
        suelo.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartHost();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartClient();
        }

        if (IsServer && !started && NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
        {
            started = true;
            // NetworkManager.Singleton.SceneManager.LoadScene("Carrera", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsClient && !IsHost)
        {
            RequestSpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void RequestSpawnPlayerServerRpc(ulong clientId, ServerRpcParams rpcParams = default)
    {
        GameObject playerGO = Instantiate(player_prefab, startPositionClient.position, startPositionClient.rotation);
        playerGO.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
    }
}