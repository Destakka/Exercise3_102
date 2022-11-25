using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Linked_List_A
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        
        public CircularList()
        {
            LAST = null;
        }

        // add Node
        public void addNode()
        {
            int rollNo;
            string nm;

            Console.Write("\nEnter the Roll Number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter the name of student: ");
            nm = Console.ReadLine();

            Node newNode = new Node();
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)/*Searches for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); /*Return true if the node is found*/
            }
            if (rollNo == LAST.rollNumber) /*If the node is present at the end*/
                return true;
            else
                return (false); /*return false if the node is not found*/
        }
    }
}
