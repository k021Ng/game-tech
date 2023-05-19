using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuickDemo;

public class Main : MonoBehaviour
{
    public static Main Inst;

    public string heroRace;
    public string heroClass;
    public string heroWeapon;
    public int heroLevel;
    public int enemyIndex;
    public ActorRender heroRender;
    public ActorRender monsterRender;

    [Header("DEBUG")]
    public bool debugHeroState;
    public int debugHeroStrength;
    public int debugHeroIntelligence;
    public int debugHeroWillpower;
    public int debugHeroAgility;
    public int debugHeroEndurance;
    public int debugHeroPersonality;
    public int debugHeroSpeed;
    public int debugHeroLuck;

    [Header("RUNTIME")]
    public Hero hero;
    public Monster monster;

    void Awake()
    {
        Inst = this;

        UnityEngine.Random.InitState((int)Time.time);

        // Races.Init();
        Classes.Init();
        Items.Init();
        Spells.Init();

        hero = heroRender.gameObject.AddComponent<Hero>();
        hero.gameObject.AddComponent<ActorEffect>();
        hero.AssignCharacter(heroLevel);
        hero.StatReroll();
        if (debugHeroState)
        {
            hero.stats.SetPermanentStatValue(Stats.Strength, debugHeroStrength);
            hero.stats.SetPermanentStatValue(Stats.Intelligence, debugHeroIntelligence);
            hero.stats.SetPermanentStatValue(Stats.Willpower, debugHeroWillpower);
            hero.stats.SetPermanentStatValue(Stats.Agility, debugHeroAgility);
            hero.stats.SetPermanentStatValue(Stats.Endurance, debugHeroEndurance);
            hero.stats.SetPermanentStatValue(Stats.Personality, debugHeroPersonality);
            hero.stats.SetPermanentStatValue(Stats.Speed, debugHeroSpeed);
            hero.stats.SetPermanentStatValue(Stats.Luck, debugHeroLuck);
        }
        heroRender.actor = hero;

        monster = monsterRender.gameObject.AddComponent<Monster>();
        monster.gameObject.AddComponent<ActorEffect>();
        monsterRender.actor = monster;


        MobileEnemy mobileEnemy = null;
        for (int i = 0; i < MobileEnemies.Enemies.Length; ++i)
        {
            if (MobileEnemies.Enemies[i].ID == enemyIndex)
            {
                mobileEnemy = MobileEnemies.Enemies[i];
                break;
            }
        }
        if (enemyIndex >= 0 && enemyIndex <= 42)
        {
            monster.EntityType = EntityTypes.EnemyMonster;
            monster.SetEnemyCareer(mobileEnemy, EntityTypes.EnemyMonster);
        }
        else if (enemyIndex >= 128 && enemyIndex <= 146)
        {
            monster.EntityType = EntityTypes.EnemyClass;
            monster.SetEnemyCareer(mobileEnemy, EntityTypes.EnemyClass);
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // hero.WeaponDamage(null, false, false, monster, Vector3.zero, Vector3.zero);
            // heroRender.Attack();
        }
    }

    public uint ToClassicDaggerfallTime()
    {
        return (uint)Time.time;
    }

    public void HeroAttack()
    {
        hero.WeaponDamage(null, false, false, monster, Vector3.zero, Vector3.zero);
        heroRender.Attack();
    }

    public void MonsterAttack()
    {
        monster.MeleeDamage(hero);
        monsterRender.Attack();
    }
}
