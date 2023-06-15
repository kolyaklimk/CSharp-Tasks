using _153504_KLIMKOVICH_Lab5.Entities;
using _153504_KLIMKOVICH_Lab5.Interfaces;

namespace _153504_KLIMKOVICH_Lab5.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        private MyCollection<T> head = null;
        private MyCollection<T> tail;
        private MyCollection<T> cursor;
        public T this[int index] // индексатор коллекции
        {
            get
            {
                if (index < Count - 1 || index >= 0)
                {
                    int temt = 0;
                    MyCollection<T> findItem = head;
                    while (temt != index)
                    {
                        findItem = findItem.next;
                        temt++;
                    }
                    return findItem.item;
                }
                else return default;
            }

            set
            {
                if (index < Count - 1 || index >= 0)
                {
                    int temp = 0;
                    MyCollection<T> findItem = head;
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
                MyCollection<T> findItem = head;
                while (findItem.next != cursor)
                {
                    cursor = cursor.next;
                }
                findItem.next = cursor.next;
                findItem = null;
            }
        }
        public void Remove(T item) //метод, удаляет объект item из коллекции
        {
            MyCollection<T> findItem = head;
            while (findItem != null)
            {
                if (EqualityComparer<T>.Default.Equals(findItem.item, item)) break;
                findItem = findItem.next;
            }
            if (findItem == null) return;
            if (findItem == head)
            {
                head = findItem.next;
                findItem = null;
            }
            else
            {
                MyCollection<T> findItem2 = head;
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
            MyCollection<T> newCollection = new MyCollection<T>();
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
