using System;
using System.IO;

class FileExplorer
{
    private string currentDirectory = Directory.GetCurrentDirectory();

    static void Main(string[] args)
    {
        FileExplorer explorer = new FileExplorer();

        while (true)
        {
            Console.WriteLine($"Текущая директория: {explorer.currentDirectory}");
            Console.Write("> ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "dirs":
                    explorer.ShowDirectories();
                    break;
                case "files":
                    explorer.ShowFiles();
                    break;
                case "back":
                    explorer.GoBack();
                    break;
                case "cd":
                    Console.Write("Введите имя директории: ");
                    string directoryName = Console.ReadLine();
                    explorer.ChangeDirectory(directoryName);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Неверная команда.");
                    break;
            }
        }
    }


    public void ShowDirectories()
    {
        try
        {
            string[] directories = Directory.GetDirectories(currentDirectory);
            Console.WriteLine("Директории:");
            foreach (string directory in directories)
            {
                Console.WriteLine(directory);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    public void ShowFiles()
    {
        try
        {
            string[] files = Directory.GetFiles(currentDirectory);
            Console.WriteLine("Файлы:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    public void GoBack()
    {
        try
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }


    public void ChangeDirectory(string directoryName)
    {
        try
        {
            string newDirectory = Path.Combine(currentDirectory, directoryName);
            if (Directory.Exists(newDirectory))
            {
                currentDirectory = newDirectory;
            }
            else
            {
                Console.WriteLine("Директория не найдена.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}