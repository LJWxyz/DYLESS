using UnityEngine;
using System.Collections;

public class Equipable : HandInteractable
{
    [SerializeField] GameObject EquipableGameObj;
    public void Start()
    {EquipableGameObj = gameObject;}

    //Invoked when a button is pressed.
    public void SetParent(GameObject Player)
    {
        EquipableGameObj.transform.parent = Player.transform;
        if (Player.transform.parent != null)
        {
        }
    }

    public void DetachFromParent()
    {EquipableGameObj.transform.parent = null;
    }
}