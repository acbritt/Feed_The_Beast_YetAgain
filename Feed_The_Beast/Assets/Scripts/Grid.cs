using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update

    public static Grid instance;

    public int width;
    public int height;

    public GameObject[] itemList;


    public bool isSwapping;

    itemSelect lastItem; //for swapping
    itemSelect item1,item2; //for storing actual items
    Vector3 item1StartPos, item1EndPos, item2StartPos, item2EndPos;

    void Start()
    {
        FillBoard();
    }


    private void Awake()
    {
        instance = this;
    }

    void FillBoard()
    {
        for (int i = 0; i < width; i++)
        { 
            for (int j = 0; j < height; j++)
            { 
                int randomIndex = Random.Range(0, itemList.Length);
                //spawns random item from list
                GameObject newItem = Instantiate(itemList[randomIndex], new Vector3(transform.position.x + i, transform.position.y + j, 0), Quaternion.identity) as GameObject;

                //all created blobs are child objects of the board
                newItem.transform.parent = this.transform;
            }
        }
    }

    // only ran in editor (will not run in the game build)
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        for (int i = 0; i < width; i++)
        { // i is increased until it matches the width
            for (int j = 0; j < height; j++)
            { // loops first to the width, and then to the height
                Gizmos.DrawWireCube(new Vector3(transform.position.x + i, transform.position.y + j, 0), new Vector3(1,1,1));
            }
        }
    }


#endif

    public void SwapItems(itemSelect currentItem)
    {
        if(lastItem == null)
        {
            lastItem = currentItem;
        }
        else if(lastItem == currentItem)
        {
            lastItem = null;
        }
        else 
        {
            if (lastItem.CheckIfNeighbor(currentItem))
            { // do actual swap
                item1 = lastItem;
                item2 = currentItem;

                item1StartPos = lastItem.transform.position;
                item1EndPos = currentItem.transform.position;

                item2StartPos = currentItem.transform.position;
                item2EndPos = lastItem.transform.position;

                //start swapping mechanic
            }
            else
            { // no swap

            }

        }


    }


    
}
