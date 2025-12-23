using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;
    public Sprite icon;

    public UpgradeType type;
    public int amount; // how much stat increases

    public enum UpgradeType
    {
        IncreaseDamage,
        IncreaseFireRate,
        IncreaseMoveSpeed,
        IncreaseMaxHealth,
        HealPlayer,
        AddNewWeapon
    }
}
