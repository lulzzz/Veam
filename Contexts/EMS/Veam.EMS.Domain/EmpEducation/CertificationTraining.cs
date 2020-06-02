using System;
using System.Collections.Generic;

namespace Veam.EMS.Domain
{
    public partial class CertificationTraining : BaseEntity
    {
        private CertificationTraining()
        {
            
        }
        public string CertOrTrain { get; protected set; }
        public string TopicName { get; protected set; }
        public string Institution { get; protected set; }
        public string compltionYear { get; protected set; }
        public string Period { get; protected set; }
      
        public EmployeeEducation EmployeeEducation { get; set; }
        public long EmpEducationId { get; set; }
    }
}
