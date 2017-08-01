using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {

public Transform enemyPrefab;

public Transform spawnPoint;
public float timeBetweenWaves=5f;
public float countdown = 2f;

public Text waveCountdownText;

private int waveIndex = 0;

/// <summary>
/// Update is called every frame, if the MonoBehaviour is enabled.
/// </summary>
void Update()
{
	if(countdown<=0f)
	{
		StartCoroutine(SpawnWave());
		countdown = timeBetweenWaves;
	}
	countdown -=Time.deltaTime;

// Ucina miejsca po przecinku nie zaokrąglając
	waveCountdownText.text = Mathf.Floor(countdown).ToString();
}

IEnumerator SpawnWave()
{
	waveIndex++;
	
	for(int i = 0;i<waveIndex;i++)
	{
		SpawnEnemy();
		yield return new WaitForSeconds(0.5f);
	}
}
void SpawnEnemy()
{
	Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
}

}
