using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public string fileName = ""; // Name of the text file you want to read

    void Start()
    {
        // Get the path to the text file in the Assets folder
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read the text from the file
            string fileText = File.ReadAllText(filePath);

            // Output the text to the console
            Debug.Log("File contents: " + fileText);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}
