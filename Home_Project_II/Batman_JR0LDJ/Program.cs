using System;
using System.Collections.Generic;
using System.Text;

namespace Batman_JR0LDJ
{
    class Tools
    {
        protected string nameItem;
        protected int cost;
        protected int utilityValue;

        public Tools(string nameItem, int cost, int utilityValue)
        {
            this.nameItem = nameItem;
            this.cost = cost;
            this.utilityValue = utilityValue;
        }

        public Tools()
        {

        }

        public string NameItem
        {
            get { return nameItem; }
            set { nameItem = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int UtilityValue
        {
            get { return utilityValue; }
            set { utilityValue = value; }
        }

        public SelfMadeList StoreRandomItems(SelfMadeList itemList, int size)
        {
            Random RNG = new Random();
            string[] itemNames = { "Batmobil", "Batcoper", "Batarang", "ExplosiveGel", "Parachute" };
            int[] itemCost = { 1000, 2000, 3000, 4000, 5000 };
            for (int i = 0; i < size; i++)
            {
                string nameList = itemNames[RNG.Next(itemNames.Length)];
                Tools newItem = new Tools(nameList, itemCost[RNG.Next(0, 4)], RNG.Next(1, 10));
                itemList.AddList(newItem);
            }
            return itemList;
        }

        public override string ToString()
        {
            return nameItem;
        }

        public int CurrentBudget(int currentBudget, int cost)
        {
            if (currentBudget > 0 && currentBudget > cost)
            {
                currentBudget -= cost;
            }
            if (currentBudget < 1000) throw new NotEnoughBudgetException("You don't have enough money.");
            return currentBudget;
        }
    }

    class Vehicles : Tools
    {
        public Vehicles(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class HandTools : Tools
    {
        public HandTools(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class Batmobil : Vehicles
    {
        public Batmobil(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class Batcoper : Vehicles
    {
        public Batcoper(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class Batarang : HandTools
    {
        public Batarang(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class ExplosiveGel : HandTools
    {
        public ExplosiveGel(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class Parachute : HandTools
    {
        public Parachute(string nameItem, int cost, int utilityValue) : base(nameItem, cost, utilityValue)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me your budget for this year: ");
            int n = int.Parse(Console.ReadLine());
            Tools newItem = new Tools();
            SelfMadeList newList = new SelfMadeList();
            newItem.StoreRandomItems(newList, 10);
            newList.Traversal();
            var listItem = new List<Tools>();
            newList.OfferAlgorithm(n, listItem);
            BinarySearchTree tree = new BinarySearchTree();
            foreach (Tools x in listItem)
            {
                tree.Store(x);
            }

            string a = "";
            while (a != "Cancel")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Add, Remove or Cancel?");
                a = Console.ReadLine();
                if (a == "Add")
                {
                    Console.WriteLine("Please type your new tool:");
                    Tools newTool = new Tools();
                    newTool.NameItem = Console.ReadLine();
                    newTool.Cost = int.Parse(Console.ReadLine());
                    newTool.UtilityValue = int.Parse(Console.ReadLine());
                    Console.Clear();
                    newList.AddList(newTool);
                    try
                    {
                        n = newTool.CurrentBudget(n, newTool.Cost);
                    }
                    catch(NotEnoughBudgetException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Console.WriteLine($"Current budget: {n}");
                    Console.ForegroundColor = ConsoleColor.White;
                    newList.Traversal();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    newList.OfferAlgorithm(n, listItem);
                }
                if (a == "Remove")
                {
                    Console.WriteLine("Which element do you want to remove?");
                    int index;
                    index = int.Parse(Console.ReadLine());
                    Console.Clear();
                    newList.RemoveList(index);
                    Console.WriteLine($"Current budget: {n}");
                    Console.ForegroundColor = ConsoleColor.White;
                    newList.Traversal();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    newList.OfferAlgorithm(n, listItem);
                }
            }
        }
    }

}

