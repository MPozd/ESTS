using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Program
    {
        static Place[] DB_places(CurrSession session)
        {
            Place[] DB = new Place[6];
            DB[0] = session.factory.AddPlace("Санкт-Петербург", "Крупный город", "Второй по величине город России, город федерального значения");
            DB[1] = session.factory.AddPlace("Выборг", "Город", "Город на северо-западе Ленинградской области");
            DB[2] = session.factory.AddPlace("Приозерск", "Город", "Город на севере Ленинградской области");
            DB[3] = session.factory.AddPlace("Девяткино", "ПГТ", "Посёлок к северо-западу от Санкт-Петербурга");
            DB[4] = session.factory.AddPlace("Гатчина", "Город", "Город к югу от Санкт-Петербурга");
            DB[5] = session.factory.AddPlace("Сосновый Бор", "Город", "Город на юго-западе Ленинградской области");
            return DB;
        }

        static Route[] DB_routes(CurrSession session, Place[] DB_places)
        {
            Route[] DB = new Route[9];
            DB[0] = session.factory.AddRoute(DB_places[0], DB_places[1]);
            DB[1] = session.factory.AddRoute(DB_places[0], DB_places[2]);
            DB[2] = session.factory.AddRoute(DB_places[0], DB_places[3]);
            DB[3] = session.factory.AddRoute(DB_places[0], DB_places[4]);
            DB[4] = session.factory.AddRoute(DB_places[0], DB_places[5]);
            DB[5] = session.factory.AddRoute(DB_places[1], DB_places[2]);
            DB[6] = session.factory.AddRoute(DB_places[2], DB_places[3]);
            DB[7] = session.factory.AddRoute(DB_places[3], DB_places[4]);
            DB[8] = session.factory.AddRoute(DB_places[4], DB_places[5]);
            return DB;
        }

        static Trip[] DB_trips(CurrSession session, Route[] DB_routes)
        {
            Trip[] DB = new Trip[3];
            DateTime t1s = new DateTime(2019, 6, 30, 8, 30, 0);
            DateTime t1f = new DateTime(2019, 6, 30, 9, 30, 0);
            DateTime t2s = new DateTime(2019, 6, 30, 12, 30, 0);
            DateTime t2f = new DateTime(2019, 6, 30, 13, 30, 0);
            DateTime t3s = new DateTime(2019, 6, 30, 13, 00, 0);
            DateTime t3f = new DateTime(2019, 6, 30, 13, 30, 0);
            DB[0] = session.factory.AddTrip(DB_routes[0], t1s, t1f, 50);
            DB[1] = session.factory.AddTrip(DB_routes[0], t2s, t2f, 50);
            DB[2] = session.factory.AddTrip(DB_routes[1], t3s, t3f, 50);
            return DB;
        }

        static void Main(string[] args)
        {
            CurrSession session = CurrSession.MySession;

            Place[] DB_place = DB_places(session);
            Route[] DB_route = DB_routes(session, DB_place);
            Trip[] DB_trip = DB_trips(session, DB_route);


            Console.WriteLine("Добро пожаловать в Электронную систему продажи билетов!");
            bool succ = false;
            int input = 1;
            while (!succ)
            {
                Console.WriteLine("Если вы сотрудник компании, введите 0, в противном случае введите 1");
                try
                {
                    input = Int32.Parse(Console.ReadLine());
                    if ((input != 0) && (input != 1))
                    {
                        throw new Exception("Введите либо 0, либо 1");
                    }
                    else
                    {
                        succ = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (input == 1)
            {
                User user = session.SetUser();
                Console.WriteLine("Доступные населённые пункты");
                for (int i = 0; i < DB_place.Length; i++)
                {
                    Console.WriteLine(i.ToString() + ": " + DB_place[i]);
                }
                Console.WriteLine("Введите номер точки отправления");
                int inp = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < DB_route.Length; i++)
                {
                    if (DB_route[i].dep_point == DB_place[inp])
                    {
                        Console.WriteLine(i.ToString() + ": " + DB_route[i]);
                    }
                }
                Console.WriteLine("Введите номер маршрута");
                inp = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < DB_trip.Length; i++)
                {
                    if (DB_trip[i].route == DB_route[inp])
                    {
                        Console.WriteLine(i.ToString() + ": " + DB_trip[i]);
                    }
                }
                Console.WriteLine("Введите номер поездки");
                inp = Int32.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Введите ваш логин");
                string name = Console.ReadLine();
                Console.WriteLine("Введите ваш пароль");
                string password = Console.ReadLine();
                User user = session.SetUser(name, password);
            }

            

            Console.ReadLine();
        }
    }
}
