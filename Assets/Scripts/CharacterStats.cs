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
    public int baseExp = 250;

    public int hp;
    public int maxHP = 100;
    public int baseMP = 5;
    public int mp;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defense;
    public int power;
    public int armorClass;
    public string weapon;
    public string armor;
    public Sprite sprite;

    void Start()
    {
        mpLvlBonus = new int[maxLevel];
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;

        // Initialize experience to next level and mp.
        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.5f);

            if(i % 3 == 0)
            {
                mpLvlBonus[i] += Mathf.FloorToInt(baseMP * i / 3);
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        experience += expToAdd;

        if(level < maxLevel)
        {
            if(experience > expToNextLevel[level])
            {
                // Reset experience.
                experience -= expToNextLevel[level];

                level++;
            
                // Determine whether to add to strength or defense.
                if(level % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                hp = maxHP;

                maxMP += mpLvlBonus[level];
                mp = maxMP;
            }
        }
        
        if(level >= maxLevel)
        {
            experience = 0;
        }
    }
}
