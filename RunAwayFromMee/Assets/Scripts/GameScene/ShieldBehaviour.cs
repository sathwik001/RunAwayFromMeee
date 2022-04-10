using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{

    private void Update()
    {
        transform.position = FindObjectOfType<PlayerJumpBehaviour>().transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Spikes")
        {
            this.gameObject.SetActive(false);
            Destroy(other.gameObject);
            //other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(180.0f, 360.0f), 0.0f));
        }

        if(other.tag == "DownSpikes")
        {
            this.gameObject.SetActive(false);
        }
        if(other.tag == "TopSpikes")
        {
            this.gameObject.SetActive(false);
        }
    }
}
