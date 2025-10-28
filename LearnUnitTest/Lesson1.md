# 🧪 Unit Test Practice (xUnit + Moq)

## 🎯 Mục tiêu
Bộ bài tập này giúp bạn làm quen với **Unit Test trong .NET** bằng framework **xUnit** và thư viện **Moq**.

Sau khi hoàn thành, bạn sẽ nắm được:
- Cách tạo project test (`xUnit`)
- Cách viết test case với `[Fact]`, `[Theory]`
- Sử dụng `Assert` để kiểm tra kết quả
- Cách mock service/repository bằng `Moq`
- Cách phân biệt project code chính và project test

---

## 🧩 Cấu trúc thư mục
#### UnitTestPractice/
#### │
#### ├── Calculator/
#### │ ├── Calculator.cs # Code logic thật
#### │ └── CalculatorTests.cs # Test các hàm Calculator
#### │
#### ├── NumberService/
#### │ ├── NumberService.cs
#### │ └── NumberServiceTests.cs
#### │
#### ├── ScoreService/
#### │ ├── ScoreService.cs
#### │ └── ScoreServiceTests.cs
#### │
#### └── UserService/
#### ├── IUserRepository.cs
#### ├── User.cs
#### ├── UserService.cs
#### └── UserServiceTests.cs

---

## 🧮 **Bài 1 – Calculator**

### 🎯 Mục tiêu:
Hiểu cách dùng `Assert.Equal()` và `Assert.Throws()`.

### 📘 Yêu cầu:
Tạo class `Calculator.cs`:
```csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException();
        return a / b;
    }

```
```csharp
Tạo file test CalculatorTests.cs:
using Xunit;

public class CalculatorTests
{
private readonly Calculator _calc = new();

    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        var result = _calc.Add(2, 3);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_ByZero_ShouldThrowException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }
}
```
## ⚙️ **Bài 2 – NumberService**

### 🎯 Mục tiêu:
Hiểu Assert.True() và Assert.False().

### 📘 Code:
```csharp
public class NumberService
{
    public bool IsEven(int x) => x % 2 == 0;
}
```
### 📗 Test:
```csharp
using Xunit;

public class NumberServiceTests
{
    private readonly NumberService _service = new();

    [Fact]
    public void IsEven_ShouldReturnTrue_WhenEven()
    {
        Assert.True(_service.IsEven(4));
    }

    [Fact]
    public void IsEven_ShouldReturnFalse_WhenOdd()
    {
        Assert.False(_service.IsEven(5));
    }
}
```
## ⚙️ **Bài 3 – ScoreService**

### 🎯 Mục tiêu:
Hiểu Assert.True() và Assert.False().
### 📘 Code:
```csharp
public class ScoreService
{
    public double Average(int a, int b, int c)
        => (a + b + c) / 3.0;
}
```
### 📗 Test:
```csharp
using Xunit;

public class ScoreServiceTests
{
    [Theory]
    [InlineData(5, 5, 5, 5)]
    [InlineData(3, 4, 5, 4)]
    [InlineData(10, 5, 5, 6.67)]
    public void Average_ShouldReturnCorrectValue(int a, int b, int c, double expected)
    {
        var service = new ScoreService();
        var result = service.Average(a, b, c);

        Assert.Equal(expected, result, 2);
    }
}
```
## ⚙️ **Bài 4 – UserService (Mock Repository)**

### 🎯 Mục tiêu:
Biết cách mock repository bằng Moq.
### 📘 Code:
```csharp
public interface IUserRepository
{
    User? GetById(int id);
}

public class UserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public string GetUserName(int id)
    {
        var user = _repo.GetById(id);
        return user?.Name ?? "Not found";
    }
}

public class User { public int Id { get; set; } public string Name { get; set; } = ""; }
```
### 📗 Test:
using Xunit;
using Moq;
```csharp
public class UserServiceTests
{
[Fact]
public void GetUserName_ShouldReturnName_WhenUserExists()
{
var mockRepo = new Mock<IUserRepository>();
mockRepo.Setup(r => r.GetById(1))
.Returns(new User { Id = 1, Name = "Sang" });

        var service = new UserService(mockRepo.Object);
        var result = service.GetUserName(1);

        Assert.Equal("Sang", result);
    }

    [Fact]
    public void GetUserName_ShouldReturnNotFound_WhenUserMissing()
    {
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetById(99)).Returns((User?)null);

        var service = new UserService(mockRepo.Object);
        var result = service.GetUserName(99);

        Assert.Equal("Not found", result);
    }
}
```
### Cách chạy test
Trong thư mục project, chạy:
```bash
dotnet test
```
Nếu tất cả test pass:
```bash
Passed!  All tests successful 🎉
```
Nếu có lỗi:
```bash
Assert.Equal() Failure
Expected: 5
Actual:   4
```