using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSelect : MonoBehaviour
{
    public bool matchFound;

    // checking for neighbors of selected item
    public List<itemSelect> neighborList = new List<itemSelect>();

    public GameObject selector;
    public bool isSelected = true;
    public int itemID;

    

    Vector3[] checkDirs = new Vector3[4] { Vector3.left, Vector3.right, Vector3.up, Vector3.down };

    //public int touchCount = Input.touchCount;

    // Start is called before the first frame update
   

    private void Start()
    {
        

        toggleSelector();

        StartCoroutine(DestroyFunction());
    }




    
    private void OnMouseDown()
    {

        if(Board.instance.CheckIfItemMoving())
        {
            //if the board is not changing, then continue the function
            return;
        }
        Debug.Log("Clicked");
        getAllNeighbors();
        

        if(!Board.instance.isSwapping)
        {
            toggleSelector();

            //Swap items

            Board.instance.SwapItems(this);

        }
    }

    

    private void OnMouseUpAsButton()
    {
      //  toggleSelector();
    }

    public void toggleSelector()
    {
        isSelected = !isSelected;
        selector.SetActive(isSelected);
    }


    void getAllNeighbors()
    {
        //clears list
        neighborList.Clear();

        for (int i = 0; i < checkDirs.Length; i++)
        {
            neighborList.Add(GetNeighbor(checkDirs[i]));
        }

    }
    
    // get a single neighbor, send raycast in all 4 directions
    public itemSelect GetNeighbor(Vector3 checkDir)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, checkDir, out hit))
        {
            if(hit.collider != null)
            {
                return hit.collider.GetComponent<itemSelect>();
            }
        }
        return null;
    }



    public itemSelect GetNeighbor(Vector3 checkDir, int id)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, checkDir, out hit, 0.8f))
        {
            itemSelect b = hit.collider.GetComponent<itemSelect>();
            if(b!=null && b.itemID == id)
            {
                return b;
            }


            if (hit.collider != null)
            {
                return hit.collider.GetComponent<itemSelect>();
            }
        }
        return null;
    }

    public bool CheckIfNeighbor(itemSelect item)
    {
        if (neighborList.Contains(item))
        {
            return true;
        }
        return false;
    }

    List<itemSelect> FindMatch(Vector3 checkDir)
    {
        List<itemSelect> matchList = new List<itemSelect>();
        List<itemSelect> checkList = new List<itemSelect>();

        checkList.Add(this);

        for (int i = 0; i < checkList.Count; i++)
        {
            itemSelect b = checkList[i].GetNeighbor(checkDir, itemID);
            if(b != null && itemID == b.itemID)
            {
                checkList.Add(b);
            }
        }

        matchList.AddRange(checkList);
        return matchList;
    }

    void ClearMatch(Vector3[] dirs)
    {
        List<itemSelect> matchingItems = new List<itemSelect> ();
        List<itemSelect> sortedList = new List<itemSelect> ();

        for (int i = 0; i < dirs.Length; i++)
        {
            matchingItems.AddRange(FindMatch(dirs[i]));

        }

        //erase all doubles
        for (int i = 0; i < matchingItems.Count; i++)
        {
            if(!sortedList.Contains(matchingItems[i]))
            {
                sortedList.Add(matchingItems[i]);
            }

        }


        //check for more than 3 items
        if(sortedList.Count >= 3)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                //all items in list marked as destoryable
                sortedList[i].matchFound = true;


                //Clear itemList



                //Destroy items


            
                //Create new items
            }
        }

    }


    public void ClearAllMatches()
    {
        ClearMatch(new Vector3[2] {Vector3.left, Vector3.right});
        ClearMatch(new Vector3[2] { Vector3.up, Vector3.down });

        //report to Board script that matches are done
        Board.instance.ReportTurnDone();

    }

   


    IEnumerator DestroyFunction()
    {
        while (true)
        {
            if (matchFound)
            {
                //report a score


                // create a new item


                // remove old item
                Board.instance.CreateNewItem(this, transform.position);
                Destroy(gameObject);

                yield break;

            }
            yield return new WaitForSeconds(0.25f);
        }
    }




    //--- Check that there are possible matches on the board ---//
    public bool CheckNeighbours(itemSelect b)
    {

        getAllNeighbors();
        if(neighborList.Contains(b))
        {
            return true;
        }
        return false;
    }



}
