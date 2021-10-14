using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//nell'edificio fabbro metterò attualmente pochi potenziamenti per ora, in quanto son ancora in fase di decisione/bilanciamento
public class Fabbro : MonoBehaviour
{
    //------------------ soldati ------------------------
    public void powerUPSword(Soldiers.Swordsmen swordman)
    {
        int x = swordman.getAtk() + 1;     //una singola funzione che viene richiamata ogni qual volta viene fatto un lvl up che aumenta di 1 l'ATK
    }
    public void powerUPBow(Soldiers.Archers archer)
    {
        int x = archer.getAtk() + 1;      //una singola funzione che viene richiamata ogni qual volta viene fatto un lvl up che aumenta di 1 l'ATK
    }
    public void powerUPSaddle(Soldiers.Riders rider)
    {
        int x = rider.getAtk() + 1;       //una singola funzione che viene richiamata ogni qual volta viene fatto un lvl up che aumenta di 1 l'ATK
    }

    //----------------economia-------------------------

    public int zappa = 0;
    public int zappa2 = 0;
    public void powerUPZappa ()
    {
        zappa = 1;
    }
    public void powerUPZappa2()
    {
        zappa2 = 1;
    }

}
