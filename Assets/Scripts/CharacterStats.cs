using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public string name;
    public int level = 1;
    public int experience;
    public int[] expToNextLevel;
    public int maxLevel = 20;

    public int hp;
    public int maxHP = 100;
    public int mp;
    public int maxMP = 30;
    public int strength;
    public int defence;
    public int power;
    public int armorClass;
    public string weapon;
    public string armor;
    public Sprite sprite;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
