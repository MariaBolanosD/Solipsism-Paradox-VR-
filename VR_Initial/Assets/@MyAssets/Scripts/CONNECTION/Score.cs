using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Score : NetworkBehaviour
{
    public static Score Instance;

    public NetworkVariable<int> redScore = new NetworkVariable<int>(0); // left
    public NetworkVariable<int> blueScore = new NetworkVariable<int>(0); // right
    public NetworkVariable<float> timer = new NetworkVariable<float>(10);


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        if (IsServer)
            VRGameManager.Instance.SpawnPlayers();

    }

    void FixedUpdate()
    {
        if (!IsServer)
            return;


        if (timer.Value >= 0)
        {
            timer.Value -= Time.deltaTime;
        }
        else //time's up
        {
            timer.Value = 0;

            if (redScore.Value > blueScore.Value)
            {
                // RED WINS
            }
            else if (blueScore.Value > redScore.Value)
            {
                // BLUE WINS
            }
            else
            {
                // TIE
            }
            StartCoroutine(PauseGame()); //Pausa
        }
    }

    private IEnumerator PauseGame()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }

    public void ScoredGoal(string _direction) // Esto ser�a el score cuando se dispara a la bola por cada jugador para aumentar el score.
    {

        if (_direction == "Right")
        {
            blueScore.Value++;

        }
        else if (_direction == "Left")
        {
            redScore.Value++;
        }
    }
}