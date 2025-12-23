using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public AutoWeapon weapon;
    public Projectile projectile;

    public void ApplyUpgrade(UpgradeData upgrade)
    {
        switch (upgrade.type)
        {
            case UpgradeData.UpgradeType.IncreaseDamage:
                projectile.damage += upgrade.amount;
                break;

            case UpgradeData.UpgradeType.IncreaseFireRate:
                weapon.fireRate -= (upgrade.amount * 0.01f);
                if (weapon.fireRate < 0.1f) weapon.fireRate = 0.1f;
                break;

            case UpgradeData.UpgradeType.IncreaseMoveSpeed:
                playerMovement.moveSpeed += (upgrade.amount*0.01f);
                break;

            case UpgradeData.UpgradeType.IncreaseMaxHealth:
                playerHealth.maxHealth += upgrade.amount;
                playerHealth.currentHealth += upgrade.amount;
                break;

            case UpgradeData.UpgradeType.HealPlayer:
                playerHealth.currentHealth = Mathf.Min(playerHealth.maxHealth, 
                playerHealth.currentHealth + upgrade.amount);
                break;
        }
    }
}