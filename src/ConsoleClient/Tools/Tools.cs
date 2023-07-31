

namespace ConsoleClient.Tools;


public class Tools
{
    public string FizzBuz()
    {

        Func<int, string> transformNumbers = (int n) =>
        {

            if (n % 3 == 0 && n % 5 == 0) return $"FizzBuzz{n}";

            if (n % 3 == 0) return $"Fizz{n}";

            if (n % 5 == 0) return $"Buzz{n}";

            return n.ToString();
        };
        var numbers = Enumerable.Range(1, 100)
                                .Select(n => transformNumbers(n))
                              .ToList();

        numbers.ForEach(n => Console.WriteLine(n));
        return "0";
    }

    public async Task ExampleFunc(string message)
    {
        await Task.Run(() => Console.WriteLine(message));
    }

    public void FizzBuzz(int n)
    {
        var transformers = new Dictionary<Func<int, bool>, string>
        {
            { i => i % 3 == 0 && i % 5 == 0, "FizzBuzz" },
            { i => i % 3 == 0, "Fizz" },
            { i => i % 5 == 0, "Buzz" }
        };

        for (int i = 1; i <= n; i++)
        {
            var transformer = transformers.FirstOrDefault(t => t.Key(i));
            Console.WriteLine(transformer.Value ?? i.ToString());
        }
    }


    public record User(string UserName, string Password);
    public record Email(string To, string Subject, string Body);

    public interface IUserService
    {
        Task<(bool, string)> LogIn(User user);
        Task<(bool, string)> SignUp(User user);
    }

    public interface IEmailService
    {
        Task<(bool, string)> SendEmail(Email email);
    }

    public interface ILoggingService
    {
        void LogInformation(string message);
    }

    public class UserService : IUserService
    {
        public async Task<(bool, string)> LogIn(User user)
        {
            return await Task.FromResult((true, "Login successful"));
        }

        public async Task<(bool, string)> SignUp(User user)
        {
            return await Task.FromResult((true, "Signup successful"));
        }
    }

    public class EmailService : IEmailService
    {
        public async Task<(bool, string)> SendEmail(Email email)
        {
            return await Task.FromResult((true, "Email sent successfully"));
        }
    }

    public class LoggingService : ILoggingService
    {
        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }


}
