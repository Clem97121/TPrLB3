using System;
using System.Collections.Generic;

// Интерфейс курса
public interface ICourse
{
    void Enroll();
}

// Конкретный класс онлайн-курса
public class OnlineCourse : ICourse
{
    public void Enroll()
    {
        Console.WriteLine("Enrolling in online course...");
    }
}

// Конкретный класс курса в классе
public class ClassroomCourse : ICourse
{
    public void Enroll()
    {
        Console.WriteLine("Enrolling in classroom course...");
    }
}

// Конкретный класс самоучителя
public class SelfStudyCourse : ICourse
{
    public void Enroll()
    {
        Console.WriteLine("Enrolling in self-study course...");
    }
}

// Фабрика курсов
public interface ICourseFactory
{
    ICourse CreateCourse();
}

// Фабрика для создания онлайн-курсов
public class OnlineCourseFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new OnlineCourse();
    }
}

// Фабрика для создания курсов в классе
public class ClassroomCourseFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new ClassroomCourse();
    }
}

// Фабрика для создания самоучителей
public class SelfStudyCourseFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new SelfStudyCourse();
    }
}

// Клиентский код
class Program
{
    static void Main(string[] args)
    {
        // Создание фабрик
        var onlineCourseFactory = new OnlineCourseFactory();
        var classroomCourseFactory = new ClassroomCourseFactory();
        var selfStudyCourseFactory = new SelfStudyCourseFactory();

        // Создание курсов через фабрики
        var onlineCourse = onlineCourseFactory.CreateCourse();
        var classroomCourse = classroomCourseFactory.CreateCourse();
        var selfStudyCourse = selfStudyCourseFactory.CreateCourse();

        // Запись на курсы
        onlineCourse.Enroll();
        classroomCourse.Enroll();
        selfStudyCourse.Enroll();

        Console.ReadLine(); 
    }
}
