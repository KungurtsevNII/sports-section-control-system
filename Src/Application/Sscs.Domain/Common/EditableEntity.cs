using System;

namespace Sscs.Domain.Common
{
    public abstract class EditableEntity : Entity
    {
        public long? CreateUserId { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? ModifyUserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}