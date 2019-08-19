using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrestlingMatch : MonoBehaviour
{
    public NPC npc;

    public Text enemyHpText;
    public Text playerHpText;

    public Animator enemyAnimator;
    public Animator playerAnimator;

    public int enemyMaxHp = 20;
    public int playerMaxHp = 16;

    public string enemyName = "The Verenator";
    public string playerName = "Pepe pewpew";

    public Text enemyNameText;
    public Text playerNameText;

    public GameObject enemyBackground;
    public GameObject playerBackground;

    public Vector2 returnPosition;

    public Image heart;

    private int enemyCurrentHp;
    private int playerCurrentHp;

    private const string hpPrefix = "HP: ";
    private const string hpDivider = " / ";

    private void Start()
    {
        enemyCurrentHp = enemyMaxHp;
        playerCurrentHp = playerMaxHp;
        UpdateHpTexts();
        enemyNameText.text = enemyName;
        playerNameText.text = playerName;
        npc.OnInteraction();
    }

    private void UpdateHpTexts()
    {
        enemyHpText.text = hpPrefix + enemyCurrentHp + hpDivider + enemyMaxHp;
        playerHpText.text = hpPrefix + playerCurrentHp + hpDivider + playerMaxHp;
    }

    public string OnLine(string line)
    {
        string returnString = "";
        string[] split = line.Split('_');

        if(split[1] == "pa")
        {
            int damage = int.Parse(split[2]);
            StartCoroutine(PlayerAttackSequence(damage));
            returnString = playerName + " attacks for " + damage + " damage!";
        }

        if (split[1] == "va")
        {
            int damage = int.Parse(split[2]);
            StartCoroutine(EnemyAttackSequence(damage));
            returnString = enemyName + " attacks for " + damage + " damage!";
        }

        if (split[1] == "love")
        {
            playerAnimator.SetTrigger("love");
            enemyAnimator.SetTrigger("love");
            enemyBackground.SetActive(false);
            playerBackground.SetActive(false);
            StartCoroutine(ActivateHeartDelayed());
            returnString = "Love is in the air! <3";
        }

        if (split[1] == "end")
        {
            Game.instance.scenes.SwitchToScene("3_Wrestling", returnPosition);
        }

        return returnString;
    }

    private IEnumerator PlayerAttackSequence(int damage)
    {
        playerAnimator.SetTrigger("attack");
        yield return new WaitForSeconds(0.25f);
        enemyCurrentHp -= damage;
        UpdateHpTexts();
    }

    private IEnumerator EnemyAttackSequence(int damage)
    {
        enemyAnimator.SetTrigger("attack");
        yield return new WaitForSeconds(0.25f);
        playerCurrentHp -= damage;
        UpdateHpTexts();
    }

    private IEnumerator ActivateHeartDelayed()
    {
        yield return new WaitForSeconds(1f);
        heart.enabled = true;
    }
}
