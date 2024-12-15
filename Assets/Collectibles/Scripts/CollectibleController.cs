using UnityEngine;
using TMPro;  // Dodajemy namespace TextMeshPro

public class CollectibleController : MonoBehaviour
{
    public int coins;  // Zmieniamy na publiczne, aby inne skrypty mia³y dostêp
    public TextMeshProUGUI coinText;  // Zmieniamy na TextMeshProUGUI

    void Start()
    {
        coins = 0;
        UpdateCoinText();  // Wywo³ujemy metodê, aby zaktualizowaæ UI na pocz¹tku
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
        // Zwiêkszamy liczbê monet, jeœli dotkniemy monety
        if (other.CompareTag("coin"))
        {
            coins++;  // Zwiêkszamy liczbê monet
            other.gameObject.SetActive(false);  // Ukrywamy obiekt monety
            UpdateCoinText();  // Aktualizujemy tekst na UI po zebraniu monety
        }
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins.ToString();
    }
}
