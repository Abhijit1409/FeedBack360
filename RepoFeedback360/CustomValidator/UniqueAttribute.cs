using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.CustomValidator
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple=false)]
    public class UniqueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }
    }
}
