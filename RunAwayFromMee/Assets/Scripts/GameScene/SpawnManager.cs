using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spikesPrefab;
    public float _spikesDelay = 5f;
    [SerializeField] private GameObject _shieldEffectPrefab,_scaleSizeIncreaser,_bladePrefab;

    void Start()
    {
        StartCoroutine(SpikesSpawning());
        StartCoroutine(ShieldEffectSpawning());
        StartCoroutine(SizeScallingEffect());
        StartCoroutine(BladesSpawning());
    }
    
    IEnumerator SpikesSpawning()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(-1.9f, 2.1f), -5.2f);
            Instantiate(_spikesPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_spikesDelay);
        }
    }

    IEnumerator ShieldEffectSpawning()
    {
        yield return new WaitForSeconds(Random.Range(25.0f,30.0f));
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(-1.8f, 1.8f), Random.Range(3.5f,-3.5f));
            Instantiate(_shieldEffectPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(45.0f, 50.0f));
        }
    }

    IEnumerator SizeScallingEffect()
    {
        yield return new WaitForSeconds(40.0f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(-1.8f, 1.8f), Random.Range(3.5f, -3.5f));
            Instantiate(_scaleSizeIncreaser, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(50.0f);
        }
    }

    IEnumerator BladesSpawning()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(3.0f,Random.Range(3.5f, -3.5f));
            Instantiate(_bladePrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
