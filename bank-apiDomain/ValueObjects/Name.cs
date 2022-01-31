namespace bank_apiDomain.ValueObjects
{
    public class Name
    {
        public string First { get; private set; }
        public string Last { get; private set; }

        protected Name() { }
        private Name(string first, string last)
        {
            First = first;
            Last = last;
        }

        public static ValidationResult<Name> Create(string first, string last)
        {
            if (string.IsNullOrEmpty(first))
                return ValidationResult<Name>.Failure("First Name Required");
            if (string.IsNullOrEmpty(last))
                return ValidationResult<Name>.Failure("Last Name Required");

            return ValidationResult<Name>.Success(new Name(first, last));
        }
    }
}
