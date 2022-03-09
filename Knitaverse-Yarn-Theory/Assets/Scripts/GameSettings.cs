using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum GameDifficulties // create an enum to hold all the different difficulties
    {
        NOT_SET,
        EASY,
        INTERMEDIATE,
        HARD,

    }

    public static GameSettings Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private GameDifficulties gameDifficulty;

    void Start()
    {
        gameDifficulty = GameDifficulties.NOT_SET;
    }

    public void SetGameDifficulty(GameDifficulties difficulty)
    {
        gameDifficulty = difficulty;
    }

    public void SetGameDifficulty(string difficulty)
    {
        if (difficulty == "Easy") SetGameDifficulty(GameDifficulties.EASY);
        else if (difficulty == "Intermediate") SetGameDifficulty(GameDifficulties.INTERMEDIATE);
        else if (difficulty == "Hard") SetGameDifficulty(GameDifficulties.HARD);
        else SetGameDifficulty(GameDifficulties.NOT_SET);
    }

    public string GetGameDifficulty()
    {
        switch(gameDifficulty)
        {
            case GameDifficulties.EASY: return "Easy";
            case GameDifficulties.INTERMEDIATE: return "Intermediate";
            case GameDifficulties.HARD: return "Hard";
            
        }
        Debug.LogError("Game Difficulty is not set");
        return " ";
    }
}
