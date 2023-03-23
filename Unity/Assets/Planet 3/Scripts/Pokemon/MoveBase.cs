using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] private string name;

    [TextArea] [SerializeField] private string description;
    [SerializeField] private PokemonType type;
    [SerializeField] private int power;
    [SerializeField] private int accuracy;
    [SerializeField] private int pp;

    public int Pp => pp;

    public int Accuracy => accuracy;

    public int Power => power;

    public PokemonType Type => type;

    public string Description => description;

    public string Name => name;
}
