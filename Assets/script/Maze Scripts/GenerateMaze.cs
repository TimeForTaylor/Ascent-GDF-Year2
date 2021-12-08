using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    public GameObject wall;
    int i, j;

    private int[,] worldMap = new int[10, 10]
    {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 0, 1, 0, 0, 0, 0, 0, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
        {1, 0, 1, 0, 0, 0, 0, 0, 0, 1},
        {1, 0, 1, 1, 1, 1, 0, 0, 0, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 1, 1, 1},
        {1, 0, 0, 1, 0, 0, 0, 0, 0, 1},
        {1, 0, 1, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };
    
    // Add this method: 
    void LoadLevel()
    {
        for (i = 0; i < worldMap.GetLength(0); i++)
        {
            for (j = 0; j < worldMap.GetLength(1); j++)
            {
                GameObject t;
                if (worldMap[i, j] == 1)
                {
                    t = (GameObject) (Instantiate(wall, new Vector3(50 - i * 10, 1.5f, 50 - j * 10), Quaternion.identity));
                }
            }
        }
    } 
    
    void LoadLevelFromFile()
    {
        int count1=0, count2=0, count3=0;
        //Load a text file (Assets/Resources/level01.txt) 
        var t1=Resources.Load<TextAsset>("level02"); 
        
        string s1 = t1.text;
        
        //Debug.Log(s1);
        for (i = 0; i < s1.Length; i++)
        {
            if (s1[i] == '\n')
            {
                count1 = count1 + 1;
                if (count1 == 1)
                {
                    count2 = i-1;
                }
            }
        }
        
        //Debug.Log(count1);
        //Debug.Log(count2);
        
        s1 = s1.Replace("\n","");
        //Debug.Log(s1.Length);
        
        for(i=0;i<s1.Length;i++)
        {
            Debug.Log(s1[i]);
            // if the char s[i] is '1' then add a wall 
            if(s1[i] == '1')
            {
                int column, row;
                column = count3 % 10;
                
                row = count3 / 10; 
                GameObject t = (GameObject)(Instantiate(wall, new Vector3(50-column*10, 1.5f, 50-row*10),Quaternion.identity));
                
                //Debug.Log(column);
                //Debug.Log(row);
                count3 = count3 + 1;
            } 
            else if (s1[i] == '0')
            {
                //Debug.Log(i);
                count3 = count3 + 1;
            }
        } 
    } 

    void Start()
    {
        //LoadLevel();
        LoadLevelFromFile();
    }

    void Update()
    {
        
    }
}
