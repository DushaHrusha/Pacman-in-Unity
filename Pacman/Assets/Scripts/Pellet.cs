using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    public virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Pacman>() != null )
        {
            Eat();
        }
    }
}
