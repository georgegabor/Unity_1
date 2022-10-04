using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{
    int sum = 0;
    [SerializeField] TMP_Text displayedText;

    private void Start()
    {
        UpdateText();
    }
    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable = other.GetComponent<Collectable>();

        if (collectable != null)
        {
            sum += collectable.value;
            collectable.TeleportRandom();
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (displayedText != null)
            displayedText.text = "Score: " + sum;
    }
}
