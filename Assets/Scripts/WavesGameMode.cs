using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    [SerializeField] private Life playerBaseLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesManager.instance.enemies.Count <=0 && WavesManager.instance.waves.Count <=0) {

            SceneManager.LoadScene("WinScreen");
        }

        if (playerLife.amount <= 0) {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
    }

    void OnPlayerOrBaseDied() {
        SceneManager.LoadScene("LoseScreen");
    }

    void OnPlayerDied() {
        SceneManager.LoadScene("LoseScreen");
    }
}
