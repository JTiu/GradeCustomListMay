using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GradeCustomListMay.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_ShouldAddItemToList()//naming convbention 'method, underscore, expected result. whenever third item needed, add an extra underscore. nned to add areference.
        { //arrange
            CustomList<string> listOfTowns = new CustomList<string>();//empty list


            //act in effect, going to test the function for expected result
            listOfTowns.Add("Roswell");



            //Assert

            Assert.AreEqual("Roswell", listOfTowns[0]);
        }

        [TestMethod]
        public void Remove_ShouldReturnTrue_IfItemExistsInList()//naming convbention 'method, underscore, expected result. as third item needed, add an extra underscore. 
        { //arrange
            CustomList<string> listOfTowns = new CustomList<string>();//empty list
            listOfTowns.Add("Roswell");
            listOfTowns.Add("Mesilla");

            //act in effect, going to test the function for expected result
            bool result = listOfTowns.Remove("Roswell");



            //Assert

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Remove_ShouldReturnFalse_IfItemDoesNotExistInList()//naming convbention 'method, underscore, expected result. as third item needed, add an extra underscore. 
        { //arrange
            CustomList<string> listOfTowns = new CustomList<string>();//empty list
            listOfTowns.Add("Roswell");
            listOfTowns.Add("Mesilla");

            //act in effect, going to test the function for expected result
            bool result = listOfTowns.Remove("Las Cruces");



            //Assert

            Assert.IsFalse(result);
        }
    }
}
