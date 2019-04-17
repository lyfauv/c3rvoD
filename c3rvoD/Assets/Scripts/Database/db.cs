using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
public class db : MonoBehaviour
{
    SqliteConnection dbconn;
    GameObject selectionMecha;
    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/c3rvoD.db"; //Path to database.
        dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        // Find all objects needed
        selectionMecha = GameObject.Find("SelectMechaPanel");


        //// Query to database
        //SqliteCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT name " + "FROM Area";
        //dbcmd.CommandText = sqlQuery;
        //SqliteDataReader reader = dbcmd.ExecuteReader();

        //while (reader.Read())
        //{
        //    string name = reader.GetString(0);
        //    Debug.Log("name =" + name);
        //}
        //reader.Close();
        //reader = null;
        //dbcmd.Dispose();
        //dbcmd = null;
        //dbconn.Close();
        //dbconn = null;
    }

    // Display all buttons created via data in database, on prefab's model MechaButton
    public void SelectMechaOnClick()
    {
        GameObject mainMenu = GameObject.Find("Main Menu");
        

        // Display mechanisms selection menu
        mainMenu.SetActive(false);
        selectionMecha.SetActive(true);

        // Query to database
        SqliteCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT name " + "FROM mechanisms";
        dbcmd.CommandText = sqlQuery;
        SqliteDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            GameObject newButton = Instantiate(buttonPrefab, selectionMecha.transform);
            newButton.name = name;
            newButton.GetComponentInChildren<Text>().text = name;
            newButton.SetActive(true);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
