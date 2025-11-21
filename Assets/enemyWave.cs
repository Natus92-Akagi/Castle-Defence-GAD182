using UnityEngine;

public class enemyWave : MonoBehaviour
{
    [Header("Wave Stats")]
    public float waveTimer;
    public float waveTimerStart;
    public int waveDifficulty;
    public bool gameStarted = false;

    [Header("X Position on Spawn")]
    public float summonRangeLow;
    public float summonRangeHigh;
    public float summonRange;

    //GameObject with EnemyControl on it
    public GameObject enemy;

    void Start()
    {
        gameStarted = true;
        waveTimer = 9f;
        //waveTimerStart = 0f;
        waveDifficulty = 1;
    }

    void summonWave()
    {
        //Run function num of times equal to waveDifficulty
        for (int i = 0; i < waveDifficulty; i++)
        {
            //Randomize X
            float randomX = Random.Range(summonRangeLow, summonRangeHigh);
            //Spawn Enemy at Random X
            Instantiate(enemy, new Vector3(randomX, -3.719f, 0f), Quaternion.identity);
        }
    }

    void Update()
    {
        //Count up Wave Timer
        waveTimer += Time.deltaTime;

        //Summon a Wave of Enemies
        if (waveTimer >= waveTimerStart)
        {
            waveTimer = 0f;
            Debug.Log("A wave was summoned!");
            summonWave();
            waveDifficulty += 1;

        }
    }
}
