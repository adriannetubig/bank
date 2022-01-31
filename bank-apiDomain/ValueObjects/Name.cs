using CSharpFunctionalExtensions;

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

        public static Result<Name> Create(string first, string last)
        {
            if (string.IsNullOrEmpty(first))
                return Result.Failure<Name>("First Name Required");
            if (string.IsNullOrEmpty(last))
                return Result.Failure<Name>("Last Name Required");

            return Result.Success(new Name(first, last));
        }
    }
}
