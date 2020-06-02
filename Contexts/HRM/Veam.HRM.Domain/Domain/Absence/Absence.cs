namespace HR.Entity
{
    using Dto;
    using System;
    using System.Collections.Generic;


    public partial class Absence
    {
       
        public Absence()
        {
            AbsenceDays = new HashSet<AbsenceDay>();
            ApprovalStateId = (int)ApprovalStates.Requested;
        }

        public int AbsenceId { get; set; }

        public int OrganisationId { get; set; }

        public int PersonnelAbsenceEntitlementId { get; set; }

        public int AbsenceTypeId { get; set; }

       
        public string AbsenceStatusByUser { get; set; }

       
        public DateTime? AbsenceStatusDateTimeUtc { get; set; }

        public string Description { get; set; }

        public bool? ReturnToWorkCompleted { get; set; }

        public bool? DoctorsNoteSupplied { get; set; }

        public int ApprovalStateId { get; set; }

        public virtual AbsenceType AbsenceType { get; set; }

        public virtual ApprovalState ApprovalState { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual PersonnelAbsenceEntitlement PersonnelAbsenceEntitlement { get; set; } 
        public virtual ICollection<AbsenceDay> AbsenceDays { get; set; }
    }
}
