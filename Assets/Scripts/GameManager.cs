using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/** 1) Menu
 *  2) InGame
 *  3) GameOver
 *  4) Pause
 * 
 * */
enum DaysOfTheWeek : byte
{
    Monday = 1,
    Tuesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
public enum GameState
{
    Menu,
    InGame,
    GameOver,
    Resume
}
public class GameManager : MonoBehaviour
{
    // Starts our game
    // DaysOfTheWeek currentDay = DaysOfTheWeek.Sunday;
  public  GameState currentGameState = GameState.Menu;
   private static GameManager sharedInstance;
    public Canvas mainMenu;
    public Canvas gameMenu;
    public Canvas gameOverMenu;
    int collectedCoins = 0;
    private void Awake()
    {
        sharedInstance = this;
    }
     public static GameManager GetInstance()
    {
        return sharedInstance;
    }
    public void StartGame()
    {
        LevelGenerator.sharedInstance.createInitialBlocks();
        PlayerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
    }
    private void Start()
    {
        //StartGame();
        currentGameState = GameState.Menu;
        mainMenu.enabled = true;
        gameMenu.enabled = false;
        gameOverMenu.enabled = false;
    }
    private void Update()
    {
        if (currentGameState != GameState.InGame && Input.GetButtonDown("s"))
        {
            ChangeGameState(GameState.InGame);
            StartGame();
        }

    }
    // Called when player dies
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        
        ChangeGameState(GameState.GameOver);
    }
    // Called when the player decides to quick the game
    // and go to the main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }
    void ChangeGameState(GameState newGameState)
    {
       
         switch(newGameState)
        {
            case GameState.Menu:
                mainMenu.enabled = true;
                gameMenu.enabled = false;
                gameOverMenu.enabled = false;
                break;
            case GameState.InGame:
                mainMenu.enabled = false;
                gameMenu.enabled = true;
                gameOverMenu.enabled = false;
                break;
            case GameState.GameOver:
                mainMenu.enabled = false;
                gameMenu.enabled = false;
                gameOverMenu.enabled = true;
                break;
            default:
                newGameState = GameState.Menu;
                break;
        }

        currentGameState = newGameState;
    }

   public  void CollectCoins()
    {
        collectedCoins++;
    }
    public int GetCollectedCoins()
    {
        return collectedCoins;
    }
}
