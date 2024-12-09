using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //A Static variable which will hold the copy/instance of GameManager class.
    public static GameManager instance;

    //This game object is the parent of GameOverText and PlayAgainButton.
    //We need only their parent to display/hide both of them.
    public GameObject gameOverContent;

    //This game object is the parent of StartGameText and PlayButton.
    //We need only their parent to display/hide both of them.
    public GameObject startGameContent;

    //The Player gameobject is needed to activate the player again
    //when the user clicks the PlayAgain button.
    public GameObject player;

    //Player Score text to display the current score of the Player.
    public TextMeshProUGUI playerAScoreText;

    //Opposing Player Score text to display the current score of the opposing Player.
    public TextMeshProUGUI playerBScoreText;

    //This variable keeps track of the game status i.e., if it is over or not.
    private bool isGameOver = true;

    //This variable keeps track of the player's score.
    private int playerAScore = 0;

    //This variable keeps track of the opposing player's score.
    private int playerBScore = 0;

    // The score required to reach the next level
    private int scoreToNextLevel = 10;



    void Awake()
    {
        // Ensure there is only one GameManager instance (Singleton pattern)
        if (instance == null)
        {

            //This class name is GameManager and we'll assign it's copy/instance
            //to the "instance" variable using "this". Down the line it will be easy 
            //for us to call any function of this class objects.
            //For example: GameManager.instance.GameOver();
            instance = this;
        }
        else
        {
            //If another GameManager is created then destroy it because we 
            //only one copy/instance of GameManager in our game.
            Destroy(gameObject);
        }
    }

    public void OnHideGameStartUIAnimationEnd()
    {


        if (startGameContent.activeSelf)
        {
            startGameContent.SetActive(false); // Hide Game Title text and Play button.
        }

        StartGame();
    }

    public void OnHideGameOverUIAnimationEnd()
    {

        if (gameOverContent.activeSelf)
        {
            gameOverContent.SetActive(false); // Hide Game Over text and PlayAgain button.
        }

        StartGame();
    }

    public void StartGame()
    {

        // Set the scores to zero.
        playerAScore = 0;
        playerBScore = 0;

        // Display the zero score in the text views.
        playerAScoreText.text = "0";
        playerBScoreText.text = "0";

        isGameOver = false; // Game is no longer over.

        //TODO: Reset the ball's position.
    }

    //This function is called when the Score target is achieved by any Player.
    public void GameOver()
    {
        //TODO: Play the celebration sound.
        //SoundManager.instance.PlayDestroySound();

        // Show Congratulations message to Winner.
        gameOverContent.SetActive(true);

        
        //TODO: Show controls with animations
        //Trigger animation to show UI Controls
        //UIAnimationsManager.instance.ShowGameOverUIControls();

        isGameOver = true; //Game is over.

        //De-Activate the Ball and handles.
        //player.SetActive(false); 

    }

    // Function to check if the game is over
    //This fucntion is called whenever we try to spawn a new Pipe.
    public bool IsGameOver()
    {
        return isGameOver;
    }

    //This function is called whenever the Ball hits the Player B's wall.

    public void AddScoreToPlayerAAccount() {
        playerAScore++; //Increase the score.

        playerAScoreText.text = playerAScore.ToString(); //Show the incremented score on UI.
    }

    //This function is called whenever the Ball hits the Player A's wall
    public void AddScoreToPlayerBAccount()
    {
        playerBScore++; //Increase the score.

        playerBScoreText.text = playerBScore.ToString(); //Show the incremented score on UI.
    }
}
