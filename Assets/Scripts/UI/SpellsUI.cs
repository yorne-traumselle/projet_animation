using UnityEngine;
using UnityEngine.UI;

public class SpellsUI: MonoBehaviour
{
    [SerializeField]
    FighterManager fighter_manager;

    [SerializeField]
    Image cover1;
    [SerializeField]
    Image cover2;
    [SerializeField]
    Image cover3;
    [SerializeField]
    Image cover4;

    void Update()
    {
        if (fighter_manager.Player != null)
        {   
            Debug.Log("Spell 1 cooldown: " + fighter_manager.Player.GetSpellCooldown(0) + " / " + fighter_manager.Player.GetSpellCooldownTime(0));
            
            cover1.fillAmount = fighter_manager.Player.GetSpellCooldown(0) / fighter_manager.Player.GetSpellCooldownTime(0);

            cover2.fillAmount = fighter_manager.Player.GetSpellCooldown(1) / fighter_manager.Player.GetSpellCooldownTime(1);

            cover3.fillAmount = fighter_manager.Player.GetSpellCooldown(2) / fighter_manager.Player.GetSpellCooldownTime(2);

            cover4.fillAmount = fighter_manager.Player.GetSpellCooldown(3) / fighter_manager.Player.GetSpellCooldownTime(3);
        }
    }
}