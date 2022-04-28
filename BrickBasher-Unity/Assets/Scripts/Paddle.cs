/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle


    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // get axis, smooth with time, and multiply by speed
        Vector3 newPos = this.transform.position;                            // prepare new position
        newPos.x += deltaX;
        this.transform.position = newPos;                                    // set new position
    }//end Update()
}
