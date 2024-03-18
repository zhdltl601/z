using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInventory inventory;
    
    public static List<Player> players;

    public void KillMyself()
    {
        print("fuck died");
    }

}
