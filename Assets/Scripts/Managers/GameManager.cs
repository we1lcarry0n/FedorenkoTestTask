using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioSource audioSource;
    public int Killcounter { get; private set; }

    [SerializeField] private TMP_Text killcounterText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TMP_Text gameOverText;

    [SerializeField] private AudioClip gameOverAudioClip;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        Killcounter = 0;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.OnDieEvent += GameOver;
    }

    public void AddKill()
    {
        Killcounter++;
        killcounterText.text = Killcounter.ToString();
    }

    private void GameOver(object sender, System.EventArgs e)
    {
        gameOverMenu.SetActive(true);
        gameOverText.text = gameOverText.text.Insert(14, Killcounter.ToString());
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverAudioClip);
    }

}
