using HireHub.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireHub.Core.Entities
{
    [Table("Resumes")]
    public class Resumes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // מפתח ראשי (Primary Key) עם יצירה אוטומטית

        public int CandidateId { get; set; } // מפתח זר (Foreign Key) שמצביע על ה-Id של המשתמש המועמד

        [ForeignKey("CandidateId")]
        public User Candidate { get; set; } // אובייקט המשתמש המועמד

        public string Path { get; set; } // נתיב הקובץ

        public DateTime UploadedOn { get; set; } = DateTime.UtcNow; // תאריך העלאת הקובץ

        [Column("UpdatedOn", TypeName = "timestamp with time zone")]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow; // תאריך עדכון הקובץ האחרון

        public bool IsGeneral { get; set; } // האם הקובץ הוא קורות חיים כלליים

        public string ContentType { get; set; } // סוג התוכן של הקובץ

        public int DownloadCount { get; set; } = 0; // מספר הפעמים שהקובץ הורד
    }
}