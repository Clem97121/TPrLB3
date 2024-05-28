using System;

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

// Интерфейс дополнительного материала
public interface IAdditionalMaterial
{
    void AddMaterial();
}

// Конкретный класс видеоурока
public class VideoMaterial : IAdditionalMaterial
{
    public void AddMaterial()
    {
        Console.WriteLine("Adding video material...");
    }
}

// Конкретный класс учебного файла
public class FileMaterial : IAdditionalMaterial
{
    public void AddMaterial()
    {
        Console.WriteLine("Adding file material...");
    }
}

// Декоратор для добавления дополнительных материалов к курсу
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

// Интерфейс стратегии обучения
public interface ILearningStrategy
{
    void Learn();
}

// Конкретная стратегия обучения: лекции
public class LectureLearningStrategy : ILearningStrategy
{
    public void Learn()
    {
        Console.WriteLine("Attending lectures...");
    }
}

// Конкретная стратегия обучения: практические занятия
public class PracticalLearningStrategy : ILearningStrategy
{
    public void Learn()
    {
        Console.WriteLine("Participating in practical sessions...");
    }
}

// Конкретная стратегия обучения: тестирование
public class TestingLearningStrategy : ILearningStrategy
{
    public void Learn()
    {
        Console.WriteLine("Taking tests...");
    }
}

// Декоратор для добавления стратегии обучения к курсу
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

// Клиентский код
class Program
{
    static void Main(string[] args)
    {
        // Создание фабрик
        var onlineCourseFactory = new OnlineCourseFactory();
        var classroomCourseFactory = new ClassroomCourseFactory();
        var selfStudyCourseFactory = new SelfStudyCourseFactory();

        // Создание стратегий обучения
        var lectureLearningStrategy = new LectureLearningStrategy();
        var practicalLearningStrategy = new PracticalLearningStrategy();
        var testingLearningStrategy = new TestingLearningStrategy();

        // Создание курсов через фабрики
        var onlineCourse = onlineCourseFactory.CreateCourse();
        var classroomCourse = classroomCourseFactory.CreateCourse();
        var selfStudyCourse = selfStudyCourseFactory.CreateCourse();

        // Добавление стратегий обучения к курсам
        onlineCourse = new LearningStrategyDecorator(onlineCourse, lectureLearningStrategy);
        classroomCourse = new LearningStrategyDecorator(classroomCourse, practicalLearningStrategy);
        selfStudyCourse = new LearningStrategyDecorator(selfStudyCourse, testingLearningStrategy);

        // Добавление дополнительных материалов к курсам
        onlineCourse = new AdditionalMaterialDecorator(onlineCourse, new VideoMaterial());
        classroomCourse = new AdditionalMaterialDecorator(classroomCourse, new FileMaterial());

        // Запись на курсы
        onlineCourse.Enroll();
        classroomCourse.Enroll();
        selfStudyCourse.Enroll();

        Console.ReadLine(); // Чтобы консольное окно не закрывалось сразу после выполнения кода
    }
}
