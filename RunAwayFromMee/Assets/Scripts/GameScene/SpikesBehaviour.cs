using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    float _speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if(transform.position.y >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
