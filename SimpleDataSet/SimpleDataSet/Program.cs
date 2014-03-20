using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;   //for serializing in a binary format.


namespace SimpleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with DataSets ****\n");

            //Create the DataSet object and add a few properties
            DataSet carsInventoryDS = new DataSet("Car Inventory");

            carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventoryDS.ExtendedProperties["Company"] = "Northwest BMW";

            FillDataSet(carsInventoryDS);
            ManipulateDataRowState();
            Console.WriteLine();

            PrintDataSet(carsInventoryDS);
            Console.WriteLine();

            SaveAndLoadAsXML(carsInventoryDS);

            SaveAndLoadAsBinary(carsInventoryDS);

            Console.ReadLine();
        }

        //Manually create columns and rows and add them to the data table
        static void FillDataSet(DataSet ds)
        {
            /*Create the data colums that map to the 'real' columns in the
             Inventory table of the AutoLot database.*/
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
            carIDColumn.Caption = "Car ID";
            carIDColumn.ReadOnly = true;
            carIDColumn.AllowDBNull = false;
            carIDColumn.Unique = true;
            carIDColumn.AutoIncrement = true;
            carIDColumn.AutoIncrementSeed = 0;
            carIDColumn.AutoIncrementStep = 1;

            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";      //for display purposes

            //Now add the DataColumns to a DataTable
            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });
            inventoryTable.PrimaryKey = new DataColumn[] { inventoryTable.Columns[0] };

            //Now add some rows to the Inventory table
            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["PetName"] = "Hamlet";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            //Column 0 is the autoincremented ID field, so start at 1.
            carRow[1] = "Saab";
            carRow[2] = "Red";
            carRow[3] = "Sea Breeze";
            inventoryTable.Rows.Add(carRow);

            //Finally, add our table to the DataSet.
            ds.Tables.Add(inventoryTable);
        }

        //Manually manipulate row data, printing the row state along the way.
        private static void ManipulateDataRowState() 
        {
            //create a new temporary DataTable for testing
            DataTable tempTable = new DataTable("TempTable");
            tempTable.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            //RowState = Detached (i.e. row has been created, but in not part of a DataTable yet.)
            DataRow row = tempTable.NewRow();
            Console.WriteLine("After calling NewRow(): {0}", row.RowState);

            //RowState = Added
            tempTable.Rows.Add(row);
            Console.WriteLine("After calling Rows.Add(): {0}", row.RowState);

            //RowState = Added
            row["TempColumn"] = 10;
            Console.WriteLine("After first assignment: {0}", row.RowState);

            //RowState = Unchanged
            tempTable.AcceptChanges();
            Console.WriteLine("After calling AcceptChanges(): {0}", row.RowState);

            //RowState = Modified
            row["TempColumn"] = 11;
            Console.WriteLine("After first assignment: {0}", row.RowState);

            //RowState = Added
            tempTable.Rows[0].Delete();
            Console.WriteLine("After calling Delete(): {0}", row.RowState);
        }

        //Print out the DataSet name and any extended properties.
        static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
            Console.WriteLine();

            //Print out each table.
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("=> {0} Table:", dt.TableName);

                //print out the column names
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                }
                Console.WriteLine("\n----------------------------------------\n");

                //Print the table using the PrintTable method
                PrintTable(dt);

                Console.WriteLine("\nManual print of table: \n");
                //print the DataTable Manually
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }


        /*Utilizes a DataTableReader to provide a single model to process
         data from a table regardless of which layer of ADO.NET is used to obtain it.*/
        static void PrintTable(DataTable dt)
        {
            DataTableReader dtReader = dt.CreateDataReader();

            //The DataTableReader works just like DataReader
            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.Write("{0}\t", dtReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }

        //Serialize the DataTable/DataSet objects as XML
        static void SaveAndLoadAsXML(DataSet carsInventoryDS)
        {
            //Save this DataSet as XML
            carsInventoryDS.WriteXml("carsDataSet.xml");
            carsInventoryDS.WriteXmlSchema("carsDataSet.xsd");

            //Clear out the DataSet;
            carsInventoryDS.Clear();

            //Load DataSet from XML
            carsInventoryDS.ReadXml("carsDataSet.xml");
        }

        static void SaveAndLoadAsBinary(DataSet carsInventoryDS)
        {
            //Set binary serialization flag.
            carsInventoryDS.RemotingFormat = SerializationFormat.Binary;

            //Save this DataSet as binary
            FileStream fs = new FileStream("BinaryCars.bin", FileMode.Create);

            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(fs, carsInventoryDS);
            fs.Close();

            //Clear out the DataSet
            carsInventoryDS.Clear();

            //Load the DataSt from binary file
            fs = new FileStream("BinaryCars.bin", FileMode.Open);
            DataSet data = (DataSet)bFormat.Deserialize(fs);
        }

    }
}
