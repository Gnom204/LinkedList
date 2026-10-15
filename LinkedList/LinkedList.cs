using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class LinkedList<T>
    {
        ListElem<T> Prev;
        ListElem<T> Next;
        public LinkedList() {
            this.Prev = null;
            this.Next = null;
        }
        public T this[int index]
        {
            get
            {
                ListElem<T> cur = this.Next;
                int i = 0;
                while (cur != null && i < index)
                {
                    cur = cur.Next;
                    i++;
                }
                return cur.value;
            }
            set
            {
                ListElem<T> cur = this.Next;
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
            if (this.Next == null)
            {
                this.Next = elem;
            }
            else
            {
                this.Next.Prev = elem;
                elem.Next = this.Next;
            }
        }
        public void AddLast(T value)
        {
            ListElem<T> elem = new ListElem<T>(value);

            if (this.Next == null)
            {
                this.Next = elem;
            }
            else
            {
                ListElem<T> cur = this.Next;
                while (cur.Next != null)
                {
                    cur = cur.Next;
                }
                cur.Next = elem;
                elem.Prev = cur;
            }
        }

        public void AddAt(T val, int index)
        {
            if (index == 0)
            {
                AddFirst(val);
                return;
            }

            ListElem<T> cur = this.Next;
            int i = 0;
            while (cur != null && i < index - 1)
            {
                cur = cur.Next;
                i++;
            }

            ListElem<T> elem = new ListElem<T>(val);
            elem.Next = cur.Next;
            elem.Prev = cur;
            if (cur.Next != null)
            {
                cur.Next.Prev = elem;
            }
            cur.Next = elem;
        }

        public int Find(T val)
        {
            ListElem<T> cur = this.Next;
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
            return this.Next == null;
        }
    }
}