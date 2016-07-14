using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Unit
{
    public int ID;
    public string Name;
    public int HP;
    public int Attack;
    public override string ToString()
    {
        return string.Format("{0}: {1}", Name, HP);
    }
}

public class PartyManager
{
    public List<Unit> Party;
    public int TotalHP;
    public void Initialize()
    {
        Debug.Log("パーティの初期化");
        Party = new List<Unit>()
        {
            new Unit() {
                ID = 1,
                Name = "主人公",
                HP = 100,
                Attack = 30
            },
            new Unit() {
                ID = 2,
                Name = "博士",
                HP = 80,
                Attack = 20
            }
        };
        TotalHP = Party.Sum(x => x.HP);
    }
    public override string ToString()
    {
        return string.Format("パーティ: {0}", TotalHP);
    }
}
public class EnemyManager
{
    public List<Unit> Enemies;
    public void Initialize()
    {
        Debug.Log("敵の初期化");
        Enemies = new List<Unit>()
        {
            new Unit() {
                ID = 1,
                Name = "クマA",
                HP = 60,
                Attack = 10
            },
            new Unit() {
                ID = 2,
                Name = "クマB",
                HP = 40,
                Attack = 8
            }
        };
    }
    public override string ToString()
    {
        return string.Join(", ", Enemies.Select(x => x.ToString()).ToArray());
    }
}
