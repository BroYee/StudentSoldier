using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public List<GameObject> items;
    public bool[] itemUsed;

    private void Start()
    {
        StartCoroutine(RegenAmmo(0));
        StartCoroutine(RegenFirstAidKit(0));

        itemUsed = new bool[items.Capacity];

        for (int i = 0; i < items.Capacity; i++)
        {
            itemUsed[i] = false;
        }
    }

    private void Update()
    {
        if (itemUsed[0] == true)
        {
            StartCoroutine(RegenAmmo(10.0f));
            itemUsed[0] = false;
        }
        if (itemUsed[1] == true)
        {
            StartCoroutine(RegenFirstAidKit(7.0f));
            itemUsed[1] = false;
        }
    }

    public IEnumerator RegenAmmo(float time)
    {
        yield return new WaitForSeconds(time);
        
        GameObject tempAmmo = Instantiate(items[0], new Vector3(-10, 3, 0), Quaternion.identity);
        tempAmmo.transform.SetParent(transform);
    }

    public IEnumerator RegenFirstAidKit(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject tempFirstAidKit = Instantiate(items[1], new Vector3(-4.6f, -3, 0), Quaternion.identity);
        tempFirstAidKit.transform.SetParent(transform);
    }
}
