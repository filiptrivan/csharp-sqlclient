using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderCascadeVsClientCascadeBenchmark.Entities
{
    public class Blog
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Number { get; set; }
        public string Code { get; set; }
        public string Html { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaCode { get; set; }
        public string MetaHtml { get; set; }

        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public People Owner { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
