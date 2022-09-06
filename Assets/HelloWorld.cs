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

        Debug.Log(c);
        c = 11;
        Debug.Log(c);


    }
}
