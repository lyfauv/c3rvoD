#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endif

public class ShowActivationOnClick : MonoBehaviour
{
#if UNITY_EDITOR
    db data;
    SqliteConnection dbconn;
    Renderer rend;
    GameObject targetArea;
    GameObject mechaPanel;

    // Start is called before the first frame update
    void Start()
    {
        mechaPanel = GameObject.FindWithTag("MechaSelect");
    }

    // Change color of given object in white
    public void AllWhite(string areaName)
    {
        GameObject area = GameObject.Find(areaName);
        rend = area.GetComponentInChildren<Renderer>();
        rend.material.color = Color.white;

    }

    // Conection to database
    public void Connect()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/c3rvoD.db"; //Path to database.
        dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
    }

    // Change color of activated areas (for a given mechanism)
    public void ShowActivation(Button clickedButton)
    {
        int mechaId = 0;
        Connect();
        // Get all area names to change color of the objects to white (sort of reset)
        SqliteCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT name " + "FROM Area";
        dbcmd.CommandText = sqlQuery;
        SqliteDataReader reader = dbcmd.ExecuteReader();
        List<string> areaNames = new List<string>();

        while(reader.Read())
        {
            areaNames.Add(reader.GetString(0));
        }

        reader.Close();
        reader = null;

        foreach(string name in areaNames)
        {
            AllWhite(name);
        }

        // Query to database to select the right mechanism
        dbcmd = dbconn.CreateCommand();
        string buttonName = Convert.ToString(clickedButton.name);

        sqlQuery = "SELECT id_meca " + "FROM mechanisms" + " WHERE " + "name" + " = '" 
            + buttonName + "'";
        
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();

        // we keep the right id (appears multiple times in database but has a unique value)
        if(reader.Read())
            mechaId = reader.GetInt32(0);
        reader.Close();
        reader = null;

        // Find area names of those involved in the chosen mechanism
        sqlQuery = "SELECT id_area FROM linkMechaArea WHERE id_mecha ="
            + mechaId;

        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();

        List<int> areaIds = new List<int>();
        List<Color> colors = new List<Color>();
        colors.Add(Color.green);
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.yellow);


        // Find the right gameObjects to change their color
        while (reader.Read())
        {
            // get area ids
            int id = reader.GetInt32(0);
            areaIds.Add(id);
        }

        reader.Close();
        reader = null;

        int i = 0;

        // Find the right area objects
        foreach (int id in areaIds)
        {
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT name " + "FROM Area" +
                       " WHERE id_area = " + id;
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                string name = reader.GetString(0);
                targetArea = GameObject.Find(name);
                rend = targetArea.GetComponentInChildren<Renderer>();

                // Change area color
                rend.material.color = colors[i%2];

                reader.Close();
                reader = null;
                i++;
            }
        }

        // Display mechanism name
        mechaPanel = GameObject.FindWithTag("MechaSelect");
        mechaPanel.GetComponentInChildren<Text>().text = buttonName;

        GameObject selectionMecha = GameObject.Find("SelectMechaPanel");
        selectionMecha.SetActive(false);

        // Close access to database
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
#endif
}
