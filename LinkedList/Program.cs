using LinkedList;

void printInfo<T>(MyLinkedList<T> list, int size)
{
    for (int i = 0; i < size; i++)
    {
        Console.Write(list[i] + ", ");
    }
    Console.WriteLine();
}

Random rnd = new Random();
MyLinkedList<int> list1 = new MyLinkedList<int>();
int size = 10;

for(int i = 0; i < size; i++)
{
    list1.AddLast(rnd.Next(0,100));
}

printInfo<int>(list1 , size);

list1.AddFirst(1111);
size++;

list1.AddAt(15, 5);
size++;

printInfo<int>(list1, size);