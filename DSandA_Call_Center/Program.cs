namespace DSandA_Call_Center
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linked List Program");
            Console.WriteLine("By: Eric Miller");
            Console.WriteLine();

            //Create a new linked list
            TicketQueue list = new TicketQueue();

            //Add nodes to the linked list
            Console.WriteLine("ADD NODES:");
            Console.WriteLine("Add 5 to the list.");
            list.AddNode(5);
            Console.WriteLine("Add 10 to the list.");
            list.AddNode(10);
            Console.WriteLine("Add 20 to the list.");
            list.AddNode(20);
            Console.WriteLine("Print the list:");
            list.PrintList();
            Console.WriteLine();

            //Delete A Node from the linked list
            Console.WriteLine("Delete 5 from list. ");
            list.DeleteNode(5);
            Console.WriteLine("Print the list:");
            list.PrintList();
            Console.WriteLine();

            //Search the linked list
            Console.WriteLine("Search for 5.");
            Console.WriteLine(list.Search(5));
            Console.WriteLine("Search for 10.");
            Console.WriteLine(list.Search(10));
            Console.WriteLine();
        }
    }

    public class Ticket
    {
        //Properties-------------------------------------------------------------
        public string customerName { get; set; }
        public string problemDescription { get; set; }
        public Ticket Next { get; set; }

        //Constructor------------------------------------------------------------
        public Ticket(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    public class TicketQueue
    {
        //Properties-------------------------------------------------------------
        public Ticket Head { get; set; }
        public Ticket Tail { get; set; }

        //Constructor------------------------------------------------------------
        public TicketQueue()
        {
            this.Head = null;
        }

        //Methods----------------------------------------------------------------

        //Method to add a node
        public void AddNode(int data)
        {
            //Create a new node, passing the data to the constructor to set the data property
            Ticket newNode = new Ticket(data);

            //Check if the list is empty (check head for null), if it is, set the new node as the head
            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else //If the list is not empty, go through the list and add the new node to the end
            {
                //Set the head as the current node
                Ticket current = this.Head;

                //While loop to go through the list until the last node is reached (current.Next == null)
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;//adds the new node to the end of the list by assigning the new node to the current node's next property
            }
        }

        //Method to delete a node (returns a bool to indicate if the node was deleted)
        public bool DeleteNode(int data)
        {
            //Check if the list is empty
            if (this.Head == null)
            {
                return false;
            }
            else //If the list is not empty, go through the list to find the node to delete
            {
                //Check if the node to delete is the head
                if (this.Head.Data == data)
                {
                    this.Head = this.Head.Next; //Set the head to the next node in the list
                    return true;
                }
                else //If the node to delete is not the head, go through the list to find the node to delete
                {
                    //Set the head as the current node
                    Ticket current = this.Head;

                    //While loop to go through the list until the last node is reached (current.Next == null)
                    while (current.Next != null)
                    {
                        //Check if the next node is the node to delete
                        if (current.Next.Data == data)
                        {
                            //Set the current node's next property to the node after the node to delete
                            current.Next = current.Next.Next;
                            return true;
                        }

                        current = current.Next;
                    }

                    //If the node to delete is not found, return false
                    return false;
                }
            }
        }

        //Method to search the linked list for a value
        public bool Search(int data)
        {
            Ticket current = this.Head;

            while (current != null)
            {
                if (current.Data == data)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        //Method to print the list
        public void PrintList()
        {
            Ticket current = this.Head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
