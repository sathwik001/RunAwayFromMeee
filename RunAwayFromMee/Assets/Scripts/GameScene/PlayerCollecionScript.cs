using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerCollecionScript : MonoBehaviour
{
    [SerializeField] private GameObject _shieldEffect;
    [SerializeField] private TextMeshProUGUI _bladesScoreText;
    public int _bladeScorePoints;
    public bool isScalePowerUpActive;

    private void Start()
    {
        _shieldEffect.SetActive(false);
        _bladeScorePoints = 0;
        _bladesScoreText.text = "" + _bladeScorePoints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ShieldEffect")
        {
            Destroy(other.gameObject);
            _shieldEffect.SetActive(true);
            StartCoroutine(DisableShieldEffect());
        }

        if(other.tag == "ScaleEffect")
        {
            Destroy(other.gameObject);
            isScalePowerUpActive = true;
            transform.localScale = new Vector2(0.5f, 0.5f);
            StartCoroutine(DisableScaleEffect());
        }

        if(other.tag == "Blade")
        {
            _bladeScorePoints += 1;
            _bladesScoreText.text = "" + _bladeScorePoints;
            Destroy(other.gameObject);
        }
    }

    IEnumerator DisableShieldEffect()
    {
        yield return new WaitForSeconds(7f);
        _shieldEffect.SetActive(false);
    }

    IEnumerator DisableScaleEffect()
    {
        yield return new WaitForSeconds(7f);
        isScalePowerUpActive = false;
        transform.localScale = new Vector2(0.32f, 0.28f);
    }
}
