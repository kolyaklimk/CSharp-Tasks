namespace _153504_KLIMKOVICH_Lab5.Interfaces
{
    public interface ICustomCollection<T>
    {
        T this[int index] // индексатор коллекции
        {
            get;
            set;
        }

        void Reset(); // метод, устанавливает курсор в начало коллекции

        void Next(); // метод, перемещает курсор на следующий элемент коллекции

        T Current(); //метод, возвращает элемент текущего положения курсора

        int Count //свойство, возвращает количество элементов в коллекции
        {
            get;
            set;
        }

        void Add(T item); //метод, добавляет объект item в конец коллекции

        void Remove(T item); //метод, удаляет объект item из коллекции

        void RemoveCurrent(); //метод, удаляет элемент текущего положения курсора
    }
}
