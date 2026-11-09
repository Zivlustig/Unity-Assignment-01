using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject[] coinPrefabs;   
    public int numCoins = 5;

    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    private static string CoinTag = "Coin";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNewCoins();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag(CoinTag).Length == 0)
        {
            SpawnNewCoins();
        }
    }

    private void SpawnNewCoins()
    {
        for (int i = 0; i < numCoins; i++)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        int randomCoin = Random.Range(0, 3);

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(coinPrefabs[randomCoin], new Vector3(x, y, 0f), Quaternion.identity);
    }
}
