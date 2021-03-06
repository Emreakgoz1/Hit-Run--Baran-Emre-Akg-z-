using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Cubes;
    public Transform startPos;

    public List<Color> WallColors = new List<Color>();

    public int numberOfRows;
    public int objectsPerRows;
    public int whitecubeCounter = 0;
    public float spacing;

    Rigidbody Temporary_RigidBody;

    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        WallColors.Clear();
        WallColors.Add(Color.white);
        WallColors.Add(Color.red);
        WallColors.Add(Color.green);
        WallColors.Add(Color.blue);

        int[] colorsArray = new int[numberOfRows * objectsPerRows];
        int activeColor = 0;
        int i = 0;

        if (numberOfRows>3&&objectsPerRows>3)
        {
            startPos.position = new Vector3((startPos.position.x + (numberOfRows * -0.2f)), startPos.position.y + (objectsPerRows*0.4f), startPos.position.z);
        }
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int column = 0; column < objectsPerRows; column++)
            {
                Vector3 startingPos = new Vector3(startPos.position.x + column * spacing, startPos.position.y - row * spacing, startPos.position.z);
                Transform _Cubes = Instantiate(Cubes, startingPos, Quaternion.identity);

                if (i > 1)
                {
                    if (colorsArray[i - 2] == 0 && colorsArray[i - 1] == 0)
                    {
                        activeColor = Random.Range(1, WallColors.Count);
                    }
                    else if (colorsArray[i - 2] != 0 && colorsArray[i - 2] != 0)
                    {
                        activeColor = 0;
                    }
                    else
                    {
                        activeColor = Random.Range(0, WallColors.Count);
                    }
                }
                else
                {
                    activeColor = Random.Range(0, WallColors.Count);
                }
                colorsArray[i] = activeColor;
                _Cubes.GetComponent<Renderer>().material.color = WallColors[activeColor];
                if (activeColor != 0)
                {
                    _Cubes.tag = "Destroyable";
                }
                else
                {
                    Temporary_RigidBody = _Cubes.transform.gameObject.GetComponent<Rigidbody>();
                    Temporary_RigidBody.isKinematic = true;
                    whitecubeCounter++;
                }
                i++;
            }
        }
    }
    
    


}
