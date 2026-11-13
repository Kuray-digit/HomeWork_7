using System;

namespace Program
{
    class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Employee> Subordinates { get; set; } = new List<Employee>();

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public void AddSubordinate(Employee subordinate)
        {
            Subordinates.Add(subordinate);
        }

        public bool IsDirectManagerOf(Employee sub)
        {
            return Subordinates.Contains(sub);
        }
    }

    class TaskItem
    {
        public string Title { get; set; }
        public List<Employee> TargetEmployees { get; set; }

        public TaskItem(string title, List<Employee> targetEmployees)
        {
            Title = title;
            TargetEmployees = targetEmployees;
        }
    }

    class HoneWork7
{
        static void Main()
        {
            Employee timur = new Employee("Тимур", "Генеральный директор");
            Employee rashid = new Employee("Рашид", "Финансовый директор");
            Employee oilham = new Employee("О Ильхам", "Директор по автоматизации");
            timur.AddSubordinate(rashid);
            timur.AddSubordinate(oilham);

            Employee lukas = new Employee("Лукас", "Главный бухгалтер");
            rashid.AddSubordinate(lukas);

            Employee orkadiy = new Employee("Оркадий", "Начальник инф. систем");
            Employee volodya = new Employee("Володя", "Зам. начальника ИТ");
            oilham.AddSubordinate(orkadiy);
            oilham.AddSubordinate(volodya);

            Employee ilshat = new Employee("Ильшат", "Главный сектора системщиков");
            Employee ivanych = new Employee("Иваныч", "Зам. сектора системщиков");
            orkadiy.AddSubordinate(ilshat);
            volodya.AddSubordinate(ilshat);
            ilshat.AddSubordinate(ivanych);

            Employee ilya = new Employee("Илья", "Системщик");
            Employee vitya = new Employee("Витя", "Системщик");
            Employee zhenya = new Employee("Женя", "Системщик");
            ivanych.AddSubordinate(ilya);
            ivanych.AddSubordinate(vitya);
            ivanych.AddSubordinate(zhenya);

            Employee sergey = new Employee("Сергей", "Главный сектора разработчиков");
            Employee lyaysan = new Employee("Ляйсан", "Зам. сектора разработчиков");
            orkadiy.AddSubordinate(sergey);
            volodya.AddSubordinate(sergey);
            sergey.AddSubordinate(lyaysan);

            Employee marat = new Employee("Марат", "Разработчик");
            Employee dina = new Employee("Дина", "Разработчик");
            Employee ildar = new Employee("Ильдар", "Разработчик");
            Employee anton = new Employee("Антон", "Разработчик");
            lyaysan.AddSubordinate(marat);
            lyaysan.AddSubordinate(dina);
            lyaysan.AddSubordinate(ildar);
            lyaysan.AddSubordinate(anton);

            List<TaskItem> tasks = new List<TaskItem>
            {
                new TaskItem("Автоматизация бухгалтерии", new List<Employee> { sergey, lyaysan }),
                
                new TaskItem("Настроить локальную сеть", new List<Employee> { ilshat, ivanych }),
                
                new TaskItem("Купить новые серверы", new List<Employee> { orkadiy, volodya }),
                
                new TaskItem("Поправить верстку отчета", new List<Employee> { dina })
            };

            Employee assigner = timur;

            foreach (var task in tasks)
            {
                Console.WriteLine($"Задача: \"{task.Title}\"");
                Console.WriteLine($"Передается от: {assigner.Name} ({assigner.Position})");

                bool someoneTookTask = false;

                foreach (var employee in task.TargetEmployees)
                {
                    bool isDirect = assigner.IsDirectManagerOf(employee);

                    if (isDirect)
                    {
                        Console.WriteLine($"{employee.Name} ({employee.Position}): БЕРЕТ задачу.");
                        someoneTookTask = true;
                    }
                    else
                    {
                        Console.WriteLine($"{employee.Name} ({employee.Position}): НЕ БЕРЕТ (не прямое руководство).");
                    }
                }

                if (!someoneTookTask)
                {
                    Console.WriteLine("  [!] Задача никем не взята.");
                }
                Console.WriteLine();
            }
        }
    }
}