using System;
using System.Collections.Generic;
using Xunit;


namespace BagOLoot.Tests
{
    public class SantaHelperShould
    {
        private SantaHelper _helper;
        private readonly ChildRegister _register;

        public SantaHelperShould()
        {
            _helper = new SantaHelper();
            _register = new ChildRegister();
        }

        [Fact]
        public void AddToyToChildsBag()
        {
            string toyName = "SkateBoard";
            int childId = 715;
            
            // returning a boolean we are now assigning and asking what child ..
            int toyID = _helper.AddToyToBag(toyName, childId);

            //4. Review child's toy list - testing the toy list for the child
            List<int> toys = _helper.getChildsToyList(childId);

            Assert.Contains(toyID, toys);
        }


// Test For 3. Revoke toy from child
        [Fact]
        public void RemoveToyFromChild()
        {
            int toyID = 2;
            int childId = 14;
            
            List<int> toys = _helper.getChildsToyList(childId);

            //this is where the input in the real code will be for a user to select what toy to be removed.

            List<int> remainingToys = _helper.RemoveAToyFromChild(toyID);


            Assert.DoesNotContain(toyID, remainingToys);
        }

// TEST Must be able to list all toys for a given child's name.
        [Fact]
        public void checkingChildList()
        {
            int childId = 7;

            List<int> childsToyList = _helper.getChildsToyList(childId);
            Assert.True(childsToyList.Count >= 0);
        }
    //Must be able to list all children who are getting a toy.
        [Fact]
        public void listOfChildrenGettingAToyTest()
        {

            int toyId = 5;
            string childName = "Stephanie";
            
            var result = _register.AddChild(childName);
            List<string> listOfChildrenGettingToys = _helper.GetGoodChildrenNames();

            // Assert.IsType(List<int> listOfChildrenGettingToys = 0)
            // Assert.True(listOfChildrenGettingToys.Count= 0);

            //Assign a toy to Stephanie
            _helper.AddToyToChildsBag(childName, toyId);

            //Get List of good Children again 
            List<string> listOfGoodKidsGettingToys = _helper.GetGoodChildrenNames();

            //Assert that the count of the list is greater than 0 
            Assert.True(listOfChildrenGettingToys.Count > 0);

        }

        [Fact]

        public void SetDeliveredPropertyToChild()
        {
            int childId = 34;
            bool deliveredToChild = _helper.ToyWasDelivered(childId);

            Assert.True(deliveredToChild);
        }

    }
}