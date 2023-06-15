using _153504_KLIMKOVICH_Lab5.Entities;
using _153504_KLIMKOVICH_Lab5.Interfaces;
using System.Collections;

namespace _153504_KLIMKOVICH_Lab5.Collections
{
    public class MyCustomCollection<T> : IEnumerable<T>, ICustomCollection<T>
    {
        private MyNode<T> head = null;
        private MyNode<T> tail;
        private MyNode<T> cursor;
        public T this[int index] // индексатор коллекции
        {
            get
            {
                try
                {
                    if (index > Count - 1 || index < 0)
                    {
                        throw new IndexOutOfRangeException("Exception in indexer");
                    }
                }

                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    return default;
                }
                int temt = 0;
                MyNode<T> findItem = head;
                while (temt != index)
                {
                    findItem = findItem.next;
                    temt++;
                }
                return findItem.item;
            }

            set
            {
                if (index < Count - 1 || index >= 0)
                {
                    int temp = 0;
                    MyNode<T> findItem = head;
                    while (temp != index)
                    {
                        findItem = findItem.next;
                    }
                    findItem.item = value;
                }
            }
        }
        public void RemoveCurrent() //метод, удаляет элемент текущего положения курсора
        {
            if (cursor == head)
            {
                head = head.next;
                cursor = head;
                Count--;
            }
            else
            {
                MyNode<T> findItem = head;
                while (findItem.next != cursor)
                {
                    cursor = cursor.next;
                }
                findItem.next = cursor.next;
                findItem = null;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            MyNode<T> current = head;
            while (current != null)
            {
                yield return current.item;
                current = current.next;
            }

        }
        public void Remove(T item) //метод, удаляет объект item из коллекции
        {
            MyNode<T> findItem = head;
            try
            {
                foreach (var i in this)
                {
                    if (EqualityComparer<T>.Default.Equals(findItem.item, item)) break;
                    findItem = findItem.next;
                }
                if (findItem == null) throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Item In Collection");
            }
            if (findItem == head)
            {
                head = findItem.next;
                findItem = null;
            }
            else
            {
                MyNode<T> findItem2 = head;
                while (findItem2.next != findItem)
                {
                    findItem = findItem.next;
                }
                findItem2.next = findItem.next;
                findItem = null;
            }
            Reset();
            Count--;
        }
        public void Add(T item) //метод, добавляет объект item в конец коллекции
        {
            MyNode<T> newCollection = new MyNode<T>();
            newCollection.item = item;
            if (head == null)
            {
                head = newCollection;
                tail = newCollection;
                newCollection.next = null;
                cursor = head;
            }
            else
            {
                tail.next = newCollection;
                tail = newCollection;
                tail.next = null;
            }

            Count++;
        }
        public void Reset() // метод, устанавливает курсор в начало коллекции
        {
            cursor = head;
        }

        public void Next() // метод, перемещает курсор на следующий элемент коллекции
        {
            if (cursor.next != null) cursor = cursor.next;
        }
        public T Current() //метод, возвращает элемент текущего положения курсора
        {
            return cursor.item;
        }
        public int Count
        {
            get;
            set;
        }
    }
}
