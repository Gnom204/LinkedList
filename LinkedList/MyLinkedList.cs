using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace LinkedList
{
    internal class MyLinkedList<T>
    {
        private ListElem<T> First;
        private ListElem<T> Last;
        private int Count;
        public MyLinkedList() {
            this.First = null;
            this.Last = null;
            this.Count = 0;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new Exception("shit, Segmentation fault");
                }
                ListElem<T> cur = this.First;
                int i = 0;
                //Вынести в отдельный метод
                while (cur != null && i < index-1)
                {
                    cur = cur.Next;
                    i++;
                }
                return cur.value;
            }
            set
            {
                ListElem<T> cur = this.First;
                int i = 0;
                while (cur != null && i < index)
                {
                    cur = cur.Next;
                    i++;
                }
                cur.value = value;
            }
        }
        public void AddFirst(T value)
        {
            ListElem<T> elem = new ListElem<T>(value);
            if (this.First == null)
            {
                Count++;
                this.First = elem;
                this.Last = elem;
            }
            else
            {
                elem.Next = this.First;
                this.First = elem;
                Count++;
            }
        }
        public void AddLast(T value)
        {
            ListElem<T> elem = new ListElem<T>(value);

            if (this.Last == null)
            {
                this.First = elem;
                this.Last = elem;
                Count++;
            }
            else
            {
                ListElem<T> cur = this.Last;
                cur.Next = elem;
                elem.Prev = cur;
                this.Last = elem;
                Count++;
            }
        }

        public void AddAt(T val, int index)
        {
            ListElem<T> cur = getElement(index);            
            ListElem<T> elem = new ListElem<T>(val);

            elem.Next = cur.Next;
            elem.Prev = cur;
            if (cur.Next != null)
            {
                cur.Next.Prev = elem;
            }
            cur.Next = elem;
            Count++;
        }

        public int Find(T val)
        {
            ListElem<T> cur = this.First;
            int index = 0;
            int result = -1;
            while (cur != null)
            {
                if (object.Equals(cur.value, val))
                {
                    result = index;
                }
                cur = cur.Next;
                index++;
            }
            return result;
        }
        public bool isEmpty()
        {
            return this.First == null;
        }

        private ListElem<T> getElement(int index)
        {
            ListElem<T> cur = this.First;
            int i = 0;
            while (cur != null && i < index - 1)
            {
                cur = cur.Next;
                i++;
            }
            return cur;
        }

    }
}