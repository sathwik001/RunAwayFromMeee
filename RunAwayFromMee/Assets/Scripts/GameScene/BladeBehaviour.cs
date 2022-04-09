using UnityEngine;

public class BladeBehaviour : MonoBehaviour
{
    float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= -3.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
