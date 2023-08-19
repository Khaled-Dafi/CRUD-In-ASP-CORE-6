using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Mystore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=mystore;Integrated Security=True";


                using (SqlConnection connection = new SqlConnection(connectionString)) { 
                
                
                         connection.Open();
                    string sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name =  reader.GetString(1);
                                clientInfo.email =  reader.GetString(2);
                                clientInfo.phone =  reader.GetString(3);
                                clientInfo.address=  reader.GetString(4);
                                clientInfo.create_ad =  reader.GetDateTime(5).ToString();

                                ListClients.Add(clientInfo);
                            }
                        }
                    
                    
                    }
                
                
                }

            }
            catch (Exception ex) { 
            
               Console.WriteLine("EXPTIONS: "+ ex.ToString());
               
            }
        }
    }


    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
        public string create_ad;

    }

}
