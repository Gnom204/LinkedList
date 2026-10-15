using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class ListElem<T>
    {
        public T value { get; set; }
        public ListElem<T> Next { get; set; }
        public ListElem<T> Prev { get; set; }

        public ListElem(T value, ListElem<T> prev=null,  ListElem<T> next=null){
            this.value = value;
            this.Prev = prev;
            this.Next = next;
        }
    }
}
