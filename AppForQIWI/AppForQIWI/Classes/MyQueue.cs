using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AppForQIWI.Classes
{

    class MyQueue<dynamic>
    {
        public List<dynamic> list = new List<dynamic>();
        
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        // - удаляет и возвращает первый элемент в очереди
        public dynamic Dequeue() {
            if (!IsEmpty())
            {
                dynamic x = list[0];
                list.RemoveAt(0);
                return x;
            }
            else 
            { 
                return default;
            }
        }

        // - добавляет последний элемент в очередь
        public void Enqueue(dynamic x) {
            list.Add(x);
        }
        
        // - возвращает true если очередь пуста
        public bool IsEmpty() {
            if (Size() == 0) return true;
            return false;
        }
        
        // - возвращает количество элементов в очереди
        public int Size() {
            int size = 0;
            foreach (dynamic x in list)
            {
                size++;
            }
            return size;
        }

        // - сортирует элементы по полю 
        public void Sort(string property)
        {
            list = list.OrderBy(p => p.GetType()
                                       .GetProperty(property)
                                       .GetValue(p, null)).ToList();
        }
    }
}
