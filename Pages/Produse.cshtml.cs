using Microsoft.IdentityModel;
using CostControlApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace CostControlApp.Pages
{
    public class ProduseModel : PageModel 
    {
        //public List<ProduseInfo> listProduse = new List<ProduseInfo>();
        
        public void OnGet()
        {
            //try
            //{
            //    string connectionString = "Data Source=DESKTOP-CT3VKRI\\SQLEXPRESS;Initial Catalog=InventoryDb;Integrated Security=True";
            //    using (SqlConnection connection = new SqlConnection())
            //    {
            //        connection.Open();
            //        string sql = "SELECT * From sheet1";
            //        using(SqlCommand command = new SqlCommand(sql,connection)) 
            //        {
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while(reader.Read())
            //                {
            //                    ProduseInfo produse = new ProduseInfo();
            //                    produse.NrCrt = reader.GetFloat(0);
            //                    produse.CodProdus= reader.GetString(1);
            //                    produse.DimensiuniMm = reader.GetString(2);
            //                    produse.Greutate = reader.GetString(3);
            //                    produse.Buc = reader.GetString(4);
            //                    produse.Mp = reader.GetInt32(5);
            //                    produse.Ml = reader.GetInt32(6);                           
            //                    produse.MpSistem = reader.GetString(7);
            //                    produse.Culoare= reader.GetString(8);
            //                    produse.NrBucPePachet = reader.GetString(9);
            //                    produse.Finisaj= reader.GetString(10);

            //                    listProduse.Add(produse);

            //                }
            //            }
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{

            //}
        }

    //    public Sheet1 ProduseInfo 
    //    { 
        
    //        public double? NrCrt;

    //        public string? CodProdus;

    //        public string? DimensiuniMm;

    //        public string? Denumire;

    //        public string? Greutate;

    //        public string? Buc;

    //        public double? Mp;

    //        public double? Ml;

    //        public string? MpSistem;

    //        public string? Culoare;

    //        public string? NrBucPePachet;

    //        public string? Finisaj;
    //}
}
           
}
