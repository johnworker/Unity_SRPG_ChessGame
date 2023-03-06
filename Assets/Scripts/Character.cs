using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Character : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;

    // ���Ⲿ�ʤ�k
    public void Move(Vector3 destination)
    {
        // TODO: ��{���Ⲿ�ʪ��N�X
    }

    // ���������k
    public void Attack(Character target)
    {
        // TODO: ��{����������N�X
    }

    // ������������k
    public void TakeDamage(int damage)
    {
        // TODO: ��{�������������N�X
    }
}
#region ��{�ʧ@�I�t��
//��{�ʧ@�I�t�ΡG
//�bSRPG�C�����A����M�ĤH�ݭn���@�w���ʧ@�I�ƶq�A�H�K�b�C�^�X������ާ@�C���F��{�o�ӥ\��A�Ыؤ@�����Ӫ�ܰʧ@�I�C
#endregion
public class ActionPoints
{
    public int maxPoints;
    public int currentPoints;

    // �C�^�X�����ɭ��m�ʧ@�I�ƶq
    public void Reset()
    {
        currentPoints = maxPoints;
    }

    // ��ְʧ@�I�ƶq
    public void Decrease()
    {
        currentPoints--;
    }

    // �P�_�O�_���������ʧ@�I�ƶq
    public bool CanUse()
    {
        return currentPoints > 0;
    }

    #region �޲z�Ө��⪺�ʧ@�I
    //�bCharacter�����K�[�@��ActionPoints��H�A�Ω�޲z�Ө��⪺�ʧ@�I�C
    #endregion
    public ActionPoints actionPoints;

    #region ��{�԰��t��
    //��{�԰��t�ΡG
    //�bSRPG�C�����A����M�ĤH�����ݭn�i������M���m�C���F��{�o�ӥ\��A�Ыؤ@��BattleSystem���C
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
    #region �ͩR��
    //�b�����������ɡA�]�i�H�ϥγo�Ӥ�k�p���ڦ������ͩR��
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
                // TODO: ���⦺�`���N�X
            }
        }

    #region ��{���ʨt��
    //��{���ʨt�ΡG
    //�bSRPG�C�����A����ݭn�b�a�ϤW���ʡC���F��{�o�ӥ\��A�Ыؤ@��Map���A��ܦa�ϡC
    #endregion
    public class Map
    {
        public int width;
        public int height;
        public Tile[,] tiles;

        // ������w��m��Tile��H
        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }

        // �ˬd���w��m�O�_�i�H����
        /*public bool CanMove(int x, int y)
        {
            Tile tile = GetTile(x, y);
            return tile.isPassable;
        }*/
    }


}
