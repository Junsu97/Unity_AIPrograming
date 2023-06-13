using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<Monster> moblist = new List<Monster>();
    public static MonsterManager instance = null;
    public Character player = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        StartCoroutine(SortByDistance(0.1f));
    }

    public Monster GetClosedMonster()
    {
        foreach (Monster one in moblist)
        {
            if (one.gameObject.activeSelf == true)
                return one;
        }
        return null;
    }

    IEnumerator SortByDistance(float _time)
    {
        for(;;)
        {
            yield return new WaitForSeconds(_time);
            moblist.Sort((x, y) => x.DISTANCE.CompareTo(y.DISTANCE));
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
