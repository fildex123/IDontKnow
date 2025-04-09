using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject enemy;
    public Transform player;
    public int chunkSize = 70;
    public static Dictionary<Vector2Int, Chunks> chunkMap = new Dictionary<Vector2Int, Chunks>();

    private void Start()
    {
        int playx = Mathf.FloorToInt(player.transform.position.x);
        int playy = Mathf.FloorToInt(player.transform.position.y);
    }

    private void Update()
    {
        Vector2Int playerChunkPos = new Vector2Int(
            Mathf.FloorToInt(player.transform.position.x / chunkSize),
            Mathf.FloorToInt(player.transform.position.y / chunkSize)
        );

        for (int x = -2; x <= 2; x++)
        {
            for (int y = -2; y <= 2; y++)
            {
                Vector2Int chunkPos = new Vector2Int(playerChunkPos.x + x, playerChunkPos.y + y);
                if (!chunkMap.ContainsKey(chunkPos))
                {
                    Chunks newChunk = new Chunks(chunkPos.x, chunkPos.y, Random.Range(1, 4));
                    chunkMap.Add(chunkPos, newChunk);
                    Render(newChunk);
                }
                else
                {
                    Render(chunkMap[chunkPos]);
                }
            }
        }
    }

    public void Render(Chunks chunk)
    {
       if (!chunk.vygen)
       {
           chunk.vygen = true;
           chunk.pocplat = Random.Range(3, 9);
           chunk.platx = new int[chunk.pocplat];
            chunk.platy = new int[chunk.pocplat];
            chunk.rendered = new bool[chunk.pocplat];
            chunk.platforma = new GameObject[chunk.pocplat];
            for (int i = 0; i < chunk.pocplat; i++)
            {
                chunk.platx[i] = Random.Range(-chunkSize / 2, chunkSize / 2);
                chunk.platy[i] = Random.Range(-chunkSize / 2, chunkSize / 2);
                Vector3 position = new Vector3(chunk.chunkx * chunkSize + chunk.platx[i], chunk.chunky * chunkSize + chunk.platy[i], 0);
                GameObject newPlatform = Instantiate(platform, position, Quaternion.identity);
                newPlatform.transform.SetParent(transform);
                chunk.platforma[i] = newPlatform;
                chunk.rendered[i] = true;
            }
       }
       else
       {
           for (int i = 0; i < chunk.pocplat; i++)
           {
               if ((Mathf.Abs(chunk.chunkx * chunkSize + chunk.platx[i] - player.transform.position.x) > 400 || Mathf.Abs(chunk.chunky * chunkSize + chunk.platy[i] - player.transform.position.y) > 400))
               {
                    if (chunk.rendered[i])
                    {
                        chunk.rendered[i] = false;
                        Destroy(chunk.platforma[i]);
                    }
               }
               if (!chunk.rendered[i])
               {
                    Vector3 position = new Vector3(chunk.chunkx * chunkSize + chunk.platx[i], chunk.chunky * chunkSize + chunk.platy[i], 0);
                    GameObject newPlatform = Instantiate(platform, position, Quaternion.identity);
                    newPlatform.transform.SetParent(transform);
                    chunk.platforma[i] = newPlatform;
                    chunk.rendered[i] = true;
                }
           }
       }
    }
}

public class Chunks
{
    public bool vygen;
    public int chunkx;
    public int chunky;
    public int pocplat;
    public bool[] rendered;
    public int[] platx;
    public int[] platy;
    public GameObject[] platforma;

    public Chunks(int chunkx, int chunky, int plattyp)
    {
        this.chunkx = chunkx;
        this.chunky = chunky;
        this.vygen = false;
    }
}
