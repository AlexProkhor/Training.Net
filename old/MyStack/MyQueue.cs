
namespace MyStack
{
    using System;
    using System.Collections;

    class MyQueue
    {

        /// <summary>
        /// Напишите класс MyQueue, который реализует очередь с использованием двух стеков.
        /// </summary>

        Stack _stackNewest, _stackOldest;

        public MyQueue()
        {
            _stackNewest = new Stack();
            _stackOldest = new Stack();
        }

        public int size()
        {
            return _stackNewest.Count + _stackOldest.Count;
        }

        public void add(T value)
        {
            // Все новейшие элементы находятся на вершине stackNewest.
            _stackNewest.Push(value);
        }

        // Перемещение элементов из stackNewest в stackOldest.
        private void shiftStacks()
        {
            if (_stackOldest == null)
            {
                while (_stackNewest != null)
                {
                    _stackOldest.Push(_stackNewest.Pop());
                }
            }
        }

        public T peek()
        {
            // Перенести текущие элементы в stackOldest.
            shiftStacks();
            // Получить самый старый элемент . 
            return (T)_stackOldest.Peek();
        }

        public T remove()
        {
            // Перенести текущие элементы в stackOldest.
            shiftStacks();
            // Извлечь самый старый элемент.
            return (T)_stackOldest.Pop();
        }

    }

    public class T
    {
    }
}
