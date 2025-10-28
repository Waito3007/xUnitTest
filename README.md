🧪 Unit Test Practice (.NET, xUnit & Moq)
🎯 Mục tiêu chung
Bộ bài tập này giúp bạn làm quen với Unit Test trong .NET sử dụng framework xUnit và thư viện mocking Moq.

Sau khi hoàn thành, bạn sẽ nắm được:

Cách tạo và cấu trúc một project test (xUnit).

Cách viết các test case cơ bản với [Fact] và [Theory].

Sử dụng các phương thức Assert để kiểm tra tính đúng đắn của code.

Cách "giả lập" (mock) các dependency (ví dụ: repository, service) bằng Moq để cô lập đối tượng cần test.

🧩 Cấu trúc thư mục đề xuất
Để thực hành, bạn nên tạo một solution với cấu trúc project như sau: một project chính chứa code logic và một project test để kiểm tra nó.

UnitTestPracticeSolution/
│
├── UnitTestPractice/ (Class Library - Code chính)
│   ├── Calculator.cs
│   ├── NumberService.cs
│   ├── ScoreService.cs
│   └── UserService/
│       ├── IUserRepository.cs
│       ├── User.cs
│       └── UserService.cs
│
└── UnitTestPractice.Tests/ (xUnit Test Project)
    ├── CalculatorTests.cs
    ├── NumberServiceTests.cs
    ├── ScoreServiceTests.cs
    └── UserServiceTests.cs
🧮 Bài 1 – Calculator
🎯 Mục tiêu
Làm quen với [Fact].

Sử dụng Assert.Equal() để so sánh kết quả mong đợi.

Sử dụng Assert.Throws<T>() để kiểm tra việc ném ngoại lệ.

📘 Code cần test
Tạo file Calculator.cs với nội dung:

C#

public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException();
        return a / b;
    }
}
✍️ Yêu cầu
Trong file CalculatorTests.cs, hãy viết các test case sau:

Add_ShouldReturnCorrectSum: Kiểm tra rằng hàm Add(2, 3) trả về kết quả là 5.

Divide_ByZero_ShouldThrowException: Kiểm tra rằng khi gọi hàm Divide(10, 0), một ngoại lệ DivideByZeroException sẽ được ném ra.

🔢 Bài 2 – NumberService
🎯 Mục tiêu
Sử dụng Assert.True() và Assert.False() để kiểm tra các điều kiện boolean.

📘 Code cần test
Tạo file NumberService.cs với nội dung:

C#

public class NumberService
{
    public bool IsEven(int number) => number % 2 == 0;
}
✍️ Yêu cầu
Trong file NumberServiceTests.cs, hãy viết các test case sau:

IsEven_ShouldReturnTrue_WhenNumberIsEven: Kiểm tra rằng hàm IsEven(4) trả về true.

IsEven_ShouldReturnFalse_WhenNumberIsOdd: Kiểm tra rằng hàm IsEven(5) trả về false.

🏆 Bài 3 – ScoreService
🎯 Mục tiêu
Sử dụng [Theory] và [InlineData] để kiểm tra nhiều bộ dữ liệu khác nhau cho cùng một logic.

Học cách so sánh số thực với độ chính xác (precision).

📘 Code cần test
Tạo file ScoreService.cs với nội dung:

C#

public class ScoreService
{
    public double Average(int a, int b, int c) => (a + b + c) / 3.0;
}
✍️ Yêu cầu
Trong file ScoreServiceTests.cs, hãy viết một test case duy nhất Average_ShouldReturnCorrectValue sử dụng [Theory] để kiểm tra các trường hợp sau: | Input (a, b, c) | Expected Output | | :--- | :--- | | (5, 5, 5) | 5 | | (3, 4, 5) | 4 | | (10, 5, 5) | 6.67 |

Gợi ý: Khi dùng Assert.Equal() để so sánh số thực, hãy cung cấp tham số thứ ba để chỉ định độ chính xác (ví dụ: 2 chữ số thập phân).

👤 Bài 4 – UserService (Sử dụng Moq)
🎯 Mục tiêu
Hiểu khái niệm Dependency Injection (DI) trong unit test.

