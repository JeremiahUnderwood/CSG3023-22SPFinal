/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Spawns bircks
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
   
    public GameObject brickPrefab;                    //reference to brick prefab
    public float paddingBetweenBricks = 0.25f;        //space betwen bricks
    private Vector2 brickPadding = new Vector2(0,0);  //actual varable used to place the brick objects at certain coordinates


    // Start is called before the first frame update
    void Start()
    {

       //brick padding is the width/height of the brick plus the padding between
       brickPadding.x = brickPrefab.transform.localScale.x + paddingBetweenBricks;
       brickPadding.y = brickPrefab.transform.localScale.y + paddingBetweenBricks;

        //create bricks in a 7x7 rectangle
        for (int y=0; y < 7; y++)
        {
            for(int x=0; x < 7; x++)
            {
                Vector3 pos = new Vector3(x * brickPadding.x , y * brickPadding.y, 0); 
              
                GameObject brickGo = Instantiate(brickPrefab); //fixed instantiate call that was causing error
              
                brickGo.transform.parent = transform; //initialise transform
                brickGo.transform.localPosition = pos; //set position

            }//end for(int x=0; x < 9; x++)
        }//end for (int y=0; y < 9; y++)
    }

}
