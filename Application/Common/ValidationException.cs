namespace Application.Common;

public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException(IEnumerable<string> failures) 
    {
        Errors = failures.ToList();
    }
}
