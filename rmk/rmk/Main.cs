using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anonym.Model.DataBaseMySQL;

namespace Anonym
{
    class Anonym
    {
        public static void Main()
        {
            ConnectionBaseMySQL connectionBase = new ConnectionBaseMySQL("localhost", "3306", "root", "root", "MyBase");

            Console.WriteLine("Соединение с серверов: " + connectionBase.IsConnection);
            Console.WriteLine("Соединение с базой: " + connectionBase.IsBase);

            if (connectionBase.IsBase)
            {
                connectionBase.ActivateBase();
                Console.WriteLine("Активированна база: " + "MyBase");
                connectionBase.CreateTable("MyTable1");
                Console.WriteLine("Создана таблица: " + "MyTable1");
            }
            else
            {
                connectionBase.CreateBase();
                Console.WriteLine("Создана база: " + "MyBase");
                connectionBase.ActivateBase();
                Console.WriteLine("Активированна база: " + "MyBase");
                connectionBase.CreateTable("MyTable");
                Console.WriteLine("Создана таблица: " + "MyTable");
            }

            connectionBase.CloseConnection();
            Console.WriteLine("Закрытие базы " + "MyBase");

            Console.ReadLine();
        }
    }
}
