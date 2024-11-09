using UnityEngine;

public class BonusPellet : Pellet
{
    public float duration = 9.0f;

    private void Awake()
    {
        points = 50;
    }
    public override void Eat()
    {
        FindObjectOfType<GameManager>().BonusPelletEaten(this);
    }
}
