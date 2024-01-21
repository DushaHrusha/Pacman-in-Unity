using UnityEngine;

public class Ghost : MonoBehaviour
{
    public readonly int points = 200;
    public Movement movement { get; private set; }
    public GhostSpawn spawn { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }

    private void Awake()
    {
        spawn = GetComponent<GhostSpawn>();
        movement = GetComponent<Movement>();
        scatter = GetComponent<GhostScatter>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
    }
    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();
        frightened.Disable();
        chase.Disable();
        scatter.Enable();
        spawn.Disable();
    }
}
