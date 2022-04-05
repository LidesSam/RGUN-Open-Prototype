using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static  GameManager SharedInstance;

    public static  int InGameState = 0;
    public static  int PauseState = 1;
    public static  int GameOverState = 2;
    
    public int currentGameState = 0;
    
    public int score=0;
    public HUD Hud = null;
    
    private void Awake() {
        if (SharedInstance==null){
            SharedInstance=this;
        }
        else{
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inGame();
        score=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //control funtion to enter menu pause
    public void PauseGame(){
        SetGameState(GameManager.PauseState);
    }

    public void inGame(){
        SetGameState(GameManager.InGameState);
    }


    public void ResetGame(){

    }

    public void GameOver(){

    }

    public void SetGameState(int State=0){
        currentGameState = State;
    }


    public void addPointsToScore(int addedPoints = 0){
        if(Hud!= null){
       
            score+=addedPoints;
            print(score);
            Hud.updateScore(score);
        }
    }
}
