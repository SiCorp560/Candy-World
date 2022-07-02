using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public GameObject gumbombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropGumbomb());
    }

    public IEnumerator DropGumbomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            Instantiate(gumbombPrefab, transform.position, Quaternion.identity);
        }
    }
}
