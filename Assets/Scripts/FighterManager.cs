using UnityEngine;

public class FighterManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    Fighter player;

    Fighter[] fighters;
    
    void Start()
    {
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Fighter>();
    }
}