using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFromImage : MonoBehaviour
{
    //2Darrayofpixels 
    private Color[,]colourOfPixel;
    public GameObject tallWall, bigItem;
    public Texture2D levelBitmap;

    void InitLevel()
    {
        // set the array based on image width and height 
        colourOfPixel = new Color[levelBitmap.width, levelBitmap.height];
        // read the pixels the same as the 1st example with a nested forloop. 
        for(int i=0; i < levelBitmap.width; i++)
        {
            for(int j = 0; j < levelBitmap.height; j++)
            {
                // convert pixels to walls 
                colourOfPixel[i,j] = levelBitmap.GetPixel(i,j);
                if(colourOfPixel[i,j] == Color.black)
                { 
                    int column,row;
                    column = i - (levelBitmap.width / 2);
                    row = j - (levelBitmap.height / 2); 
                    //add a wall 
                    GameObject t = (GameObject)(Instantiate(tallWall, new Vector3(column, 1.5f, row), Quaternion.identity));
                }
                
                else if(colourOfPixel[i,j] == Color.red)
                { 
                    int column,row;
                    column = i - (levelBitmap.width / 2);
                    row = j - (levelBitmap.height / 2); 
                    //add a wall 
                    GameObject t = (GameObject)(Instantiate(bigItem, new Vector3(column, 1.5f, row), Quaternion.identity));
                }
                
                else if (colourOfPixel[i, j] == Color.green)
                {
                    
                }
                
                else if (colourOfPixel[i, j] == Color.blue)
                {
                    
                }
                
                else if (colourOfPixel[i, j] == Color.yellow)
                {
                    
                }
                
                else if (colourOfPixel[i, j] == Color.magenta)
                {
                    
                }
                
                else if (colourOfPixel[i, j] == Color.cyan)
                {
                    
                }
            }
        } 
    }
    
    void Start()
    {
        InitLevel();
    }
}
