using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleToDoApp
{
    internal class Program
    {
        static List<string> todoList = new List<string>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task List Manager");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Show tasks");
                Console.WriteLine("2. Add a task");
                Console.WriteLine("3. Delete a task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        //DeleteTask();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }

        static void AddTask()
        {
            Console.WriteLine("What is your next task?");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
            {
                todoList.Add(task);
                Console.WriteLine("Added new task");
            }
            else
            {
                Console.WriteLine("Something went wrong with your task entry");
            }
            WaitKeyAction();
        }


        static void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("Your actual task list: ");
            if (todoList.Count == 0)
            {
                Console.WriteLine("There are no task on your actual list");
            }
            else
            {
                for (int i = 0; i < todoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {todoList[i]}");
                }
            }
            WaitKeyAction();
        }

        static void WaitKeyAction()
        {
            Console.WriteLine("Drücke eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }
    }
}
