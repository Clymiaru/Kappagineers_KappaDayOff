using System.Collections.Generic;
using UnityEngine;

public class BombCounter : MonoBehaviour
{
    [SerializeField] private GameObject bombIconTemplate;

    private List<GameObject> bombs = new List<GameObject>();

    public void UseBomb()
    {
        if (bombs.Count > 0)
        {
            var toRemove = bombs[0];
            bombs.Remove(toRemove);
        }
    }
}
