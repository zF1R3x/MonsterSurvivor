using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    public float currentXP;
    public float maxXP;
    private float excessXP;
    public int level = 1;
    public AudioClip xpClip;
    public AudioClip levelClip;
    private UpgradeUI upgradeUI;
    private void Start()
    {
        currentXP = 0;
        maxXP = 5;
        upgradeUI = FindFirstObjectByType<UpgradeUI>();
    }

    private void Update()
    {
        if(currentXP >= maxXP)
        {
            excessXP = currentXP - maxXP;
            currentXP = 0;
            level++;
            upgradeUI.ShowUpgrades();
            if (level <= 10)
            {
                maxXP = maxXP + 3;
            } else if (level <= 20)
            {
                maxXP = maxXP + 5;
            } else if (level <= 30)
            {
                maxXP = maxXP + 8;
            }
            
            currentXP = excessXP;
            SoundManager.instance.PlaySoundClip(levelClip, transform, 1f);
        }
    }

    public void AddXP(float _value)
    {
        currentXP = currentXP + _value;
        SoundManager.instance.PlaySoundClip(xpClip, transform, 0.5f);
    }
}
