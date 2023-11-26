using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Results
{
    public int Increase;
    public int Stamine;
    public int Diversity;
    public int Sintez;
    public int StressResistance;
}
public class ResultCreator : MonoBehaviour
{
    public static event Action<Results> OnResult;
    private Results results=new Results();
    public void SetTypeForCreateResult(List<MoverGen> moverGen)
    {
        results.Increase = 0;
        results.Stamine = 0;
        results.Diversity = 0;
        results.Sintez = 0;
        results.StressResistance = 0;

        foreach (var mover in moverGen)
        {
            if (mover.typeGen == TypeGen.Type1) results.Increase += mover.addScore;
            if (mover.typeGen == TypeGen.Type2) results.Stamine += mover.addScore;
            if (mover.typeGen == TypeGen.Type3) results.Diversity += mover.addScore;
            if (mover.typeGen == TypeGen.Type4) results.Sintez += mover.addScore;
            if (mover.typeGen == TypeGen.Type5) results.StressResistance += mover.addScore;
        }
        
    }
    public void CreateBonus(List<List<TypeGen>> typeCoupleGens)
    {
        foreach(var couple in typeCoupleGens)
        {
            if (couple[0] == TypeGen.Type1 && couple[1] == TypeGen.Type1) results.Increase += 4;
            if (couple[0] == TypeGen.Type2 && couple[1] == TypeGen.Type2) results.Stamine += 25;
            if (couple[0] == TypeGen.Type3 && couple[1] == TypeGen.Type3) results.Diversity += 13;
            if (couple[0] == TypeGen.Type4 && couple[1] == TypeGen.Type4) results.Sintez += 7;
            if (couple[0] == TypeGen.Type5 && couple[1] == TypeGen.Type5) results.StressResistance += 10;

            if ((couple[0] == TypeGen.Type1 && couple[1] == TypeGen.Type2) || (couple[1] == TypeGen.Type1 && couple[0] == TypeGen.Type2))
            {
                results.Increase += 20;
                results.Stamine += 20;
            }
            if((couple[0] == TypeGen.Type2 && couple[1] == TypeGen.Type3) || (couple[1] == TypeGen.Type2 && couple[0] == TypeGen.Type3))
            {
                results.Stamine += 3;
                results.Diversity += 5;
            }
            if((couple[0] == TypeGen.Type2 && couple[1] == TypeGen.Type4) || (couple[1] == TypeGen.Type2 && couple[0] == TypeGen.Type4))
            {
                results.Stamine += 17;
                results.Sintez += 25;
            }
            if((couple[0] == TypeGen.Type2 && couple[1] == TypeGen.Type5) || (couple[1] == TypeGen.Type2 && couple[0] == TypeGen.Type5))
            {
                results.Stamine += 17;
                results.StressResistance += 25;
            }
            if ((couple[0] == TypeGen.Type1 && couple[1] == TypeGen.Type3) || (couple[1] == TypeGen.Type1 && couple[0] == TypeGen.Type3))
            {
                results.Increase += 25;
                results.Diversity += 2;
            }
            if((couple[0] == TypeGen.Type1 && couple[1] == TypeGen.Type4) || (couple[1] == TypeGen.Type1 && couple[0] == TypeGen.Type4))
            {
                results.Increase += 19;
                results.Sintez += 5;
            }
            if((couple[0] == TypeGen.Type1 && couple[1] == TypeGen.Type5) || (couple[1] == TypeGen.Type1 && couple[0] == TypeGen.Type5))
            {
                results.Increase += 16;
                results.StressResistance += 7;
            }
            if((couple[0] == TypeGen.Type3 && couple[1] == TypeGen.Type4) || (couple[1] == TypeGen.Type3 && couple[0] == TypeGen.Type4))
            {
                results.Diversity += 7;
                results.Sintez += 10;
            }
            if((couple[0] == TypeGen.Type3 && couple[1] == TypeGen.Type5) || (couple[1] == TypeGen.Type3 && couple[0] == TypeGen.Type5))
            {
                results.Diversity += 9;
                results.StressResistance += 13;
            }
            if((couple[0] == TypeGen.Type4 && couple[1] == TypeGen.Type5) || (couple[1] == TypeGen.Type4 && couple[0] == TypeGen.Type5))
            {
                results.Sintez += 13;
                results.StressResistance += 4;
            }
        }
        OnResult.Invoke(results);
       
    }
   
}
