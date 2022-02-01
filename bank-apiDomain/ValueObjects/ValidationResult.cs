namespace bank_apiDomain.ValueObjects
{
    public class ValidationResult
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; private set; }
        public ErrorTypes ErrorType { get; private set; }
        public bool IsNotFound => ErrorType == ErrorTypes.NotFound;
        public bool IsValidationError => ErrorType == ErrorTypes.Validation;
        public bool IsForbidden => ErrorType == ErrorTypes.Forbidden;

        protected ValidationResult()
        {
            IsSuccess = true;
            ErrorType = ErrorTypes.None;
        }
        protected ValidationResult(string error)
        {
            Error = error;
            IsSuccess = false;
            ErrorType = ErrorTypes.Validation;
        }
        protected ValidationResult(string error, ErrorTypes errorType) : this(error) => ErrorType = errorType;
        protected ValidationResult(ValidationResult validationResult)
        {
            Error = validationResult.Error;
            IsSuccess = validationResult.IsSuccess;
            ErrorType = validationResult.ErrorType;
        }

        public static ValidationResult Failure(string error) => new ValidationResult(error);
        public static ValidationResult Failure(string error, ErrorTypes errorType) => new ValidationResult(error, errorType);
        public static ValidationResult Success() => new ValidationResult();
        public static ValidationResult Failure(ValidationResult validationResult) => new ValidationResult(validationResult);
    }

    public class ValidationResult<T> : ValidationResult
    {
        public T Value { get; private set; }

        private ValidationResult(T value) : base() => Value = value;
        private ValidationResult(string error) : base(error) { }
        protected ValidationResult(string error, ErrorTypes errorType) : base(error, errorType) { }
        protected ValidationResult(ValidationResult validationResult) : base(validationResult) { }

        public static ValidationResult<T> Success(T value) => new ValidationResult<T>(value);
        public static ValidationResult<T> Failure(string error) => new ValidationResult<T>(error);
        public static ValidationResult<T> Failure(string error, ErrorTypes errorType) => new ValidationResult<T>(error, errorType);
        public static ValidationResult<T> Failure(ValidationResult validationResult) => new ValidationResult<T>(validationResult);
    }

    public enum ErrorTypes
    {
        None,
        Validation,
        NotFound,
        Forbidden
    }
}
