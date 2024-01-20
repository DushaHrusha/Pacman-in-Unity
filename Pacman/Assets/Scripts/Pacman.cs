using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    private Movement _movment;
    private float _anglePacmanSprite;
    private void Awake()
    {
        _movment = GetComponent<Movement>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _movment.SetDirection(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _movment.SetDirection(Vector2.down);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _movment.SetDirection(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _movment.SetDirection(Vector2.left);
        }
        _anglePacmanSprite = Mathf.Atan2(_movment.direction.y, _movment.direction.x);
        transform.rotation = Quaternion.AngleAxis(_anglePacmanSprite * Mathf.Rad2Deg,Vector3.forward);
    }
}
