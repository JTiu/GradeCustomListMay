using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCustomListMay
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomList<string> listOfTowns = new CustomList<string>();

            listOfTowns.Add("Las Cruces");
            listOfTowns.Add("Mesilla");
            listOfTowns.Add("Roswell");

            Console.WriteLine($"List of towns: {listOfTowns.ToString()}");


            string secondTown = listOfTowns[1];
            Console.WriteLine($"second town is: { secondTown}");

            listOfTowns.Remove(secondTown);

            Console.WriteLine($"list after removal of second town {listOfTowns.ToString()}");

            CustomList<string> anotherList = new CustomList<string>();

            anotherList.Add("El Paso");
            anotherList.Add("Hatch");
            Console.WriteLine($"new list of towns is: {anotherList.ToString()}");


            CustomList<string> combinedList = listOfTowns + anotherList;
            Console.WriteLine($"Combined list is: {combinedList.ToString()}");
            Console.ReadLine();
            Console.Clear();
            //check capacity, check count

            Console.WriteLine($" the capcaicty and the count of the combined lists are {combinedList.Capacity} , {combinedList.Count}");


            Console.ReadLine();





        }
    }
}
