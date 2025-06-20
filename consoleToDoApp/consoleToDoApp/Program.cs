﻿using System;
using System.Collections.Generic;
using System.IO;
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
                Console.WriteLine("4. Save task list as text file");
                Console.WriteLine("5. Exit");
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
                        DeleteTask();
                        break;
                    case "4":
                        SaveTasksToFile();
                        return;
                    case "5":
                        break;
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

        static void DeleteTask()
        {
            Console.Clear();
            if (todoList.Count == 0)
            {
                Console.WriteLine("There are no tasks to delete.");
                WaitKeyAction();
                return;
            }

            Console.WriteLine("Which task do you want to delete?");
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todoList[i]}");
            }

            Console.Write("Enter the number of the task to delete: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= todoList.Count)
                {
                    string deletedTask = todoList[taskNumber - 1];
                    todoList.RemoveAt(taskNumber - 1);
                    Console.WriteLine($"Task \"{deletedTask}\" deleted.");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }

            WaitKeyAction();
        }

        static void SaveTasksToFile()
        {
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads",
                "todoList.txt"
            );

            try
            {
                File.WriteAllLines(filePath, todoList);
                Console.WriteLine($"Tasks saved successfully to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving tasks: " + ex.Message);
            }

            WaitKeyAction();
        }
    }
}
