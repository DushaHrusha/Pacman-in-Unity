using UnityEngine;

public class PowerPellets : Pellet
{
    public readonly float duration = 8f;

    public override void Eat()
    {
       // GameManager.PowerPelletEaten(this);
    }
}
