using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Tables
{
    
    internal class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }


        }
        public V Get(K key)
        {
             int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }


        public int CheckHash(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            int count = 1;
            bool found = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);

            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    count = Convert.ToInt32(keyValue.Value) + 1;
                    found = true;
                    founditem = keyValue;
                }
            }
            if (found)
            {
                LinkedListofPosition.Remove(founditem);
                return count;
            }
            else
            {
                return 1;
            }

        }

        public void frequencyOfWords(K key)
#pragma warning restore IDE1006 // Naming Styles
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = item;
                    string str = foundItem.Value.ToString();
                    Console.WriteLine("found data = " + str);
                    string[] arr = str.Split(',');
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (dict.ContainsKey(arr[i]))
                        {
                            dict[arr[i]] = dict[arr[i]] + 1;
                        }
                        else
                        {
                            dict.Add(arr[i], 1);
                        }
                    }
                    foreach (KeyValuePair<String, int> entry in dict)
                    {
                        Console.WriteLine(entry.Key + " - " +
                                          entry.Value);
                        Console.ReadLine();
                    }
                }
            }
        }


        public void Display(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    Console.WriteLine("{ KeyValue : " + keyValue.Key + " , Freq of Occurance : " + keyValue.Value + " }");
                }

            }
        }

    }

}
