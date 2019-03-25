﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;

namespace Assets.Scripts.Database
{
    class Meca : SQliteHelper
    {
        private const String Tag = "Riz: Meca:\t";

        private const String TABLE_NAME = "CerebralAreas";
        private const String KEY_ID = "id";
        private const String KEY_NOUN = "noun";

        private String[] COLUMNS = new String[] { KEY_ID, KEY_NOUN };

        // Create table if doesn't exist
        public Meca() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_NOUN + " TEXT )";
            dbcmd.ExecuteNonQuery();
        }

        // Add entry to the table
        public void addData(string noun)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_NOUN + " ) "

                + "VALUES ( '"
                + "" + "', '"
                + noun + "' )";
            dbcmd.ExecuteNonQuery();
        }

        // Return informations of the line at a given id
        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        // Return informations of the line at a given string
        public override IDataReader getDataByString(string str)
        {
            Debug.Log(Tag + "Getting Location: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        // Delete data of the line at a given string
        public override void deleteDataByString(string id)
        {
            Debug.Log(Tag + "Deleting Location: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        // Delete data of the line at a given id
        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        // Delete all content of the table
        public override void deleteAllData()
        {
            Debug.Log(Tag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        // Return all the data of the table
        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }
    }
}
