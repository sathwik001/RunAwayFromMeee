using System.Collections;
using UnityEngine;

public class DangerManager : MonoBehaviour
{
    [SerializeField] private PlayerJumpBehaviour _playerScore;
    [SerializeField] private GameObject _dangerCam,_dangerBox;
    void Start()
    {
        _dangerCam.SetActive(false);
        _dangerBox.SetActive(false);
    }

    void LateUpdate()
    {
        if(_playerScore._scorePoints % 10 == 0 && _playerScore._scorePoints != 0)
        {
            _dangerCam.SetActive(true);
            _dangerBox.SetActive(true);
            StartCoroutine(DangerDestroy());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "DangerBox")
        {

            FindObjectOfType<SpawnManager>().OnStartCoroutine();
            _dangerBox.SetActive(false);
        }
    }
    IEnumerator DangerDestroy()
    {
        
        yield return new WaitForSeconds(5.0f);
        FindObjectOfType<SpawnManager>().OnStopCoroutine();
        _dangerCam.SetActive(false) ;
        _dangerBox.SetActive(false);
    }

}
