using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.BrowserBuddy
{
    internal class Node //implementation of doubly linkedlist to move forword and backword
    {
        public string Data; 
        public Node Next, Prev; //referance of previous and next tab

        public Node(string data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
           
        }
    }
    public class BrowserHistory : IHistory
    {
        private Node current;  //store the current node

        public BrowserHistory(string homepage) //search engine is mainly the homepage
        {
            current = new Node(homepage);
        }

        public void visit(string data) //method is use to use visit a new site
        {
            Node newNode = new Node(data);//creating a object of new site and pass the url

            //new node become current 
            current.Next = newNode;
            newNode.Prev = current;
            current = newNode;
        }

        //method to move backword
        public string backwards()
        {
            if(current.Prev != null) //if previous of current is not null
            {
                current = current.Prev;
            }
            return current.Data;
        }

        //method to move forward
        public string forward()
        {
            if(current.Next != null) //check if there is next tab or not
            {
                current = current.Next;  //assign the current to next tab
            }

            return current.Data;
        }

        //method to get the current data or url
        public string GetCurrent()
        {
            return current.Data;
        }
    }
}
