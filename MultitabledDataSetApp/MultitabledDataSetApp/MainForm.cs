using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace MultitabledDataSetApp
{
    /**!!!! NOTE:  Intermixing UI and data logic in a production level application is NOT RECOMMENDED.
     This is just to demonstate an example of using a DataSet's DataRelation collection for a client
     app to navigate between table data without incurring network round trips.*/

    public partial class MainForm : Form
    {
        //Form wide DataSet
        private DataSet autoLotDS = new DataSet("AutoLot");

        //Utilize command builders to simplify data adapter configuration.
        private SqlCommandBuilder sqlCBInventory;
        private SqlCommandBuilder sqlCBCustomers;
        private SqlCommandBuilder sqlCBOrders;

        //Data adapters for each table
        private SqlDataAdapter inventoryTableAdapter;
        private SqlDataAdapter customersTableAdapter;
        private SqlDataAdapter ordersTableAdapter;

        //Form wide connection string
        private string connStr = string.Empty;

        public MainForm()
        {
            InitializeComponent();

            //get the connection string from the config file
            connStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            //create the adapters
            inventoryTableAdapter = new SqlDataAdapter("Select * From Inventory", connStr);
            customersTableAdapter = new SqlDataAdapter("Select * From Customers", connStr);
            ordersTableAdapter = new SqlDataAdapter("Select * From Orders", connStr);

            //Autogenerate commands
            sqlCBInventory = new SqlCommandBuilder(inventoryTableAdapter);
            sqlCBOrders = new SqlCommandBuilder(ordersTableAdapter);
            sqlCBCustomers = new SqlCommandBuilder(customersTableAdapter);

            //Use the DataAdapters to fill in the DataSets
            inventoryTableAdapter.Fill(autoLotDS, "Inventory");
            ordersTableAdapter.Fill(autoLotDS, "Orders");
            customersTableAdapter.Fill(autoLotDS, "Customers");

            //Build the relationships between the tables
            BuildTableRelationships();

            //Finally, bind the tables to the data grids
            dataGridViewInventory.DataSource = autoLotDS.Tables["Inventory"];
            dataGridViewCustomers.DataSource = autoLotDS.Tables["Customers"];
            dataGridViewOrders.DataSource = autoLotDS.Tables["Orders"];
        }


        /*BuildTableRelationship does the grunt work to add two DataRelation objects into
         the autoLotDS object.*/
        private void BuildTableRelationships()
        {
            //**Note that the parent table (second parameter) is ALWAYS specificed BEFORE the child table (third parameter).

            //Create CustomerOrder data relation object
            DataRelation dr = new DataRelation("CustomerOrder", autoLotDS.Tables["Customers"].Columns["CustID"],
                autoLotDS.Tables["Orders"].Columns["CustID"]);
            //add the relation to the autoLotDS relation collection.
            autoLotDS.Relations.Add(dr);

            //Create the InventoryOrder data relation object
            dr = new DataRelation("InventoryOrder", autoLotDS.Tables["Inventory"].Columns["CarID"],
                autoLotDS.Tables["Orders"].Columns["CarID"]);
            //add the relation to the autoLotDS relation collection.
            autoLotDS.Relations.Add(dr);
        }

        //When clicked, updates the backend database from the changes made to the table by the user.
        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                inventoryTableAdapter.Update(autoLotDS, "Inventory");
                customersTableAdapter.Update(autoLotDS, "Customers");
                ordersTableAdapter.Update(autoLotDS, "Orders");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Retrieve relevant info about a customer based on their id
        private void btnGetOrderInfo_Click(object sender, EventArgs e)
        {
            string strOrderInfo = string.Empty;
            DataRow[] drsCust = null;
            DataRow[] drsOrder = null;

            //Get the customer ID in the check box
            int custID = int.Parse(this.txtCustID.Text);

            //Now, based on the CustID, get the correct row in the Customers table.
            drsCust = autoLotDS.Tables["Customers"].Select(string.Format("CustID = {0}", custID));

            //Begin building the string that will be output to the user in a message box
            strOrderInfo += string.Format("Customer {0}: {1} {2}\n",
                drsCust[0]["CustID"].ToString(),
                drsCust[0]["FirstName"].ToString(),
                drsCust[0]["LastName"].ToString());

            //Navigate from the Customers table to the Orders table
            drsOrder = drsCust[0].GetChildRows(autoLotDS.Relations["CustomerOrder"]);

            //Loop through all orders for this customer
            foreach (DataRow order in drsOrder)
            {
                strOrderInfo += string.Format("-----\nOrder Number: {0}\n", order["OrderID"]);

                //get the car referenced by this order
                DataRow[] drsInv = order.GetParentRows(autoLotDS.Relations["InventoryOrder"]);

                //Get info for (SINGLE) car info for this order
                DataRow car = drsInv[0];
                strOrderInfo += string.Format("Make: {0}\n", car["Make"]);
                strOrderInfo += string.Format("Color: {0}\n", car["Color"]);
                strOrderInfo += string.Format("Pet Name: {0}\n", car["PetName"]);
            }

            MessageBox.Show(strOrderInfo, "Order Details");
        }

    }
}
