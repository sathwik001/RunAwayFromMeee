using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _downSpikesPrefab, _topSpikesPrefab;
    public float _spikesDelay;
    [SerializeField] private GameObject _shieldEffectPrefab, _scaleSizeIncreaser, _bladePrefab;
    [SerializeField] private GameObject _topSpikes;
    IEnumerator dangerSpikes;

    private void Awake()
    {
        dangerSpikes = TopSpikesSpawn();
    }
    void Start()
    {
        StartCoroutine(SpikesSpawning());
        StartCoroutine(ShieldEffectSpawning());
        StartCoroutine(SizeScallingEffect());
        StartCoroutine(BladesSpawning());
    }

    public void OnStartCoroutine()
    {
        StartCoroutine(dangerSpikes);
    }

    public void OnStopCoroutine()
    {
        StopCoroutine(dangerSpikes);
    }

    private void Update()
    {
        int _score = FindObjectOfType<PlayerJumpBehaviour>()._scorePoints;

        switch (_score)
        {
            case 0:
                _spikesDelay = 3f;
                break;
            case 15:
                _spikesDelay = 2.5f;
                break;
            case 30:
                _spikesDelay = 2.0f;
                break;
            case 45:
                _spikesDelay = 1.75f;
                break;
            case 60:
                _spikesDelay = 1.50f;
                break;
            case 75:
                _spikesDelay = 1.25f;
                break;
            case 100:
                _spikesDelay = 1.0f;
                break;  
        }
    }

    IEnumerator SpikesSpawning()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(3.7f,7.7f), -5.2f);
            Instantiate(_downSpikesPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_spikesDelay);
        }
    }

    IEnumerator TopSpikesSpawn()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(3.7f, 7.7f), 5.2f);
            Instantiate(_topSpikes, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_spikesDelay);
        }
    }
    IEnumerator ShieldEffectSpawning()
    {
        yield return new WaitForSeconds(Random.Range(20.0f,25.0f));
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(3.7f,7.7f), Random.Range(3.5f,-3.5f));
            Instantiate(_shieldEffectPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(25.0f,30.0f));
        }
    }

    IEnumerator SizeScallingEffect()
    {
        yield return new WaitForSeconds(30.0f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(3.7f,7.7f), Random.Range(3.5f, -3.5f));
            Instantiate(_scaleSizeIncreaser, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(25.0f, 30.0f));
        }
    }

    IEnumerator BladesSpawning()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(3.7f,7.7f), Random.Range(3.5f, -3.5f));
            Instantiate(_bladePrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
