using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GradutionProject.Areas.Identity.Data;

namespace GradutionProject.Models
{
    public enum Finishig
    {
       
        [Display(Name = "كامل")]
        Normal = 1,
        [Display(Name = "لوكس")]
        Lux = 2,
        [Display(Name = "سوبر لوكس")]
        superlux = 3,

    }
    public enum Furniture
    {

        [Display(Name = "مفروش")]
        Full = 1,
        [Display(Name = "مفروش جزئياً")]
        Part = 2,
        [Display(Name = "غير مفروش")]
        Empty = 2,
      
    }
    public class Post
    {
        [Key]
        public int Post_Id { get; set; }
        [Required(ErrorMessage = "This Field Required Please Add Description")]
        [Display(Name ="تفاصيل الخدمة")]
        [DataType(DataType.MultilineText)]
        public string Post_Desc { get; set; }
        [Required(ErrorMessage ="This Field Required Please Add Title")]
        [Display(Name = "عنوان الخدمة")]
        public string Post_Title { get; set; }
        [Column (TypeName ="DateTime")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yy}")]//Edit
        public DateTime Post_Create_Date { get; set; }
        [Display(Name = "عدد غرف النوم")]
        [Required]
        public int BedroomsNumber { get; set; }
        [Display(Name = "عدد الحمامات")]
        public int? BathroomsNumbers { get; set; }
        [EnumDataType(typeof(Furniture))]
        public Furniture FurnitureState { get; set; }
        [Required]
        public bool WIFI { get; set; }
        [EnumDataType(typeof(Finishig))]
        public Finishig FinishingState { get; set; }
        [Column(TypeName = "Money")]
        [Required(ErrorMessage = "This Field Required Please Add Price")]
        [Display(Name = "السعر")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal Price { get; set; }
       
        [Required]
        [Display(Name = "التكييف")]
        public bool AirCondition { get; set; }
        [Required]
        [Display(Name = "المصعد")]
        public bool Elevator { get; set; }
        [Range(1,20)]
        [Display(Name = "الطابق")]
        public int Floor { get; set; }
        [Display(Name = "رقم العقار")]
        public string BuildingNumber { get; set; }
        [Display(Name = "اسم الشارع")]
        public string Street { get; set; }
        [Required]
        [Column(TypeName = "float")]
        [Display(Name = "المساحة")]
        public float Area { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser _User { get; set; }

        public int? CategoryId { get; set; }
        
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? RegionId { get; set; }
        public  Region Region { get; set; }
        public  Category Category { get; set; }
        public  ICollection<Comments> Comments { get; set; }
        public  ICollection<Like> Likes { get; set; }
        public  ICollection<Images> Images { get; set; }



    }
}
