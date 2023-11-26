using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    [SerializeField] private CoupleGens coupleGens;
    [SerializeField] private GensConteiner gensConteiner;
    [SerializeField] private ResultCreator resultCreator;

    private List<MoverGen> moverGens = new List<MoverGen>();
    private List<TypeGen> typeGens=new List<TypeGen>();
    private List<List<TypeGen>> coupleTypeGens = new List<List<TypeGen>>();
    public void CheckCoupleGroups()
    {
        FormTypeList();
    }
   private void FormTypeList()
    {
       
        moverGens.Clear();
        typeGens.Clear();
        foreach (var couple in coupleGens.IsCouple)
        {
            foreach (var gen in couple.BusyGens)
            {
                var mover = gen.GetComponent<MoverGen>();
              
                if (mover!=null)
                {
                    typeGens.Add(gen.GetComponent<MoverGen>().typeGen);
                    moverGens.Add(gen.GetComponent<MoverGen>());
                   
                }
            }
        }
       
        CheckList();
    }
    private void CheckList()
    {
        coupleTypeGens.Clear();
        if (gensConteiner.IsMaxCount > typeGens.Count) return;

        resultCreator.SetTypeForCreateResult(moverGens);
        var listType = new List<TypeGen>();
        for (int i=1; i<=typeGens.Count;i++)
        { 
            listType.Add(typeGens[i-1]);
            if (i % 2 == 0)
            {
                coupleTypeGens.Add(listType);
                listType = new List<TypeGen>();
            }
        }

        resultCreator.CreateBonus(coupleTypeGens);
        
    }
}
