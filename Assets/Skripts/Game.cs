using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static NewPlayer Player => NewPlayer.Instance;
    public static PlayerInventory Inventory => NewPlayer.Instance.Inventory;
}
