using UnityEngine;

class HelloWorld : MonoBehaviour
{

    // Format code : Ctrl + K + D
    void Start()
    {
        Debug.Log("Hello World !");
        Debug.Log("I am " + name);

        int myFirtsVar;
        myFirtsVar = 123;
        myFirtsVar = 47;

        int a, b, c;

        a = 3;
        b = 6;
        c = a + b;
        c = 11;
    }

    [SerializeField] int a, b, c;

    void OnValidate()
    {
        Debug.Log("a: " + a + " b: " + b + " c: " + c);
    }
}
