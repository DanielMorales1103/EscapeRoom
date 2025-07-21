using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int totalCoins = 5;
    public TextMeshProUGUI coinText;

    [HideInInspector] public int coinsCollected = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        coinsCollected = 0;
        UpdateCoinUI();

    }

    public void CollectCoin()
    {
        coinsCollected = Mathf.Min(coinsCollected + 1, totalCoins);
        UpdateCoinUI();

    }

    void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = $"Monedas: {coinsCollected}/{totalCoins}";
    }

    public bool HasAllCoins => coinsCollected >= totalCoins;
}
