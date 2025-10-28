~~# 🧪 Unit Test Practice (xUnit + Moq)

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
UnitTestPractice/
* │
* ├── Calculator/
* │ ├── Calculator.cs # Code logic thật
* │ └── CalculatorTests.cs # Test các hàm Calculator
* │
* ├── NumberService/
* │ ├── NumberService.cs
* │ └── NumberServiceTests.cs
* │
* ├── ScoreService/
* │ ├── ScoreService.cs
* │ └── ScoreServiceTests.cs
* │
* └── UserService/
* ├── IUserRepository.cs
* ├── User.cs
* ├── UserService.cs
* └── UserServiceTests.cs └── UserServiceTests.cs

---

## 🧮 **Bài 1 – Calculator**

### 🎯 Mục tiêu:
Hiểu cách dùng `Assert.Equal()` và `Assert.Throws()`.

### 📘 Yêu cầu:
- Viết các hàm:
  ```csharp
  Add(a,b), Subtract(a,b), Divide(a,b)
- Test các trường hợp:
    ```csharp
    Add(2,3) → 5
    
    Subtract(5,2) → 3
    
    Divide(6,2) → 3
    
    Divide(10,0) → ném DivideByZeroException
    ```
## ⚙️ **Bài 2 – NumberService**

### 🎯 Mục tiêu:
Hiểu Assert.True() và Assert.False().
### 📘 Yêu cầu:
- hàm IsEven(int x) trả về true nếu số chẵn.

- Test:

- IsEven(4) → true

- IsEven(5) → false
## ⚙️ **Bài 3 – ScoreService**

### 🎯 Mục tiêu:
Hiểu Assert.True() và Assert.False().
### 📘 Yêu cầu:
- Viết hàm Average(a,b,c) trả điểm trung bình.

- Test nhiều bộ dữ liệu:
    ```csharp
    [InlineData(5,5,5,5)]
    [InlineData(3,4,5,4)]
    [InlineData(10,5,5,6.67)]
    ```
- Gợi ý:
  ```csharp
  Assert.Equal(expected, actual, precision: 2);
    ```
## ⚙️ **Bài 4 – UserService (Mock Repository)**
### 🎯 Mục tiêu:
Biết cách mock repository bằng Moq.
### 🧱 Cấu trúc:
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
````        

### 📘 Yêu cầu:
1. Mock repository bằng Moq.

2. Khi GetById(1) → trả new User { Id=1, Name="Sang" }.

3. Khi GetById(99) → trả null.

4. Kiểm tra:
```csharp
Assert.Equal("Sang", result);
Assert.Equal("Not found", result);
mock.Verify(r => r.GetById(It.IsAny<int>()), Times.Exactly(2));

```
### Cách chạy test
Trong thư mục project, chạy:
```
dotnet test
```
Nếu tất cả test pass:
```
Passed!  All tests successful 🎉
```
Nếu có lỗi:
```
Assert.Equal() Failure
Expected: 5
Actual:   4
```~~
