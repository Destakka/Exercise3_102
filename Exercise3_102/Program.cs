using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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

            newNode.rollNumber = rollNo;
            newNode.name = nm;

            if (listEmpty())
            {
                newNode.next = newNode;
                LAST = newNode;
            }
            else if (rollNo < LAST.next.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
            }
            else if (rollNo > LAST.next.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
                LAST = newNode;
            }
            else
            {
                Node curr, prev;
                curr = prev = LAST.next;

                int i = 0;
                while (i < rollNo - 1)
                {
                    prev = curr;
                    curr = curr.next;
                    i++;
                }
                newNode.next = curr;
                prev.next = newNode;
            }
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = LAST.next;

            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;

            if (LAST.next.rollNumber == LAST.rollNumber)
            {
                LAST.next = null;
                LAST = null;
            }
            else if (rollNo == LAST.next.rollNumber)
            {
                LAST.next = current.next;
            }
            else
            {
                LAST = LAST.next;
            }
            return true;
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
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

    }
}
