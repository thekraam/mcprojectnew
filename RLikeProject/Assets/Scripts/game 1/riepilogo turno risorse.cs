using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class riepilogoturnorisorse : MonoBehaviour
{
    int crescitaCittadiniRiep;
    int gold;
    int cittadiniMAX;
    //---------------------------cittadini-----------------------------
    public int cittadiniRiep(Fattoria fattoria)
    {
        crescitaCittadiniRiep = fattoria.getCrescitaAbitanti();
        return crescitaCittadiniRiep;
    }


    //---------------------------gold-----------------------------
    public int goldRiep(Fattoria fattoria, Miniera miniera, int x, Fabbro fabbro)
    {
        gold = fattoria.getGoldFattoria() + miniera.getgoldMiniera() + 2*x + 20*fabbro.zappa*fattoria.getLvlFattoria() + 20*fabbro.zappa2*fattoria.getLvlFattoria();
        return gold;
    }

    public int cittadiniMAXRiep(Fattoria fattoria)
    {
        cittadiniMAX = fattoria.getAbitantiMax();
        return cittadiniMAX;
    }

}
