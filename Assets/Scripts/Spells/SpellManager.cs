using UnityEngine;
using System.Collections.Generic;

public class SpellManager: MonoBehaviour
{
    Fighter parent;
    List<Spell> passives = new List<Spell>();
    List<Spell> spells = new List<Spell>();

    public void Init(Fighter parent, GameObject[] spellPrefabs, GameObject[] passivePrefabs)
    {
        this.parent = parent;
        for (int i = 0; i < passivePrefabs.Length; i++)
        {
            GameObject spellObj = Instantiate(passivePrefabs[i], transform);
            Spell passive = spellObj.GetComponent<Spell>();
            passives.Add(passive);
            passive.SetCaster(parent);
        }
        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            GameObject spellObj = Instantiate(spellPrefabs[i], transform);
            Spell spell = spellObj.GetComponent<Spell>();
            spells.Add(spell);
            spell.SetCaster(parent);
        }
    }

    public void Cast(int index, Fighter target, Vector3 position)
    {
        if (index < 0 || index >= spells.Count)
        {
            Debug.LogError("Invalid spell index: " + index);
            return;
        }
        spells[index].Init(target, position);
        parent.ChangeAction(new CastSpell(spells[index], parent));
    }
}