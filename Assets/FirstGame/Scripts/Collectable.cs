using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collectable : MonoBehaviour
{
    [SerializeField] int sum = 0;
    [SerializeField] TMP_Text displayedText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Collect(int value)
    {
        sum += value;
        UpdateText();
    }

    private void UpdateText()
    {
        if (displayedText != null)
            displayedText.text = "Points: " + sum;
    }
}
