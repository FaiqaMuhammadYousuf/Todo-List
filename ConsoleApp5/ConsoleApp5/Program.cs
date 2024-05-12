using System;
using System.Collections.Generic;

class TodoItem
{
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
}

class TodoList
{
    private List<TodoItem> tasks = new List<TodoItem>();

    public void AddTask(string task)
    {
        tasks.Add(new TodoItem { Task = task, IsCompleted = false });
        Console.WriteLine("Task added successfully.");
    }

    public void EditTask(int index, string newTask)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].Task = newTask;
            Console.WriteLine("Task edited successfully.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    public void DeleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("Task deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    public void MarkTaskCompleted(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }
    public void DisplayTasks()
    {
        Console.WriteLine("Todo List:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {(tasks[i].IsCompleted ? "[X]" : "[ ]")} {tasks[i].Task}");
        }
    }


}

class Program
{
    static void Main(string[] args)
    {
        TodoList todoList = new TodoList();

        while (true)
        {
            Console.WriteLine("\nTodo List Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Mark Task as Completed");
            Console.WriteLine("5. Display Tasks");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter task to add: ");
                    string newTask = Console.ReadLine();
                    todoList.AddTask(newTask);
                    break;
                case 2:
                    Console.Write("Enter index of task to edit: ");
                    int editIndex;
                    if (int.TryParse(Console.ReadLine(), out editIndex))
                    {
                        Console.Write("Enter new task: ");
                        string editedTask = Console.ReadLine();
                        todoList.EditTask(editIndex - 1, editedTask);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;
                case 3:
                    Console.Write("Enter index of task to delete: ");
                    int deleteIndex;
                    if (int.TryParse(Console.ReadLine(), out deleteIndex))
                    {
                        todoList.DeleteTask(deleteIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;
                case 4:
                    Console.Write("Enter index of task to mark as completed: ");
                    int completeIndex;
                    if (int.TryParse(Console.ReadLine(), out completeIndex))
                    {
                        todoList.MarkTaskCompleted(completeIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;
                case 5:
                    todoList.DisplayTasks();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
