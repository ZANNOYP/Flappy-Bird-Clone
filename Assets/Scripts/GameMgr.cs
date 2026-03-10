using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏状态枚举
/// </summary>
public enum GameState
{
    Ready,
    Playing,
    GameOver
}

/// <summary>
/// 游戏管理器
/// </summary>
public class GameMgr : MonoBehaviour ,IGameFlow
{
    private static GameMgr instance;
    public static GameMgr Instance => instance;
    // 当前游戏状态
    public GameState State { get; private set; }
    private IGameState currentState;

    [SerializeField]
    private PipeBootstrap pipeBootstrap;
    [SerializeField]
    private Bird bird;

    private Dictionary<GameState, IGameState> states;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(this.gameObject);

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        states = new Dictionary<GameState, IGameState>()
        {
            { GameState.Ready,new ReadyState(bird,pipeBootstrap)},
            { GameState.Playing,new PlayingState(bird,pipeBootstrap)},
            { GameState.GameOver,new GameOverState(pipeBootstrap)}
        };

        bird.onDead += OnBirdDead;

        currentState = states[GameState.Ready];
        State = GameState.Ready;
        currentState.Enter();
    }

    /// <summary>
    /// 改变游戏状态
    /// </summary>
    /// <param name="newState">新状态</param>
    private void ChangeState(GameState newState)
    {
        if (State == newState) return;
        currentState?.Exit();
        State = newState;
        currentState = states[newState];
        currentState?.Enter();
    }

    public void StartGame()
    {
        ChangeState(GameState.Playing);
    }

    public void EndGame()
    {
        ChangeState(GameState.GameOver);
    }

    public void ResetGame()
    {
        ChangeState(GameState.Ready);
    }

    private void OnBirdDead()
    {
        EndGame();
    }
}
