using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public int Score { get; private set; }
    public int Lives { get; private set; }

    private void Start()
    {
        NewGame();

    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);

        NewRound();
    }
     
    private void NewRound()
    {
        foreach(Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void GameOver()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }
    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(true);
        }

        pacman.gameObject.SetActive(true);
    }



    private void SetScore(int score)
    {
        Score = score;
    }
     
    private void SetLives(int lives)
    {
        Lives = lives;
        if (Lives > 0)
            Invoke(nameof(ResetState), 5f);
        else
            GameOver();
        
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(Score + ghost.points);
    }

    public void PacmanEaten(Pacman pacman)
    {
        pacman.gameObject.SetActive(false);
        SetLives(Lives - 1);
    }
}
