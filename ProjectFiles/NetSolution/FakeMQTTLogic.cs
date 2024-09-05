#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.SQLiteStore;
using FTOptix.Store;
#endregion

public class FakeMQTTLogic : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        insertFakeDataTask = new PeriodicTask(InsertFakeData, 1000, LogicObject);
        insertFakeDataTask.Start();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        insertFakeDataTask?.Dispose();
    }

    private void InsertFakeData()
    {
        // ----------------------------------------------------------------
        // This is a fake method to insert data into the database
        // it will emulate the MQTT subscriber adding data to the database
        // ----------------------------------------------------------------

        // List of the tables to be used by the random method
        var dataTables = new string[] { "Line1", "Line2", "Line3" };
        var random = new Random();
        // Get a random table name from the list
        var tableName = dataTables[random.Next(0, dataTables.Length)];

        // Get the Database object from the current project
        var myStore = Project.Current.Get<Store>("DataStores/EmbeddedDatabase");
        // Get the table object from the database
        var myTable = myStore.Tables.Get<Table>(tableName);
        // Prepare the header for the insert query (list of columns)
        string[] columns = { "Speed", "Counter", "Timestamp" };
        // Create the new object, a bidimensional array where the first element
        // is the number of rows to be added, the second one is the number
        // of columns to be added (same size of the columns array)
        var values = new object[1, 3];
        // Set some values for each column
        values[0, 0] = (UInt32) random.Next(-5, 5);
        values[0, 1] = (UInt32) random.Next(-5, 5);
        values[0, 2] = DateTime.Now;
        // Perform the insert query
        myTable.Insert(columns, values);
        // Some log for users
        Log.Debug("InsertFakeData", tableName + " - Speed: " + values[0, 0] + " - Counter: " + values[0, 1]);
    }

    private PeriodicTask insertFakeDataTask;
}
