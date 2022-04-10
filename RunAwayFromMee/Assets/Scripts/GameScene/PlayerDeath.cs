using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float jumpForce = 13f;
    float _jumpForce = 8f;
    [SerializeField] private GameObject _button;
    private Animator _anim;
    public bool isDead;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _button.SetActive(true);
    }

    private void Update()
    {
        if (isDead)
        {
            _gameOverPanel.SetActive(true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            _anim.SetTrigger("isDead");
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2f;
            _button.SetActive(false);
        }           
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Spikes")
        {
            Destroy(other.gameObject);
            _gameOverPanel.SetActive(true);
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            _anim.SetTrigger("isDead");
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            _button.SetActive(false);
            rb2D.velocity = Vector2.up * _jumpForce;
        }   

        if(other.tag == "TopSpikes")
        {
            isDead = true;
            rb2D.velocity = Vector2.down * _jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "DownSpikes")
        {
            isDead = true;
            rb2D.velocity = Vector2.up * jumpForce;
        }

        if(other.collider.tag == "TopSpikes")
        {
            isDead = true;
            rb2D.velocity = Vector2.down * _jumpForce;
        }
    }
}
