using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    float _speed = 3f;

    void Update()
    {
        if(this.transform.name == "DownSpikes(Clone)")
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);

            if (transform.position.y >= 5.5f)
            {
                Destroy(this.gameObject);
            }
        }

        if(this.transform.name == "TopSpikes(Clone)")
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);

            if (transform.position.y <= -5.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
