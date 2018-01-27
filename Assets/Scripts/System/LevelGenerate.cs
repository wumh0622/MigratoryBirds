using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{

    public static LevelGenerate instence;
    [SerializeField] float scrollingSpeed;
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] Transform[] islandSpawnPoint;

    [System.Flags]
    public enum GenerateType
    {
        PassiveEnemy_NCNE, PassiveEnemy_NCBH, Drone, Food, Plane, Typhoon
    }

    [EnumFlagsAttribute]
    public GenerateType generateList;
    List<int> slectedList;
    Camera mainCamera;

    void Awake()
    {
        if (instence == null)
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
        Enemy.speed = scrollingSpeed;
        Island.speed = scrollingSpeed;
        BackGroundScrollDown.speed = scrollingSpeed;
        slectedList = ReturnSelectedElements();
                IslandChancesDefault = IslandChances;
        goodIslandChancesDefault = goodIslandChances;
        badIslandChancesDefault = badIslandChances;
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
    [Header("Prefab")]
    [SerializeField]
    GameObject[] goodIsland;
    [SerializeField] GameObject[] badIsland;
    [Tooltip("被動式敵人但是不會主動造成傷害")]
    [SerializeField]
    GameObject[] PassiveEnemy_NCNE;
    [Tooltip("被動式敵人會主動造成傷害")]
    [SerializeField]
    GameObject[] PassiveEnemy_NCBH;
    [SerializeField] GameObject[] Drone;
    [SerializeField] GameObject[] Food;
    [SerializeField] GameObject[] Plane;
    [SerializeField] GameObject[] Typhoon;
    [Space(10)]
    [Range(0, 100)]
    public int IslandChances;
    int IslandChancesDefault;
    [Range(0, 100)]
    public int goodIslandChances;
    int goodIslandChancesDefault;
    [Range(0, 100)]
    public int badIslandChances;
    int badIslandChancesDefault;
    [Range(0, 100)]
    [SerializeField]
    int enemySpawnChances_NCNE;
    [Range(0, 100)]
    [SerializeField]
    int enemySpawnChances_NCBH;
    [Range(0, 100)]
    [SerializeField]
    int DroneChances;
    [Range(0, 100)]
    [SerializeField]
    int FoodChances;
    [Range(0, 100)]
    [SerializeField]
    int PlaneChances;
    [Range(0, 100)]
    [SerializeField]
    int TyphoonChances;
    int badCount;

    bool istyphoon;
    public void GenerateIsland()
    {

        if (Random.value * 100 < IslandChances)
        {
            float randomValue = Random.value * (goodIslandChances + badIslandChances);

            if (randomValue < goodIslandChances)
            {
                InstantiatePrefab(goodIsland, islandSpawnPoint[Random.Range(0, islandSpawnPoint.Length)]);
                if(istyphoon)
                {
                    IslandChances = IslandChancesDefault;
                    goodIslandChances = goodIslandChancesDefault;
                    badIslandChances = badIslandChancesDefault;
                    istyphoon = false;
                }
            }
            else if (randomValue - goodIslandChances < badIslandChances)
            {
                if (badCount < 8)
                {
                    InstantiatePrefab(badIsland, islandSpawnPoint[Random.Range(0, islandSpawnPoint.Length)]);
                }
                else
                {
                    InstantiatePrefab(badIsland, islandSpawnPoint[Random.Range(0, islandSpawnPoint.Length)]);
                    badCount = 0;
                }
                badCount++;
            }
        }
        else
        {
            float randomValue = Random.value * (enemySpawnChances_NCNE + enemySpawnChances_NCBH + DroneChances + FoodChances + PlaneChances + TyphoonChances);
            if (randomValue < enemySpawnChances_NCNE && slectedList.Contains(0))
            {
                InstantiatePrefab(PassiveEnemy_NCNE, spawnPoint[Random.Range(0, spawnPoint.Length)]);
            }
            else if (randomValue - enemySpawnChances_NCNE < enemySpawnChances_NCBH && slectedList.Contains(1))
            {
                InstantiatePrefab(PassiveEnemy_NCBH, spawnPoint[Random.Range(0, spawnPoint.Length)]);
            }
            else if (randomValue - enemySpawnChances_NCNE - enemySpawnChances_NCBH < DroneChances && slectedList.Contains(2))
            {
                InstantiatePrefab(Drone, spawnPoint[Random.Range(0, spawnPoint.Length)]);
            }
            else if (randomValue - enemySpawnChances_NCNE - enemySpawnChances_NCBH - DroneChances < FoodChances && slectedList.Contains(3))
            {
                InstantiatePrefab(Food, spawnPoint[Random.Range(0, spawnPoint.Length)]);
            }
            else if (randomValue - enemySpawnChances_NCNE - enemySpawnChances_NCBH - DroneChances - FoodChances < PlaneChances && slectedList.Contains(4))
            {
                InstantiatePrefab(Plane, spawnPoint[Random.Range(0, spawnPoint.Length)]);
            }
            else if (randomValue - enemySpawnChances_NCNE - enemySpawnChances_NCBH - DroneChances - FoodChances - PlaneChances < TyphoonChances && slectedList.Contains(5))
            {
                InstantiatePrefab(Typhoon, spawnPoint[Random.Range(0, spawnPoint.Length)]);
                istyphoon = true;
                IslandChances = 100;
                goodIslandChances = 100;
                badIslandChances = 0;
            }
        }
    }

    #endregion

    void InstantiatePrefab(GameObject[] prefabs, Transform randomSpawnPoint)
    {
        GameObject clone = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
        clone.transform.position = randomSpawnPoint.position;
    }

    List<int> ReturnSelectedElements()
    {

        List<int> selectedElements = new List<int>();
        for (int i = 0; i < System.Enum.GetValues(typeof(GenerateType)).Length; i++)
        {
            int layer = 1 << i;
            if (((int)generateList & layer) != 0)
            {
                selectedElements.Add(i);
            }
        }

        return selectedElements;

    }


}
