using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update

    public static Board instance;
    
    public int width;
    public int height;

    public int MatchScore;

    public GameObject[] itemList; //prefabs list
    List<itemSelect> allItemsList = new List<itemSelect>();

    public bool isSwapping;
    bool turnChecked;

    itemSelect lastItem; //for swapping
    itemSelect item1,item2; //for storing actual items
    Vector3 item1StartPos, item1EndPos, item2StartPos, item2EndPos;

   

   
    void Start()
    {
        FillBoard();
        //TogglePhysics(false);

        StartCoroutine(BoardCheck());

        MatchScore = 0;


        StartCoroutine(CheckScore());
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
                GameObject newItem = Instantiate(itemList[randomIndex], new Vector3(transform.position.x + i, transform.position.y + j , 0), Quaternion.identity) as GameObject;

                allItemsList.Add(newItem.GetComponent<itemSelect>());

                //all created blobs are child objects of the grid
                newItem.transform.parent = this.transform;
            }
        }
       
    }

    void TogglePhysics(bool on)
    {
        for (int i = 0; i < allItemsList.Count; i++)
        {
            allItemsList[i].GetComponent<Rigidbody>().isKinematic = on;
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
                StartCoroutine(SwapItems());
            }
            else
            { // no swap
                lastItem.toggleSelector();
                lastItem = currentItem;
            }

        }


    }

    IEnumerator SwapItems()
    {
        if (isSwapping)
        {
            yield break;
        }

        isSwapping = true;
        //toggle all physics
        TogglePhysics(true);
     

        //swap
        while (MoveToSwapLocation(item1, item1EndPos) && MoveToSwapLocation(item2, item2EndPos)) { yield return null; }


        //has been a match
        item1.ClearAllMatches();
        item2.ClearAllMatches();

        while (!turnChecked) { yield return null; }
        if(!item1.matchFound  &&  !item2.matchFound)
        {
            //swap back if there is no match
            while (MoveToSwapLocation(item1, item1StartPos) && MoveToSwapLocation(item2, item2StartPos)) { yield return null; }
        }
        turnChecked = false;


        isSwapping = false;
        //reset all
        TogglePhysics(false);

        
        lastItem = null;
        item1.toggleSelector();
        item2.toggleSelector();

    }

    bool MoveToSwapLocation (itemSelect b, Vector3 swapGoal)
    {
        return b.transform.position != (b.transform.position = Vector3.MoveTowards(b.transform.position, swapGoal, 2 * Time.deltaTime));
    }


    public void CreateNewItem(itemSelect b, Vector3 pos)
    {
        allItemsList.Remove(b);
        //create a new one

        int randItem = Random.Range(0, itemList.Length);
        GameObject newItem = Instantiate(itemList[randItem], new Vector3(pos.x, pos.y + 10f, pos.z), Quaternion.identity);
        allItemsList.Add(newItem.GetComponent<itemSelect>());


        //Adds to score system
        MatchScore++;
        

        newItem.transform.parent = transform;

        TogglePhysics(false);

    }

    public void ReportTurnDone()
    {
        turnChecked = true;
    }


    public bool CheckIfItemMoving()
    {
        for (int i = 0; i < allItemsList.Count; i++)
        {
            if (allItemsList[i].transform.localPosition.y > 4.1f)
            {
                //means items are moving
                return true;
            }

            if(allItemsList[i].GetComponent<Rigidbody>().velocity.y > 0.02f)
            {
                return true;
            }
  
        }
        return false;

    }

    IEnumerator BoardCheck()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (!isSwapping  &&  !CheckIfItemMoving())
            {
                for (int i = 0; i < allItemsList.Count; i++)
                {
                    allItemsList[i].ClearAllMatches();
                }
            }

            yield return new WaitForSeconds(0.25f);
        }

    }




  

    IEnumerator CheckScore()
    {
        yield return new WaitForSeconds(.5f);

         //   var spawnEgg = Instantiate(Egg_model, new Vector3(1.5f, 3.4f, 1.15f), Quaternion.identity);

       

        
            
        
    }



    //--- Check that there are possible matches on the board ---//

        /*
    bool CheckForPossibleMatch()
    {
        TogglePhysics(true);
        for (int i = 0; i < allItemsList.Count; i++)
        {
            for (int j = 0; j < allItemsList.Count; j++)
            {
                if(allItemsList[i].CheckNeighbours(allItemsList[j]))
                {
                    //simulate a swap, temporarily swap items to check for a match
                    itemSelect b1 = allItemsList[i];
                    itemSelect b2 = allItemsList[j];

                    //neighbour list
                    List<itemSelect> tempNeighbours = new List<itemSelect>(b1.neighborList);
                    //Swap location
                    Vector3 b1TempPos = b1.transform.position;
                    Vector3 b2TempPos = b2.transform.position;

                }
            }
        }
    }
    */
}
