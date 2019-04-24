using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;

public class DisplayInfoOnClick : MonoBehaviour
{
    GameObject mechaPanel;
    SqliteConnection dbconn;
    Menu menu;
    GameObject infoPanel;

    // Start is called before the first frame update
    void Start()
    {
        infoPanel = GameObject.Find("Info");
    }

    // Connection to database
    public void Connect()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/c3rvoD.db"; //Path to database.
        dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
    }
    
    // call when user clic on a brain area
    public void OnMouseDown()
    {
        mechaPanel = GameObject.Find("MechaSelect");
        string mechaName = mechaPanel.GetComponentInChildren<Text>().text;

        if (mechaName != "c3rvoD") // a mechanism has been selected
        {
            //infoPanel = GameObject.Find("Info");
            Connect();

            // Get the right mechanism id
            SqliteCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT id_meca " + "FROM mechanisms " + "WHERE name ='" + mechaName + "'";
            int mechaId = 0;
            dbcmd.CommandText = sqlQuery;
            SqliteDataReader reader = dbcmd.ExecuteReader();

            if (reader.Read())
                mechaId = reader.GetInt32(0);

            reader.Close();
            reader = null;

            // Get the right area id
            string areaName = gameObject.name;
            int areaId = 0;

            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT id_area " + "FROM Area " + "WHERE name ='" + areaName + "'";
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            if (reader.Read())
                areaId = reader.GetInt32(0);
            
            reader.Close();
            reader = null;

            // Query to get the right info
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT info " + "FROM linkMechaArea" + " WHERE id_mecha =" + mechaId + 
                " AND id_area = " + areaId;
            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();

            if (reader.Read())
            {
                infoPanel.SetActive(true);
                infoPanel.GetComponentInChildren<Text>().text = reader.GetString(0);
            }

            reader.Close();
            reader = null;


            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;

        }
    }
}
