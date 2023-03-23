using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName="Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] private string name;
    
    [TextArea]
    [SerializeField]
    private string description;
    
    [SerializeField] private GameObject pokemonModel;
    [SerializeField] private PokemonType type1;
    [SerializeField] private PokemonType type2;
    
    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    [SerializeField] private int spAttack;
    [SerializeField] private int spDefense;
    [SerializeField] private int speed;

    [SerializeField] private List<LearnableMove> _learnableMoves;

    public int Speed => speed;

    public int SpDefense => spDefense;

    public int SpAttack => spAttack;

    public int Defense => defense;

    public int Attack => attack;

    public int MaxHp => maxHp;

    public PokemonType Type2 => type2;

    public PokemonType Type1 => type1;

    public GameObject PokemonModel => pokemonModel;

    public string Description => description;

    public string Name => name;
    public List<LearnableMove> LearnableMoves => _learnableMoves;

}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] private MoveBase _moveBase;
    [SerializeField] private int level;


    public int Level => level;

    public MoveBase MoveBase => _moveBase;
}

public enum PokemonType
{
    Normal,
    Fire,
    Water,
    Grass,
    Electric,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}
