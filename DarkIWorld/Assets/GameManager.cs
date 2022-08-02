using UnityEngine;

public enum gameState
{
    playing,
    paused,
    gameOver,
    gameWon
}

public class GameManager : MonoBehaviour
{
    public static gameState currentGameState;
    public bool pauseGame;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }


}




