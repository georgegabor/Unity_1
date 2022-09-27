using UnityEngine;

public class Rounding : MonoBehaviour
{
    [SerializeField] float num;
    [SerializeField] float roundedUp;
    [SerializeField] float roundedDown;
    [SerializeField] float rounded;

    private void OnValidate()
    {
        //roundedUp = Mathf.Ceil(num);
        roundedUp = Ceil(num);
        // roundedDown = Mathf.Floor(num);
        roundedDown = Floor(num);
        // rounded = Mathf.Round(num);
        rounded = Round(num);
    }

    float Floor(float n)
    {
        float remainder = n % 1;
        return n - remainder;
    }

    float Ceil(float n)
    {
        float remainder = n % 1;
        if (remainder == 0) return n;

        return n - remainder + 1;
    }

    float Round(float n)
    {
        float remainder = n % 1;
        if (remainder < 0.5f) return Floor(n);
        else return Ceil(n);
    }
}
