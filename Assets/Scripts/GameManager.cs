using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;


public enum GameState { Start, Playing, Paused, GameOver}
public class GameManager : Singleton<GameManager>
{
    //enums
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //GameStates
    public void ChangeGameState(GameState _gamestate)
    {
        gameState = _gamestate;
        SetGameState();
    }
    public void SetGameState()
    {
        switch (gameState)
        {
            case GameState.Start:
                Time.timeScale = 1;
                GameEvents.ReportGameStart();
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                GameEvents.ReportGamePlaying();
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                GameEvents.ReportGamePause();
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                GameEvents.ReportGameOver();
                break;
        }
    }
}
