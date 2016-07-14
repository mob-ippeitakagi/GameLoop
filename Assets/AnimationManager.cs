using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AnimationManager
{
    public List<IEnumerator> Animations = new List<IEnumerator>();

    public IEnumerator VanishGem()
    {
        Debug.Log("ジェムが消える");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator AttackParticleToEnemy(Unit diver, Unit enemy)
    {
        Debug.LogFormat("{0} から {1} にパーティクル飛ぶ", diver.Name, enemy.Name);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator AttackParticleToParty(Unit enemy)
    {
        Debug.LogFormat("{0} から パーティ にパーティクル飛ぶ", enemy.Name);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator DeadEnemy(Unit enemy)
    {
        Debug.LogFormat("{0} の死亡演出", enemy.Name);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator Win()
    {
        Debug.Log("勝利！");
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel("Result");
    }

    public IEnumerator Lose()
    {
        Debug.Log("敗北...");
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel("Result");
    }
}