Sử dụng Moq để tạo đối tượng giả lập (mock) cho một interface (dependency).

Kiểm tra logic của một service mà không phụ thuộc vào implementation thật của repository.

📘 Code cần test
Tạo các file sau: IUserRepository.cs, User.cs, và UserService.cs.

C#

// IUserRepository.cs
public interface IUserRepository
{
    User? GetById(int id);
}

// User.cs
public class User 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } = ""; 
}

// UserService.cs
public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string GetUserName(int id)
    {
        var user = _userRepository.GetById(id);
        return user?.Name ?? "Not found";
    }
}
✍️ Yêu cầu
Trong file UserServiceTests.cs, hãy sử dụng Moq để viết các test case sau:

GetUserName_ShouldReturnName_WhenUserExists:

Tạo một mock của IUserRepository.

Thiết lập (setup) mock sao cho khi phương thức GetById(1) được gọi, nó sẽ trả về một đối tượng User có Id = 1 và Name = "Sang".

Kiểm tra rằng kết quả trả về của userService.GetUserName(1) là "Sang".

GetUserName_ShouldReturnNotFound_WhenUserIsMissing:

Tạo một mock của IUserRepository.

Thiết lập mock sao cho khi phương thức GetById(99) được gọi, nó sẽ trả về null.

Kiểm tra rằng kết quả trả về của userService.GetUserName(99) là "Not found".

🚀 Cách chạy test
Sau khi đã viết xong code test, mở Terminal trong thư mục của project test và chạy lệnh:

Bash

dotnet test
Nếu tất cả các bài test đều đúng, bạn sẽ thấy thông báo thành công. Nếu có lỗi, terminal sẽ chỉ rõ test case nào thất bại và lý do.

Chúc bạn thực hành vui vẻ!

<details> <summary><strong>👉 Nhấn vào đây để xem gợi ý đáp án</strong></summary>

🔑 Đáp án Bài 1 – CalculatorTests.cs
C#

using System;
using Xunit;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        int a = 2;
        int b = 3;
        int expected = 5;

        // Act
        var result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_ByZero_ShouldThrowException()
    {
        // Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }
}
🔑 Đáp án Bài 2 – NumberServiceTests.cs
C#

using Xunit;

public class NumberServiceTests
{
    private readonly NumberService _service = new();

    [Fact]
    public void IsEven_ShouldReturnTrue_WhenNumberIsEven()
    {
        // Act & Assert
        Assert.True(_service.IsEven(4));
    }

    [Fact]
    public void IsEven_ShouldReturnFalse_WhenNumberIsOdd()
    {
        // Act & Assert
        Assert.False(_service.IsEven(5));
    }
}
🔑 Đáp án Bài 3 – ScoreServiceTests.cs
C#

using Xunit;

public class ScoreServiceTests
{
    [Theory]
    [InlineData(5, 5, 5, 5)]
    [InlineData(3, 4, 5, 4)]
    [InlineData(10, 5, 5, 6.67)]
    public void Average_ShouldReturnCorrectValue(int a, int b, int c, double expected)
    {
        // Arrange
        var service = new ScoreService();
        
        // Act
        var result = service.Average(a, b, c);

        // Assert
        Assert.Equal(expected, result, 2); // 2 is for 2 decimal places precision
    }
}
🔑 Đáp án Bài 4 – UserServiceTests.cs
C#

using Xunit;
using Moq;

public class UserServiceTests
{
    [Fact]
    public void GetUserName_ShouldReturnName_WhenUserExists()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        var user = new User { Id = 1, Name = "Sang" };
        
        mockRepo.Setup(r => r.GetById(1)).Returns(user);

        var service = new UserService(mockRepo.Object);

        // Act
        var result = service.GetUserName(1);

        // Assert
        Assert.Equal("Sang", result);
    }

    [Fact]
    public void GetUserName_ShouldReturnNotFound_WhenUserIsMissing()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();

        // Setup the mock to return null for a specific ID
        mockRepo.Setup(r => r.GetById(99)).Returns((User?)null);
        
        var service = new UserService(mockRepo.Object);

        // Act
        var result = service.GetUserName(99);

        // Assert
        Assert.Equal("Not found", result);
    }
}
