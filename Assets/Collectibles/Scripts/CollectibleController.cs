using UnityEngine;
using TMPro;  // Dodajemy namespace TextMeshPro

public class CollectibleController : MonoBehaviour
{
    public int coins;  // Zmieniamy na publiczne, aby inne skrypty mia�y dost�p
    public TextMeshProUGUI coinText;  // Zmieniamy na TextMeshProUGUI

    void Start()
    {
        coins = 0;
        UpdateCoinText();  // Wywo�ujemy metod�, aby zaktualizowa� UI na pocz�tku
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Debug.Log("you have " + coins + " coins");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        // Zwi�kszamy liczb� monet, je�li dotkniemy monety
        if (other.CompareTag("coin"))
        {
            coins++;  // Zwi�kszamy liczb� monet
            other.gameObject.SetActive(false);  // Ukrywamy obiekt monety
            UpdateCoinText();  // Aktualizujemy tekst na UI po zebraniu monety
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins.ToString();
    }
}
