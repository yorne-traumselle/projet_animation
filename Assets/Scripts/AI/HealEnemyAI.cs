using UnityEngine;

public class HealEnemyAI : MonoBehaviour
{
    Fighter self;
    FighterManager fighterManager;
    Fighter targetAlly;

    void Start()
    {
        self = GetComponent<Fighter>();
        fighterManager = self.GetFighterManager();
    }

    void Update()
    {
        if (targetAlly == null || targetAlly.FighterState != FighterState.Alive || targetAlly.IsFullHealth())
        {
            foreach (Fighter ally in fighterManager.enemies)
            {
                if (ally.FighterState == FighterState.Alive && !ally.IsFullHealth())
                {
                    targetAlly = ally;
                    break;
                }
            }
        }

        if (targetAlly != null)
        {
            self.SpellManager.Cast(0, targetAlly, targetAlly.transform.position);
        }
    }
}