using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowActivationOnClick : MonoBehaviour
{
    db data;
    SqliteConnection dbconn;
    Renderer rend;
    GameObject targetArea;

    // Conection to database
    public void Connect()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/c3rvoD.db"; //Path to database.
        dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
    }

    public void ShowActivation(Button clickedButton)
    {
        int mechaId = 0;
        Connect(); 

        // Query to database to select the right mechanism
        SqliteCommand dbcmd = dbconn.CreateCommand();
        string buttonName = Convert.ToString(clickedButton.name);

        string sqlQuery = "SELECT id_meca " + "FROM mechanisms" + " WHERE " + "name" + " = '" 
            + buttonName + "'";
        
        dbcmd.CommandText = sqlQuery;
        SqliteDataReader reader = dbcmd.ExecuteReader();

        // we keep the right id (appears multiple times in database but has a unique value)
        if(reader.Read())
            mechaId = reader.GetInt32(0);
        reader.Close();
        reader = null;

        // Find area names of those involved in the chosen mechanism
        sqlQuery = "SELECT name " + "FROM Area" + " INNER JOIN linkMechaArea ON Area.id_area = linkMechaArea.id_area" +
            " WHERE Area.id_area = ( " +
            "SELECT linkMechaArea.id_area FROM linkMechaArea WHERE id_mecha ="
            + mechaId + ")";

        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();

        // Find the right gameObjects to change their color
        while(reader.Read())
        {
            string name = reader.GetString(0);
            targetArea = GameObject.Find(name);
            rend = targetArea.GetComponentInChildren<Renderer>();

            // Change area color
            if (rend.material.color == Color.white || rend.material.color == Color.black)
            {
                rend.material.color = Color.green;

            }
            else
                rend.material.color = Color.white;
        }

        GameObject selectionMecha = GameObject.Find("SelectMechaPanel");
        selectionMecha.SetActive(false);


        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
}
