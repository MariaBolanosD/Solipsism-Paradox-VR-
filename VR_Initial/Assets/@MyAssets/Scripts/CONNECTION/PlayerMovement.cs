using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public static ConnectionManager connectionManager;
    public GameObject red_laser;
    public GameObject blue_laser;
    public GameObject player_camera;
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        Vector3 moveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) moveDir.z = +10f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -10f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -10f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +10f;
        float moveSpeed = 3f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        connectionManager = FindObjectOfType<ConnectionManager>();

        if (OwnerClientId == 0)
        {
            transform.position = connectionManager.startPositionHost.position;
            red_laser.SetActive(true);
            

        }
        else
        {
            transform.position = connectionManager.startPositionClient.position;
            blue_laser.SetActive(true);

        }
        if (!IsOwner) {
            return;
        }
        player_camera.SetActive(true);
    }
}
