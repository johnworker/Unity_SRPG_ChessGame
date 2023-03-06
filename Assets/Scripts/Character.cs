using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Character : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;

    // 角色移動方法
    public void Move(Vector3 destination)
    {
        // TODO: 實現角色移動的代碼
    }

    // 角色攻擊方法
    public void Attack(Character target)
    {
        // TODO: 實現角色攻擊的代碼
    }

    // 角色受到攻擊方法
    public void TakeDamage(int damage)
    {
        // TODO: 實現角色受到攻擊的代碼
    }
}
#region 實現動作點系統
//實現動作點系統：
//在SRPG遊戲中，角色和敵人需要有一定的動作點數量，以便在每回合中執行操作。為了實現這個功能，創建一個類來表示動作點。
#endregion
public class ActionPoints
{
    public int maxPoints;
    public int currentPoints;

    // 每回合結束時重置動作點數量
    public void Reset()
    {
        currentPoints = maxPoints;
    }

    // 減少動作點數量
    public void Decrease()
    {
        currentPoints--;
    }

    // 判斷是否有足夠的動作點數量
    public bool CanUse()
    {
        return currentPoints > 0;
    }

    #region 管理該角色的動作點
    //在Character類中添加一個ActionPoints對象，用於管理該角色的動作點。
    #endregion
    public ActionPoints actionPoints;

    #region 實現戰鬥系統
    //實現戰鬥系統：
    //在SRPG遊戲中，角色和敵人之間需要進行攻擊和防禦。為了實現這個功能，創建一個BattleSystem類。
    #endregion
    public class BattleSystem
    {
        public static int CalculateDamage(int attack, int defense)
        {
            int damage = attack - defense;
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
    }
    #region 生命值
    //在角色受到攻擊時，也可以使用這個方法計算實際扣除的生命值
    #endregion
    public void Attack(Character target, int attack)
        {
            if (actionPoints.CanUse())
            {
                int damage = BattleSystem.CalculateDamage(attack, target.defense);
                target.TakeDamage(damage);
                actionPoints.Decrease();
            }
        }

        public void TakeDamage(int damage, int health)
        {
            health -= damage;
            if (health <= 0)
            {
                // TODO: 角色死亡的代碼
            }
        }

    #region 實現移動系統
    //實現移動系統：
    //在SRPG遊戲中，角色需要在地圖上移動。為了實現這個功能，創建一個Map類，表示地圖。
    #endregion
    public class Map
    {
        public int width;
        public int height;
        public Tile[,] tiles;

        // 獲取指定位置的Tile對象
        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }

        // 檢查指定位置是否可以移動
        /*public bool CanMove(int x, int y)
        {
            Tile tile = GetTile(x, y);
            return tile.isPassable;
        }*/
    }


}
