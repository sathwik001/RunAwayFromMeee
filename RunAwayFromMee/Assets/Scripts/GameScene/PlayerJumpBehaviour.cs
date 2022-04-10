using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;

public class PlayerJumpBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float jumpForce = 5f;
    private float directionalJumpForce = 130f;
    private bool isRightBorderHitted, isLeftBorderHitted,isInMid;
    [SerializeField] private GameObject _midBorder;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public int _scorePoints;
    IEnumerator scaleCoroutine;
    bool isButtonClicked;

    void Start()
    {
        scaleCoroutine = PlayerScaleBack();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        _scorePoints = 0;
        _scoreText.text = "" + _scorePoints;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isButtonClicked && !FindObjectOfType<PlayerCollecionScript>().isScalePowerUpActive)
        {
            StartCoroutine(scaleCoroutine);
        }
        else if(isButtonClicked && FindObjectOfType<PlayerCollecionScript>().isScalePowerUpActive)
        {
            StopCoroutine(scaleCoroutine);
        }
    }

    public void OnButtonClicked()
    {
        isButtonClicked = true;
        transform.DOPunchScale(new Vector3(0.05f, 0.05f, 0.0f), 0.1f);
        
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
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isRightBorderHitted = true;
            isLeftBorderHitted = false;
        }
        if(other.transform.name == "LeftBorder")
        {
            _scorePoints += 1;
            _scoreText.text = "" + _scorePoints;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(115f, 0));
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
    IEnumerator PlayerScaleBack()
    {
        while (true)
        {
            transform.localScale = new Vector2(0.32f, 0.28f);
            yield return new WaitForSeconds(2f);
        }
    }
}
