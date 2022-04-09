using System.Collections;
using UnityEngine;

public class ShieldEffectBehaviour : MonoBehaviour
{
    private Animator _anim;
    bool isDestroying;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(FadeThisGameObject());
    }

    private void Update()
    {
        if (isDestroying)
        {
            _anim.SetTrigger("isDestroying");
            StartCoroutine(DestroyThisGameObject());
        }
    }

    IEnumerator FadeThisGameObject()
    {
        yield return new WaitForSeconds(7.0f);
        isDestroying = true;
    }

    IEnumerator DestroyThisGameObject()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
