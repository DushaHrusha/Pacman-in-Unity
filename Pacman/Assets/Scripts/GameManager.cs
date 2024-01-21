using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public int ghostMultiplier {  get; private set; }
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
        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }
    private void GameOver()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.gameObject.SetActive(false);
    }
    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
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
        int points = ghost.points * ghostMultiplier;
        SetScore(Score + points);
        ghostMultiplier++;
    }
    public void PacmanEaten(Pacman pacman)
    {
        pacman.gameObject.SetActive(false);
        SetLives(Lives - 1);
    }
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(Score + pellet.points);
        if(!HasRemainingPrllets())
        {
            pacman.gameObject.SetActive(true);//Должно стоять false
            Invoke(nameof(NewRound), 5f);
        }

    }
    public void PowerPelletEaten(PowerPellets pellet)
    {
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPrllets()
    {
        foreach (Transform pellet in pellets)
        {
            if(pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }
}
