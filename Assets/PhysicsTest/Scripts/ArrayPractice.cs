using System.Collections.Generic;
using UnityEngine;

public class ArrayPractice : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] int[] intArrayField;
    [SerializeField] string[] stringArrayField;
    [SerializeField] Transform[] transformArrayField;
    [SerializeField] GameObject[] gameObjectArrayField;

    [SerializeField] List<int> intList;
    [SerializeField] List<Transform> transformList;
    void Start()
    {
        /*
        int[] arrayOfInts = new int[5];

        for (int i = 0; i < arrayOfInts.Length; i++)
        {
            arrayOfInts[i] = i + 1;

            //int elem = arrayOfInts[i];
            //Debug.Log("Elem: " + elem);
        }

        int sum = 0;

        foreach (int v in arrayOfInts)
        {
            sum += v;
        }

        Debug.Log("Sum: " + sum);
        */

        List<int> integerList = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            integerList.Add(i + 1);
        }
    }


}
