using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    private SpriteRenderer _spriteRenderer;
    private readonly float animationTime = 0.125f;
    private bool loop = true;
    public int animationFrame { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }
    private void Advance()
    {
        // костыль конкретный, нужно переделть в будущем в сопрограмму
        if (!_spriteRenderer.enabled)
            return;
        animationFrame++;
        if (animationFrame >= _sprites.Length && loop)
            animationFrame = 0;
        _spriteRenderer.sprite = _sprites[animationFrame];
    }

    private void Reset()
    {
        animationFrame = -1;
        Advance();
    }
}
