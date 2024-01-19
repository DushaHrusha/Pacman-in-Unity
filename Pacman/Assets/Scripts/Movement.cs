using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private readonly float _speed = 9.0f;
    public Rigidbody2D rigidbodyUnit {  get; private set; }
    public LayerMask obstacleLayer;
    private void Awake()
    {
        rigidbodyUnit = GetComponent<Rigidbody2D>();
    }
}
