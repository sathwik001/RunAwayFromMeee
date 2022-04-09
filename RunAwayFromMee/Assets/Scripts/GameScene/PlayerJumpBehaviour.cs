using UnityEngine;
using TMPro;

public class PlayerJumpBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float jumpForce = 5f;
    private float directionalJumpForce = 130f;
    private bool isRightBorderHitted, isLeftBorderHitted,isInMid;
    [SerializeField] private GameObject _midBorder;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public int _scorePoints;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        _scorePoints = 0;
        _scoreText.text = "" + _scorePoints;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void OnButtonClicked()
    {
        if (isInMid)
        {
            rb2D.velocity = Vector2.up * jumpForce;
            rb2D.AddForce(new Vector2(directionalJumpForce, 0.0f));
        }

        if (isRightBorderHitted)
        {
            isInMid = false;
            rb2D.velocity = Vector2.up * jumpForce;
            rb2D.AddForce(new Vector2(-directionalJumpForce, 0.0f));
        }
        if (isLeftBorderHitted)
        {
            rb2D.velocity = Vector2.up * jumpForce;
            rb2D.AddForce(new Vector2(directionalJumpForce, 0.0f));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.transform.name == "RightBorder")
        {
            _midBorder.SetActive(false);
            _scorePoints += 1;
            _scoreText.text = "" + _scorePoints;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-115f, 0));
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isRightBorderHitted = true;
            isLeftBorderHitted = false;
        }
        if(other.transform.name == "LeftBorder")
        {
            _scorePoints += 1;
            _scoreText.text = "" + _scorePoints;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(115f, 0));
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isRightBorderHitted = false;
            isLeftBorderHitted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "MidBorder")
        {
            isInMid = true;
        }
    }
}
