using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static Player Player => Player.Instance;
    public static PlayerInventory Inventory => Player.Instance.Inventory;
}
