using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    //the code below in the two public methods are the job of the "helper"
    public class SantaHelper
    {

        // Adding a toy to a childID 
        public int AddToyToBag(string toy, int child)
        {
            return 4;
        }

        public List<int> getChildsToyList(int childId)
        { 
            //the below is a list of childs toyid's. 
            return new List<int>() {2,4,6,7,8};
        } 


        // Removing a toy from a  child 
        public List <int> RemoveAToyFromChild(int toyID)
        {
            return new List <int>() {4,6,7,8};
        }
        
    }
}