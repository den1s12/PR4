using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PP03Uhanov.ClassFolder
{
    class CBClass
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                                Initial Catalog=PP03Uhanov;
                                Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;

        public void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select PPRole, RoleName " +
                    "From dbo.[Role]",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Role]"].Columns["PPRole"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
