using System;

namespace Sscs.Domain.SharedKernel
{
    public abstract class EditableEntity : Entity
    {
        public long? CreateUserId { get; set; }

        public DateTime? CreateDateUtc { get; set; }

        public long? ModifyUserId { get; set; }

        public DateTime? ModifyDateUtc { get; set; }

        public bool IsDeleted { get; set; }
    }
}