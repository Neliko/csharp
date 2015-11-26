using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DbDemo.Properties;

namespace DbDemo
{
    class Program
        {

            public static List<CustomerProxy> GetCustomers()
            {
                using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
                {
                    IDbCommand command = new SqlCommand("select * from t_customer");
                    command.Connection = connection;

                    connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    List<CustomerProxy> customers = new List<CustomerProxy>();


                    while (reader.Read())
                    {
                        CustomerProxy customer = new CustomerProxy();
                        customer.id = reader.GetInt32(0);
                        customer.Name = reader.GetString(1);

                        customers.Add(customer);
                        // Console.WriteLine(string.Format("Идентификатор {0}\tФИО{1}", reader.GetInt32(0), reader.GetString(1)));
                    }
                    return customers;
                }

            }

            public static List<Customer> GetCustomersEF()
            {

                var context = new TestDBContext1();

                var customers = context.Customers.ToList();

                return customers;


                //using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
                //{
                //    IDbCommand command = new SqlCommand("select * from t_customer");
                //    command.Connection = connection;

                //    connection.Open();
                //    IDataReader reader = command.ExecuteReader();
                //    List<CustomerProxy> customers = new List<CustomerProxy>();


                //    while (reader.Read())
                //    {
                //        CustomerProxy customer = new CustomerProxy();
                //        customer.id = reader.GetInt32(0);
                //        customer.Name = reader.GetString(1);

                //        customers.Add(customer);
                //        // Console.WriteLine(string.Format("Идентификатор {0}\tФИО{1}", reader.GetInt32(0), reader.GetString(1)));
                //    }
                //    return customers;

            }

            private static void Main(string[] args)
            {
                var xDoc = new XDocument();
                var xEl= new XElement("Vorwand", new XAttribute("Name", "LA"),new XAttribute("Description", "Bla Bla Bla"));
                var path = new XElement("Path");
                path.Add("D:\\GIT\\C#");
                xEl.Add(path);
                xDoc.Add(xEl);


                using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
                {
                    /*   IDbCommand command = new SqlCommand("select * from t_customer");
                command.Connection = connection;

                connection.Open();

                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("Идентификатор {0}\tФИО{1}", reader.GetInt32(0), reader.GetString(1)));
                }
              * */
                    var customers = GetCustomers();
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(string.Format("Идентификатор {0}\tФИО{1}", customer.id, customer.Name));
                    }
                    Console.ReadKey();
                }
            }
        }
    }