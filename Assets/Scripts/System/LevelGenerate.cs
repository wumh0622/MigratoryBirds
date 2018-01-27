using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour {

	public static LevelGenerate instence;
    [SerializeField] float scrollingSpeed;
    Camera mainCamera;

	void Awake()
	{
		if(instence == null)
		{
            instence = this;
        }
		else
		{
            Destroy(gameObject);
        }
	}

    void Start()
    {
        mainCamera = Camera.main;
        EnemyBase.speed = scrollingSpeed;
        Island.speed = scrollingSpeed;
        BackGroundScrollDown.speed = scrollingSpeed;
    }

	//背景圖片生成
    #region 
    [SerializeField] GameObject backGround;

    public void GenerateBackGround()
	{
        for (int i = 1; i <= 2; i++)
        {
            GameObject clone = Instantiate(backGround);
            clone.transform.position = new Vector3(0, 2f * i * mainCamera.orthographicSize, 0);
            clone.transform.localScale = new Vector3(2f * mainCamera.orthographicSize * mainCamera.aspect, 2f * mainCamera.orthographicSize, 0);
        }
    }
    #endregion

    //島嶼生成與敵人生成
    #region 
    [SerializeField] GameObject[] goodIsland;
    [SerializeField] GameObject[] badIsland;
    [SerializeField] GameObject[] enemy;
    [Range(0,100)]
    public int goodIslandChances;
    [Range(0,100)]
    public int badIslandChances;
    [Range(0,100)]
    [SerializeField] int enemySpawnChances;
    int badCount;

    public void GenerateIsland()
	{
        float randomValue = Random.value * (goodIslandChances + badIslandChances + enemySpawnChances);
        
        if(randomValue < goodIslandChances)
        {
            InstantiatePrefab(goodIsland);
        }
        else if(randomValue-goodIslandChances <badIslandChances)
        {
            if (badCount < 8)
            {
                InstantiatePrefab(badIsland);
            }
            else
            {
                InstantiatePrefab(goodIsland);
                badCount = 0;
            }
            badCount++;
        }
        else
        {
            InstantiatePrefab(enemy);
        }
    }

    #endregion

    void InstantiatePrefab(GameObject[] prefabs)
    {
        GameObject clone = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
        clone.transform.position = new Vector3(Random.Range(-mainCamera.orthographicSize * mainCamera.aspect, 
                                        mainCamera.orthographicSize * mainCamera.aspect)
                                        , mainCamera.orthographicSize + 1, 0);
    }


}
