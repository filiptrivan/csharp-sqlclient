using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCascadeVsClientCascadeBenchmark.Entities
{
    public class People
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxName { get; set; }
        public string FaxPhone { get; set; }
        public string FaxPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Index { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
