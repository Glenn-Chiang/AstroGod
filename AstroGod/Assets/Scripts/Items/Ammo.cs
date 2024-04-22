using UnityEngine;

public enum AmmoType
{
    Energy,
    Bullet,
    Shell,
    Rocket
}

[CreateAssetMenu(fileName = "AmmoData", menuName = "Item/Ammo")]
public class AmmoData : ScriptableObject
{

}