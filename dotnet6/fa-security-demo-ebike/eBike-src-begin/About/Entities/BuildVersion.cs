using System; //need for DateTime
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace About
{
    [Table("DatabaseVersion")]
    public class BuildVersion
    {
        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        public override string ToString() 
        {
		    return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, Release Date: {DateTime}";
	    }
    }
}