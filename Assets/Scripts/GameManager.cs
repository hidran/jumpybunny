using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        ChangeGameState(GameState.InGame);
    }
    private void Start()
    {
        //StartGame();
        currentGameState = GameState.Menu;
    }
    private void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            ChangeGameState(GameState.InGame);
        }

    }
    // Called when player dies
    public void GameOver()
    {
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
       /* if(newGameState == GameState.Menu)
        {
            //Let's load Mainmenu Scene
        } else if(newGameState == GameState.InGame)
        {
            // Unity Scene must show the Real game
        } else if(newGameState == GameState.GameOver)
        {
            // Let's load end of the game scene
        }
         else{
            currentGameState = GameState.Menu
       }
       */
         switch(newGameState)
        {
            case GameState.Menu:
                //Let's load Mainmenu Scene
                break;
            case GameState.InGame:
                // Unity Scene must show the Real game
                break;
            case GameState.GameOver:
                // Let's load end of the game scene
                break;
            default:
                newGameState = GameState.Menu;
                break;
        }

        currentGameState = newGameState;
    }
}
