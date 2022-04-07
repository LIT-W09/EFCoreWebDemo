using EFCoreWebDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWebDemo.Web.Models
{
    public class HomePageViewModel
    {
        public List<Person> People { get; set; }
    }
}
