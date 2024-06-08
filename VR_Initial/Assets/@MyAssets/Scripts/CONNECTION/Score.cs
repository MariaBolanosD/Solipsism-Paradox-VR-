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
    [SerializeField] Material RedMat;
    [SerializeField] Material BlueMat;
    [SerializeField] Material WhiteMat;
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;

    private int RedScore;
    private int BlueScore;

    private Renderer _renderer;
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
        _renderer = GetComponent<Renderer>();

    }

    void FixedUpdate()
    {
        if (!IsServer)
            return;
        redScore.Value = Red.GetComponent<ScoreUpdater>().GetScore();
        blueScore.Value = Blue.GetComponent<ScoreUpdater>().GetScore();


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

    public void UpdateScore()
    {
        RedScore = Red.GetComponent<ScoreUpdater>().GetScore();
        BlueScore = Blue.GetComponent<ScoreUpdater>().GetScore();

        if (redScore.Value > blueScore.Value)
        {
            _renderer.material = RedMat;
        }
        else if (redScore.Value == blueScore.Value)
        {
            _renderer.material = WhiteMat;
        }
        else
        {
            _renderer.material = BlueMat;
        }
    }

}
