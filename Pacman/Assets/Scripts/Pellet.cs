using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;
    private protected GameManager manager;
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private protected virtual void Eat()
    {
        manager.PelletEaten(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
}
