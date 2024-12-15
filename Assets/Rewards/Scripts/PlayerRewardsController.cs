using StarterAssets;
using UnityEngine;

public class PlayerRewardsController : MonoBehaviour
{
    public CollectibleController collectibleController;  // Referencja do skryptu CollectibleController
    public ThirdPersonController thirdPersonController;  // Referencja do skryptu ThirdPersonController

    private const float MAX_SPRINT_SPEED = 10.0f;  // Maksymalna pr�dko�� sprintu, ustawiamy bezpieczn� warto��

    // Start is called before the first frame update
    void Start()
    {
        if (collectibleController == null)
        {
            collectibleController = FindObjectOfType<CollectibleController>();  // Znajd� skrypt CollectibleController
        }

        if (thirdPersonController == null)
        {
            thirdPersonController = GetComponent<ThirdPersonController>();  // Pobierz ThirdPersonController z tego samego obiektu
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibleController != null && thirdPersonController != null)
        {
            // Je�li liczba monet jest wi�ksza lub r�wna 5, podwajamy pr�dko�� sprintu, ale z limitem
            if (collectibleController.coins >= 5)
            {
                // Podwajamy sprint speed ale ograniczamy do MAX_SPRINT_SPEED
                float newSprintSpeed = thirdPersonController.SprintSpeed * 2;
                thirdPersonController.SprintSpeed = Mathf.Min(newSprintSpeed, MAX_SPRINT_SPEED);
            }
            else
            {
                // Je�li liczba monet jest mniejsza ni� 5, ustawiamy pr�dko�� sprintu na standardow�
                thirdPersonController.SprintSpeed = 5.335f;  // Zak�adaj�c, �e to by�a warto�� domy�lna
            }

            // Je�li liczba monet jest wi�ksza lub r�wna 7, zwi�kszamy wysoko�� skoku
            if (collectibleController.coins >= 7)
            {
                if (thirdPersonController.JumpHeight != 3.0f)  // Zwi�kszamy wysoko�� skoku na 3.0
                {
                    thirdPersonController.JumpHeight = 3.0f;
                }
            }
            else
            {
                // Je�li liczba monet jest mniejsza ni� 7, przywracamy standardow� wysoko�� skoku
                thirdPersonController.JumpHeight = 1.2f;
            }
        }
    }
}
