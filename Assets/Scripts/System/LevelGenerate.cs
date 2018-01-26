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
    }

	//背景圖片生成
    [SerializeField] GameObject backGround;

    public void GenerateBackGround()
	{
        BackGroundScrollDown.speed = scrollingSpeed;
        for (int i = 1; i <= 2; i++)
        {
            GameObject clone = Instantiate(backGround);
            clone.transform.position = new Vector3(0, 2f * i * mainCamera.orthographicSize, 0);
            clone.transform.localScale = new Vector3(2f * mainCamera.orthographicSize * mainCamera.aspect, 2f * mainCamera.orthographicSize, 0);
        }
    }

    //島嶼生成

    [SerializeField] GameObject[] goodIsland;
    [SerializeField] GameObject[] badIsland;
    [Range(0,100)]
    public int goodIslandChances;
    [Range(0,100)]
    public int badIslandChances;
    int badCount;

    public void GenerateIsland()
	{
        float randomValue = Random.value * (goodIslandChances + badIslandChances);
        Island.speed = scrollingSpeed;
        if(randomValue < goodIslandChances)
        {
            InstantiateIsland(goodIsland);
            /* GameObject clone = Instantiate(goodIsland[Random.Range(0, goodIsland.Length)]);
            clone.transform.position = new Vector3(Random.Range(-mainCamera.orthographicSize * mainCamera.aspect,
                                        mainCamera.orthographicSize * mainCamera.aspect)
                                        , mainCamera.orthographicSize + .2f, 0); */
        }
        else
        {
            if (badCount < 8)
            {
                InstantiateIsland(badIsland);
            }
            else
            {
                InstantiateIsland(goodIsland);
                badCount = 0;
            }
            /*  GameObject clone = Instantiate(badIsland[Random.Range(0, badIsland.Length)]);
             clone.transform.position = new Vector3(Random.Range(-mainCamera.orthographicSize * mainCamera.aspect, 
                                         mainCamera.orthographicSize * mainCamera.aspect)
                                         , mainCamera.orthographicSize + 1, 0); */
            badCount++;
        }

    }

    void InstantiateIsland(GameObject[] island)
    {
        GameObject clone = Instantiate(island[Random.Range(0, island.Length)]);
        clone.transform.position = new Vector3(Random.Range(-mainCamera.orthographicSize * mainCamera.aspect, 
                                        mainCamera.orthographicSize * mainCamera.aspect)
                                        , mainCamera.orthographicSize + 1, 0);
    }


}
