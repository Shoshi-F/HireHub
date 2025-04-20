using HireHub.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireHub.Core.Entities
{
    [Table("Jobs")]
    public class Jobs
    {
        [Key]
        public int Id { get; set; } // מפתח ראשי (Primary Key)

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; } // כותרת המשרה

        [Required]
        public string Description { get; set; } // תיאור המשרה

        public string? Company { get; set; } // שם החברה (אופציונלי)

        [Required]
        public string JobRequirements { get; set; } // דרישות המשרה

        public string JobSkills { get; set; } // מיומנויות נדרשות

        public int YearsOfExperienceRequired { get; set; } // מספר שנות ניסיון נדרש

        public string Area { get; set; } // אזור המשרה

        public int RecruiterId { get; set; } // מפתח זר (Foreign Key) למשתמש המגייס

        [ForeignKey("RecruiterId")]
        public User RecruitingUser { get; set; } // אובייקט המשתמש המגייס

        public List<Applications> Applications { get; set; } = new List<Applications>(); // רשימת המועמדויות שהוגשו למשרה

        [Column("CreatedOn", TypeName = "timestamp with time zone")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow; // תאריך יצירת המשרה

        [Column("UpdatedOn", TypeName = "timestamp with time zone")]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow; // תאריך עדכון המשרה האחרון

        public bool IsActive { get; set; } // האם המשרה פעילה

        public string Category { get; set; } // קטגוריה של המשרה

        public int ViewsCount { get; set; } = 0; // מספר הצפיות במשרה

        public string SalaryRange { get; set; } // טווח שכר
    }
}