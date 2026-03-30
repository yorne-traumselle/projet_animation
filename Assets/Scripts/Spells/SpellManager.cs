using UnityEngine;

public class SpellManager: MonoBehaviour
{
    Fighter parent;
    Spell[] passives;
    Spell[] spells;    

    public SpellManager(Fighter parent, GameObject[] spellPrefabs, GameObject[] passivePrefabs)
    {
        this.parent = parent;
        passives = new Spell[passivePrefabs.Length];
        for (int i = 0; i < passivePrefabs.Length; i++)
        {
            GameObject spellObj = Instantiate(passivePrefabs[i], transform);
            passives[i] = spellObj.GetComponent<Spell>();
            passives[i].SetCaster(parent);
        }
        spells = new Spell[spellPrefabs.Length];
        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            GameObject spellObj = Instantiate(spellPrefabs[i], transform);
            spells[i] = spellObj.GetComponent<Spell>();
            spells[i].SetCaster(parent);
        }
    }

    public void Cast(int index, Fighter target, Vector3 position)
    {
        if (index < 0 || index >= spells.Length)
        {
            Debug.LogError("Invalid spell index: " + index);
            return;
        }
        spells[index].Init(target, position);
    }
}