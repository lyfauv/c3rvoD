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
    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/c3rvoD.db"; //Path to database.
        SqliteConnection dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

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

    public void SelectMechaOnClick()
    {
        GameObject SelectionMecha = GameObject.Find("SelectMechaPanel");
    }
}
