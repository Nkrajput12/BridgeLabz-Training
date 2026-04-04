using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BrowserBuddy
{
    public class Stack //implementation of stack using linkedlist
    {
        public string Data; //store data
        public Stack Below; //store reference

        public Stack(string data)
        {
            this.Data = data;
            this.Below = null;
        } 
    }
    internal class ClosedTab : ITab
    {
        private Stack top; //top store here

        public void Push(string data) // method to push the element to the stack
        {
            Stack newNode = new Stack(data);

            newNode.Below = top; //top is under the new node
            top = newNode; // now new node is top

        }

        public string Pop() //method to return and remove the top element
        {
            if(top == null) //check if top is null or not
            {
                Console.WriteLine("No Close tab to restore");
                return null;
            }
            string url = top.Data; //storing the top data to url

            top = top.Below; //the below tab is now on the top
            return url; 
        }
    }
}
