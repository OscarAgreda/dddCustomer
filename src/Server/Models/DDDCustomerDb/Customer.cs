using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDDCustomerUi.Server.Models.DDDCustomerDb
{
    [Table("Customer", Schema = "dbo")]
    public partial class Customer
    {

        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("@odata.etag")]
        public string ETag
        {
                get;
                set;
        }

        [Key]
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [ConcurrencyCheck]
        public int CustomerNumber { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string FirstName { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string LastName { get; set; }

        [ConcurrencyCheck]
        public decimal? CreditLimit { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string PhoneNumber { get; set; }

        [Column(TypeName="datetime2")]
        [Required]
        [ConcurrencyCheck]
        public DateTime DateCreated { get; set; }

        [Required]
        [ConcurrencyCheck]
        public bool IsActive { get; set; }

        [Required]
        [ConcurrencyCheck]
        public bool IsDeleted { get; set; }

    }
}