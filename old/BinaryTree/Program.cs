using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BinaryElement> binaryTree = new Dictionary<int, BinaryElement>();
            BinaryElement element = new BinaryElement(1, 0, 0); // Корневой элемент.
            var resultOfOperation = AddElement(element, 2, binaryTree);
            switch (resultOfOperation)
            {
                case 1:
                    {
                        Console.WriteLine("У корневого элемента нет свободных ветвей");
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine($"Элемент создан. \n Корневой элемент: {element.GetID()}, ID Элемента: {2}");
                        break;
                    }
            }
        }

        public static void CreateElement(int idName, Dictionary<int, BinaryElement> binaryTree)
        {
            BinaryElement newElement = new BinaryElement(idName, 0, 0);
            binaryTree.Add(idName, newElement);
        }

        public static int AddElement(BinaryElement fatherElement, int idName, Dictionary<int, BinaryElement> binaryTree)
        {
            if (fatherElement.leftElementId == 0)
            {
                fatherElement.leftElementId = idName;
                fatherElement.isHaveTale = true;
                CreateElement(idName, binaryTree);
                return 0;
            }
            else if (fatherElement.leftElementId == 0)
            {
                fatherElement.rightElementId = idName;
                fatherElement.isHaveTale = true;
                CreateElement(idName, binaryTree);
                return 0;
            }
            else
                return 1;
        }
    }



    public class BinaryElement
    {
        int id;
        public int rightElementId;
        public int leftElementId;
        public bool isHaveTale;

        public BinaryElement(int idName, int right, int left)
        {
            id = idName;
            rightElementId = right;
            leftElementId = left;
        }
        
        public int GetID()
        {
            return id;
        }
    }
}