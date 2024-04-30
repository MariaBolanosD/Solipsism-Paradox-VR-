using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VRGameManager : NetworkBehaviour
{
    const int MAX_PLAYER_AMOUNT = 2;
    public static VRGameManager Instance { get; private set; }

    [SerializeField] GameObject Score_Lamp,  _bluePlayerPrefab, _redPlayerPrefab;

    public UnityEvent ClientDisconnected = new UnityEvent();

    public NetworkVariable<PlayerData> selectedPlayer;

    public enum State
    {
        Init = 0,
        SelectPlayer = 1,
        Main = 2
    }

    private NetworkVariable<State> currentState = new NetworkVariable<State>();

    private Dictionary<ulong, bool> playerReadyDictionary;


    private void Awake()
    {
        NetworkManager[] networkManagers = FindObjectsOfType<NetworkManager>();
        if (networkManagers.Length > 1)
            Destroy(networkManagers[1].gameObject);
        else
        {
            NetworkManager.Singleton.ConnectionApprovalCallback +=
                NetworkManager_ConnectionApproval;
            NetworkManager.Singleton.OnClientDisconnectCallback += NetworkManager_OnClientDisconnected;
        }

        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
        currentState.Value = State.Init;

        selectedPlayer = new NetworkVariable<PlayerData>();
    }



    private void NetworkManager_ConnectionApproval(NetworkManager.ConnectionApprovalRequest
        connectionApprovalRequest, NetworkManager.ConnectionApprovalResponse
        connectionApprovalResponse)
    {
        if (NetworkManager.Singleton.ConnectedClientsIds.Count >= MAX_PLAYER_AMOUNT)
        {
            connectionApprovalResponse.Approved = false;
            return;
        }
        connectionApprovalResponse.Approved = true;
    }

    private void ResetVariables()
    {
        playerReadyDictionary = new Dictionary<ulong, bool>();
        selectedPlayer.Value = new PlayerData
        {
            type = -1
        };
    }

    public void StartGame()
    {
        NetworkManager.Singleton.StartHost();
        ResetVariables();
        currentState.Value = State.SelectPlayer;
        LoadNetworkScene();
    }

    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void LoadInitialMenu()
    {
        NetworkManager.Singleton.Shutdown();
        SceneManager.LoadScene(State.Init.ToString());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void GoToMainGame()
    {
        currentState.Value = State.Main;
        LoadNetworkScene();
    }

    public void SpawnPlayers()
    {
        GameObject playerGO;
        foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (id == selectedPlayer.Value.playerId)
            {
                if (selectedPlayer.Value.type == 0) //it's left
                { 
                  playerGO = Instantiate(_bluePlayerPrefab);
                }
                else
                {
                    playerGO = Instantiate(_redPlayerPrefab);
                }
            }
            else
            {
                if (selectedPlayer.Value.type == 0)
                {
                    playerGO = Instantiate(_redPlayerPrefab);
                }
                else
                {
                    playerGO = Instantiate(_bluePlayerPrefab);
                }
            }
            playerGO.GetComponent<NetworkObject>().SpawnAsPlayerObject(id, true);
        }
    }

    public void SelectedPlayer(bool _left)
    {
        SelectedPlayerServerRpc(_left);
    }

    [ServerRpc(RequireOwnership = false)]
    private void SelectedPlayerServerRpc(bool _left, ServerRpcParams _params = default)
    {
        selectedPlayer.Value = new PlayerData
        {
            playerId = _params.Receive.SenderClientId,
            type = _left ? 0 : 1
        };


        playerReadyDictionary[_params.Receive.SenderClientId] = true;

        if (NetworkManager.Singleton.ConnectedClientsIds.Count < MAX_PLAYER_AMOUNT) //wait for all players
            return;

        bool allClientsReady = true;
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            if (!playerReadyDictionary.ContainsKey(clientId) || !playerReadyDictionary[clientId])
            {
                allClientsReady = false;
                break;
            }
        }

        if (allClientsReady)
        {
            GoToMainGame();
        }
    }


    private void NetworkManager_OnClientDisconnected(ulong _clientID)
    {
        switch (currentState.Value)
        {
            case State.Init:
                ClientDisconnected.Invoke();
                break;
            case State.SelectPlayer:
                if (_clientID == NetworkManager.ServerClientId)
                {
                    LoadInitialMenu();
                }
                else
                {
                    if (selectedPlayer.Value.type != -1 && selectedPlayer.Value.playerId == _clientID)
                    {
                        selectedPlayer.Value = new PlayerData
                        {
                            type = -1
                        };
                        //ClientDisconnected.Invoke();
                    }
                }
                break;
            case State.Main:
                LoadInitialMenu();
                break;
        }
    }


    private void LoadNetworkScene()
    {
        Time.timeScale = 1;
        NetworkManager.Singleton.SceneManager.LoadScene(currentState.Value.ToString(),
            LoadSceneMode.Single);
    }

}
