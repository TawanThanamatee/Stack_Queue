using System;

namespace HW_StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Instruction_Queue instQueue = new Instruction_Queue();
        }
    }
    class Input_Instruction_Data
    {
        public Queue CPU_Queue = new Queue();
        public char Instruction;
        public char Data;

        public Input_Instruction_Data() {
            while (true)
            {
                Console.Write("Instruction : ");
                Instruction = char.Parse(Console.ReadLine());
                if (Instruction == '?')
                {
                    break;
                }
                Console.Write("Data : ");
                Data = char.Parse(Console.ReadLine());
                Node CPU = new Node(Instruction, Data);
                CPU_Queue.Push(CPU);
            }
        }
    }
    class Instruction_Queue
    {
        public int Round = 0;
        public Instruction_Queue()
        {
            Input_Instruction_Data input = new Input_Instruction_Data();
            Node instruction_Queue;
            while (true)
            {
                instruction_Queue = input.CPU_Queue.Pop();
                Round++;
                if (instruction_Queue == null)
                {
                    break;
                }
            }
            Console.WriteLine("CPU cycles needed : " + Round);
        }
    }
    class Node
    {
        public char Instruction;
        public char Data;
        public Node Next;
        public Node(char instructionValue, char dataValue)
        {
            Instruction = instructionValue;
            Data = dataValue;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1})", Instruction, Data);
        }

    }
    class Queue
    {
        private Node Root;
        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node Pointer = Root;
                while (Pointer.Next != null)
                {
                    Pointer = Pointer.Next;
                }
                Pointer.Next = node;
            }
        }
        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
        public Node Get(int index)
        {
            Node node = Root;
            while (index > 0)
            {
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }
                node = node.Next;
                index--;
            }
            return node;
        }

    }
}
