using CSharpFunctionalExtensions;

namespace bank_apiDomain.Entities
{
    public abstract class BaseEntity : Entity
    {
        public DateTime DateCreatedUtc { get; private set; }
        public DateTime? DateUpdatedUtc { get; private set; }

        public BaseEntity() => DateCreatedUtc = DateTime.UtcNow; //ToDo: check if this will be overwritten on load

        public void Update() => DateUpdatedUtc = DateTime.UtcNow;
    }
}
