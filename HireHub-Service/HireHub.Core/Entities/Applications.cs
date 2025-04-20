using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.Entities
{
    [Table("Applications")]
    public class Applications
    {
        [Key]
        public int Id { get; set; } // מפתח ראשי (Primary Key)

        [ForeignKey(nameof(CandidateUser))]
        public int CandidateId { get; set; } // מפתח זר (Foreign Key) שמצביע על ה-Id של המשתמש המועמד

        public User CandidateUser { get; set; } // אובייקט המשתמש המועמד

        [ForeignKey(nameof(JobCandidate))]
        public int JobId { get; set; } // מפתח זר (Foreign Key) שמצביע על ה-Id של המשרה

        public Jobs JobCandidate { get; set; } // אובייקט המשרה

        [ForeignKey(nameof(UserResume))]
        public int? ResumeId { get; set; } // מפתח זר אופציונלי (Foreign Key) שמצביע על ה-Id של קורות החיים

        public Resumes UserResume { get; set; } // אובייקט קורות החיים

        public int Score { get; set; } // ציון המועמדות

        public string Status { get; set; } // סטטוס המועמדות (למשל: ממתין, ראיון, התקבל)

        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow; // תאריך הגשת המועמדות
    }
}