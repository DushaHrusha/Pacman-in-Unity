using UnityEngine;

public class PowerPellets : Pellet
{
    public readonly float duration = 8f;

    private protected override void Eat()
    {
        manager.PowerPelletEaten(this);
    }
}
