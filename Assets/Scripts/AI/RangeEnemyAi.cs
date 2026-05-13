using UnityEngine;

public class RangeEnemyAi : MonoBehaviour
{
    FighterManager fighterManager;
    Fighter self;

    void Start()
    {
        self = GetComponent<Fighter>();
        fighterManager = self.GetFighterManager();
    }

    void Update()
    {
        if (fighterManager.Player != null)
        {
            self.SpellManager.Cast(0, fighterManager.Player, fighterManager.Player.transform.position);
        }
    }
}