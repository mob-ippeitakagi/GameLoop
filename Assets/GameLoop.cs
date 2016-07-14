using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameLoop : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Button gemButton;
    [SerializeField] Button skillButton;
    [SerializeField] Button giveupButton;

    AnimationManager animationManager = new AnimationManager();
    PartyManager partyManager = new PartyManager();
    EnemyManager enemyManager = new EnemyManager();

    IEnumerator Start()
    {
        Debug.Log("===== ゲームスタート =====");
        yield return StartCoroutine(initialize());
        gemButton.onClick.AddListener(() =>
        {
            Debug.Log("ジェム消した");
            StartCoroutine(onDeleteGem());
        });
        skillButton.onClick.AddListener(() =>
        {
            Debug.Log("スキル使った（未実装）");
        });
        giveupButton.onClick.AddListener(() =>
        {
            Debug.Log("諦める");
            Application.LoadLevel("Result");
        });
    }

    IEnumerator initialize()
    {
        Debug.Log("盤面の初期化");
        partyManager.Initialize();
        Debug.Log(partyManager);
        enemyManager.Initialize();
        Debug.Log(enemyManager);
        yield return null;
    }

    IEnumerator onDeleteGem()
    {
        canvasGroup.interactable = false;
        // ロジック処理
        calculateResult();
        // アニメーション
        yield return StartCoroutine(executeAnimations());
        Debug.Log(partyManager);
        Debug.Log(enemyManager);
        canvasGroup.interactable = true;
    }

    void calculateResult()
    {
        animationManager.Animations.Add(animationManager.VanishGem());
        // こっちのターン
        foreach (var diver in partyManager.Party)
        {
            var target = enemyManager.Enemies.FirstOrDefault(x => x.HP > 0)
                      ?? enemyManager.Enemies.Last();
            target.HP -= diver.Attack;
            animationManager.Animations.Add(animationManager.AttackParticleToEnemy(diver, target));
            if (target.HP <= 0)
            {
                target.HP = 0;
                animationManager.Animations.Add(animationManager.DeadEnemy(target));
            }
        }
        if (!enemyManager.Enemies.Any(x => x.HP > 0))
        {
            animationManager.Animations.Add(animationManager.Win());
            return;
        }
        // 敵のターン
        foreach (var enemy in enemyManager.Enemies)
        {
            partyManager.TotalHP -= enemy.Attack;
            animationManager.Animations.Add(animationManager.AttackParticleToParty(enemy));
            if (partyManager.TotalHP <= 0)
            {
                partyManager.TotalHP = 0;
                animationManager.Animations.Add(animationManager.Lose());
                return;
            }
        }
    }

    IEnumerator executeAnimations()
    {
        Debug.Log("===== アニメーション開始 =====");
        foreach (var animation in animationManager.Animations)
        {
            yield return StartCoroutine(animation);
        }
        Debug.Log("===== アニメーション終了 =====");
    }
}

