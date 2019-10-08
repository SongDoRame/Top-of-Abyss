using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 머꼬!!
    public int _hp;                // 체력
    public int _damage;            // 공격력
    public int _defence;           // 방어력
    public int _evasion;           // 회피율
    public int _accuracy;          // 적중률
    
    // 회피 여부
    public virtual bool AttackSuccess(int accuracy, int evasion)
    {
        if ((accuracy - evasion) < 100)
        {
            int attackNumber = Random.Range(0, 100);
            if (attackNumber >= (accuracy - evasion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    // 데미지 계산
    public virtual int OnDamage(bool attackSuccess, int damage, int defence)
    {
        if (attackSuccess)
        {
            // 계산한 데미지값이 0보다 클경우
            if ((damage - defence) > 0)
            {
                return damage - defence;
            }
            // 작거나 같을 경우
            else
            {
                return 1;
            }
        }
        // 회피일 때 
        else
        {
            return 0;
        }
    }

    public virtual void Die()
    {
        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
