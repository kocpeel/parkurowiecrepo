using StarterAssets;
using UnityEngine;

public class PlayerRewardsController : MonoBehaviour
{
    public CollectibleController collectibleController;  // Referencja do skryptu CollectibleController
    public ThirdPersonController thirdPersonController;  // Referencja do skryptu ThirdPersonController

    private const float MAX_SPRINT_SPEED = 10.0f;  // Maksymalna prêdkoœæ sprintu, ustawiamy bezpieczn¹ wartoœæ

    // Start is called before the first frame update
    void Start()
    {
        if (collectibleController == null)
        {
            collectibleController = FindObjectOfType<CollectibleController>();  // ZnajdŸ skrypt CollectibleController
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
            // Jeœli liczba monet jest wiêksza lub równa 5, podwajamy prêdkoœæ sprintu, ale z limitem
            if (collectibleController.coins >= 5)
            {
                // Podwajamy sprint speed ale ograniczamy do MAX_SPRINT_SPEED
                float newSprintSpeed = thirdPersonController.SprintSpeed * 2;
                thirdPersonController.SprintSpeed = Mathf.Min(newSprintSpeed, MAX_SPRINT_SPEED);
            }
            else
            {
                // Jeœli liczba monet jest mniejsza ni¿ 5, ustawiamy prêdkoœæ sprintu na standardow¹
                thirdPersonController.SprintSpeed = 5.335f;  // Zak³adaj¹c, ¿e to by³a wartoœæ domyœlna
            }

            // Jeœli liczba monet jest wiêksza lub równa 7, zwiêkszamy wysokoœæ skoku
            if (collectibleController.coins >= 7)
            {
                if (thirdPersonController.JumpHeight != 3.0f)  // Zwiêkszamy wysokoœæ skoku na 3.0
                {
                    thirdPersonController.JumpHeight = 3.0f;
                }
            }
            else
            {
                // Jeœli liczba monet jest mniejsza ni¿ 7, przywracamy standardow¹ wysokoœæ skoku
                thirdPersonController.JumpHeight = 1.2f;
            }
        }
    }
}
