using UnityEngine;

public class DropCoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void Start()
    {
        GlobalEvents.SpawnDropCoin.AddListener(SpawnDropCoin);
    }

    private void SpawnDropCoin(Vector3 position)
    {
        var coin = Instantiate(coinPrefab, position, Quaternion.identity);
        coin.transform.SetParent(transform);
    }
}
