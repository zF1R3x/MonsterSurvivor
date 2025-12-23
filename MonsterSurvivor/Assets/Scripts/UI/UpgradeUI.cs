using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public GameObject panel;
    public UpgradeData[] allUpgrades;
    public LevelUpManager upgradeManager;

    public Button[] buttons;
    public Image[] icons;
    public TMP_Text[] titles;
    public TMP_Text[] descriptions;

    UpgradeData[] chosenUpgrades = new UpgradeData[3];

    public void ShowUpgrades()
    {
        panel.SetActive(true);

        // Pick 3 random upgrades
        for (int i = 0; i < 3; i++)
        {
            chosenUpgrades[i] = allUpgrades[Random.Range(0, allUpgrades.Length)];
            Debug.Log(allUpgrades.Length);

            icons[i].sprite = chosenUpgrades[i].icon;
            titles[i].text = chosenUpgrades[i].upgradeName;
            descriptions[i].text = chosenUpgrades[i].description;

            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => ChooseUpgrade(index));
        }
        Time.timeScale = 0f;
    }

    public void ChooseUpgrade(int index)
    {
        upgradeManager.ApplyUpgrade(chosenUpgrades[index]);

        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}

