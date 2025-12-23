using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public PlayerXp playerXp;

    private void Start()
    {
        levelText.text = "Level " + playerXp.level;
    }
    private void Update()
    {
        levelText.text = "Level " + playerXp.level;
    }
}
