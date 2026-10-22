using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace LinkedList
{
    internal class MyLinkedList<T> : IEnumerable<T> where T : IComparable
    {
        private ListElem<T> First;
        private ListElem<T> Last;
        private int Count;
        public MyLinkedList()
        {
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
                ListElem<T> cur = getElement(index);
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

        public bool Contains(T val)
        {
            ListElem<T> cur = this.First;
            while (cur != null)
            {
                if (object.Equals(cur.value, val))
                {
                    return true;
                }
                cur = cur.Next;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (this.First == null)
                return;

            if (this.First.Next == null)
            {
                this.First = null;
                this.Last = null;
                return;
            }

            ListElem<T> cur = this.First;
            this.First = cur.Next;
            this.First.Prev = null;
        }

        public void RemoveLast()
        {
            if (this.Last == null)
                return;

            if (this.Last.Prev == null)
            {
                this.First = null;
                this.Last = null;
                return;
            }

            ListElem<T> cur = this.Last;
            this.Last = cur.Prev;
            this.Last.Next = null;
        }

        public void Remove(T val)
        {
            if(this.First == null)
            {
                throw new Exception("shit");
            }
            ListElem<T> cur = this.First;
            int i = 0;
            while(cur != null && i < Count)
            {
                if(cur.value.Equals(val))
                {
                    cur.Next.Prev = cur.Prev;
                    cur.Prev.Next = cur.Next;
                }
                cur = cur.Next;

            }
        }

        public void RemoveAt(int index)
        {
            if(index <0 || index >= Count)
                throw new Exception("Segmentation fault");
            ListElem<T> cur = getElement(index);
            cur.Next.Prev = cur.Prev;
            cur.Prev.Next = cur.Next;
        }

        public bool isEmpty()
        {
            return this.First == null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListElem<T> cur = First;

            while (cur != null)
            {
                yield return cur.value;
                cur = cur.Next;
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Sort()
        {
            if (this.First == null)
                throw new Exception("Shish");
            for (int i = 0; i < Count; i++)
            {
                ListElem<T> cur = this.First;
                for (int j = 0; j < Count; j++)
                {
                    if(cur.Next!= null)
                    {
                        if (cur.Next.value.CompareTo(cur.value) < 0)
                        {
                            T val = cur.value;
                            cur.value = cur.Next.value;
                            cur.Next.value = val;
                        }
                        cur = cur.Next;
                    }

                }

            }
        }

        public void SortedAdd(T value)
        {
            if(this.First == null)
            {

            }
        }

        // для сортировки не используем индексатор, сортируем, меняя значения, пользуемся ссылками
        private ListElem<T> getElement(int index)
        {
            // если индекс больше чем половина каунта, то идем с конца, если меньше, то сначала
            int gran = Count/2;
            ListElem<T> cur;
            if(index < gran) {
                cur = this.First;
                int i = 0;
            while (cur != null && i < index)
                {
                    cur = cur.Next;
                    i++;
                }
            }
            else
            {
                cur = this.Last;
                int i = Count;
                while (cur != null && i > index)
                {
                    cur = cur.Prev;
                    i--;
                }
            }
            return cur;
        }

    }
}