using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public PlayerHealth playerHp;
    public Image healthbar;
    private void Start()
    {
        healthbar.fillAmount = playerHp.currentHealth / playerHp.maxHealth;
    }
    private void Update()
    {
        healthbar.fillAmount = playerHp.currentHealth / playerHp.maxHealth;
    }
}
