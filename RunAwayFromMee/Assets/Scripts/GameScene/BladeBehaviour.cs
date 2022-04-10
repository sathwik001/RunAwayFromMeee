using UnityEngine;
using System.Collections;

public class BladeBehaviour : MonoBehaviour
{
    private Animator _anim;
    bool isDestroying;

    void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(FadeThisGameObject());
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroying)
        {
            _anim.SetTrigger("isDestroying");
            StartCoroutine(DestroyThisGameObject());
        }
    }

    IEnumerator FadeThisGameObject()
    {
        yield return new WaitForSeconds(4.0f);
        isDestroying = true;
    }

    IEnumerator DestroyThisGameObject()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
