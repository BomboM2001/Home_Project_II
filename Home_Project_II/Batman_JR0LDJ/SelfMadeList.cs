using System;
using System.Collections.Generic;
using System.Text;

namespace Batman_JR0LDJ
{
    class SelfMadeList 
    {
        ListItem head;
        class ListItem
        {
            public Tools content;
            public ListItem next;
        }

        public void AddList(Tools newcontent)
        {
            ListItem newItem = new ListItem();
            newItem.content = newcontent;
            if (head == null)    // if head is null that means it is the first item and  add the  new item and  set next node to null
            {
                head = newItem;
                head.next = null;
            }
            else
            {
                // if the head is not null and find out the last node by loop
                ListItem current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newItem;
            }
        }

        public void RemoveList(int index)
        {
            int count = 0;
            ListItem pointer = head, item = null;
            while (pointer != null && count != index)
            {
                count++;
                item = pointer;
                pointer = pointer.next;
            }
            if (pointer != null)
            {
                if (item == null) head = pointer.next;
                else item.next = pointer.next;
            }
        }

        public void Traversal()
        {
            ListItem item = head;
            while (item != null)
            {
                Process(item);
                item = item.next;
            }
        }

        private void Process(ListItem item)
        {
           
            Console.WriteLine($"{item.content.NameItem} - {item.content.Cost} - {item.content.UtilityValue}");
        }

        public List<Tools> OfferAlgorithm(int budget, List<Tools> listItem)
        {
            ListItem item = head;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("An offer for you: ");
            while (item != null)
            {
                if (item.content.Cost <= budget && item.content.UtilityValue > 5)
                {
                    Process(item);
                    listItem.Add(item.content);
                }
                item = item.next;
            }
            return listItem;
        }
    }
}
