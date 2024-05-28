using System;

// Інтерфейс курсу
public interface ICourse
{
    void Enroll(); // Запис на курс
}

// Конкретний клас онлайн-курсу
public class OnlineCourse : ICourse
{
    public void Enroll()
    {
        Console.WriteLine("Запис на онлайн-курс...");
    }
}

// Конкретний клас курсу в класі
public class ClassroomCourse : ICourse
{
    public void Enroll()
    {
        Console.WriteLine("Запис на курс в аудиторії...");
    }
}

// Конкретний клас самостійного навчання
public class SelfStudyCourse : ICourse
{
    public void Enroll()
    {
        Console.WriteLine("Запис на самостійне навчання...");
    }
}

// Фабрика курсів
public interface ICourseFactory
{
    ICourse CreateCourse(); // Створення курсу
}

// Фабрика для створення онлайн-курсів
public class OnlineCourseFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new OnlineCourse();
    }
}

// Фабрика для створення курсів в аудиторії
public class ClassroomCourseFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new ClassroomCourse();
    }
}

// Фабрика для створення самостійних курсів
public class SelfStudyCourseFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new SelfStudyCourse();
    }
}

// Інтерфейс додаткового матеріалу
public interface IAdditionalMaterial
{
    void AddMaterial(); // Додавання матеріалу
}

// Конкретний клас відеоматеріалу
public class VideoMaterial : IAdditionalMaterial
{
    public void AddMaterial()
    {
        Console.WriteLine("Додавання відеоматеріалу...");
    }
}

// Конкретний клас файлового матеріалу
public class FileMaterial : IAdditionalMaterial
{
    public void AddMaterial()
    {
        Console.WriteLine("Додавання файлового матеріалу...");
    }
}

// Декоратор для додавання додаткових матеріалів до курсу
public class AdditionalMaterialDecorator : ICourse
{
    private readonly ICourse _course;
    private readonly IAdditionalMaterial _additionalMaterial;

    public AdditionalMaterialDecorator(ICourse course, IAdditionalMaterial additionalMaterial)
    {
        _course = course;
        _additionalMaterial = additionalMaterial;
    }

    public void Enroll()
    {
        _course.Enroll();
        _additionalMaterial.AddMaterial();
    }
}

// Інтерфейс стратегії навчання
public interface ILearningStrategy
{
    void Learn(); // Навчання
}

// Конкретна стратегія навчання: лекції
public class LectureLearningStrategy : ILearningStrategy
{
    public void Learn()
    {
        Console.WriteLine("Участь у лекціях...");
    }
}

// Конкретна стратегія навчання: практичні заняття
public class PracticalLearningStrategy : ILearningStrategy
{
    public void Learn()
    {
        Console.WriteLine("Участь у практичних заняттях...");
    }
}

// Конкретна стратегія навчання: тестування
public class TestingLearningStrategy : ILearningStrategy
{
    public void Learn()
    {
        Console.WriteLine("Проходження тестів...");
    }
}

// Декоратор для додавання стратегії навчання до курсу
public class LearningStrategyDecorator : ICourse
{
    private readonly ICourse _course;
    private readonly ILearningStrategy _learningStrategy;

    public LearningStrategyDecorator(ICourse course, ILearningStrategy learningStrategy)
    {
        _course = course;
        _learningStrategy = learningStrategy;
    }

    public void Enroll()
    {
        _course.Enroll();
        _learningStrategy.Learn();
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        // Створення фабрик
        var onlineCourseFactory = new OnlineCourseFactory();
        var classroomCourseFactory = new ClassroomCourseFactory();
        var selfStudyCourseFactory = new SelfStudyCourseFactory();

        // Створення стратегій навчання
        var lectureLearningStrategy = new LectureLearningStrategy();
        var practicalLearningStrategy = new PracticalLearningStrategy();
        var testingLearningStrategy = new TestingLearningStrategy();

        // Створення курсів через фабрики
        var onlineCourse = onlineCourseFactory.CreateCourse();
        var classroomCourse = classroomCourseFactory.CreateCourse();
        var selfStudyCourse = selfStudyCourseFactory.CreateCourse();

        // Додавання стратегій навчання до курсів
        onlineCourse = new LearningStrategyDecorator(onlineCourse, lectureLearningStrategy);
        classroomCourse = new LearningStrategyDecorator(classroomCourse, practicalLearningStrategy);
        selfStudyCourse = new LearningStrategyDecorator(selfStudyCourse, testingLearningStrategy);

        // Додавання додаткових матеріалів до курсів
        onlineCourse = new AdditionalMaterialDecorator(onlineCourse, new VideoMaterial());
        classroomCourse = new AdditionalMaterialDecorator(classroomCourse, new FileMaterial());

        // Запис на курси
        onlineCourse.Enroll();
        classroomCourse.Enroll();
        selfStudyCourse.Enroll();

        Console.ReadLine(); // Щоб консольне вікно не закривалося відразу після виконання коду
    }
}
