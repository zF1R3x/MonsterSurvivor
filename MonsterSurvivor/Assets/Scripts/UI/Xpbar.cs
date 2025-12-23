using UnityEngine;
using UnityEngine.UI;
public class Xpbar : MonoBehaviour
{
    public PlayerXp playerXp;
    public Image xpbar;
    private void Start()
    {
        xpbar.fillAmount = playerXp.currentXP / playerXp.maxXP;
    }
    private void Update()
    {
        xpbar.fillAmount = playerXp.currentXP / playerXp.maxXP;
    }
}
