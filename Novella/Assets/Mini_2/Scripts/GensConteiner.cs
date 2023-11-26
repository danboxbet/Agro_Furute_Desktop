using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GensConteiner : MonoBehaviour
{
    [SerializeField] private LocaterTarget locaterTarget;
    [SerializeField] private int maxCountConteiner;
    private List<MoverGen> conteinerMoverGen;
    private SpawnerGen[] spawnersArray;
    

    public int IsMaxCount => maxCountConteiner;
    private void Start()
    {
        spawnersArray = FindObjectsOfType<SpawnerGen>();
        foreach(var spawner in spawnersArray)
        {
            spawner.OnStartFirstMovingGen += CheckConteiner;
        }
    }
    private void CheckConteiner()
    {
       
        conteinerMoverGen = new List<MoverGen>();
        var arrayrMoverGen = GetComponentsInChildren<MoverGen>();
        foreach (var element in arrayrMoverGen)
        {
            conteinerMoverGen.Add(element);
            
        }
        if (conteinerMoverGen.Count > maxCountConteiner)
        {
            GenImages.CheckGen(conteinerMoverGen[0].gameObject.GetComponent<RectTransform>());
            // conteinerMoverGen.RemoveAt(0);
            locaterTarget.RemoveElementInCouple(conteinerMoverGen[0].currentGenRectTransform);
            Destroy(conteinerMoverGen[0].gameObject);
        }
    }
    private void OnDestroy()
    {
        foreach (var spawner in spawnersArray)
        {
            spawner.OnStartFirstMovingGen -= CheckConteiner;
        }
    }

}
