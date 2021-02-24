using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SemanticBlazor.Web.Data
{
  public class DummyData
  {
    [Display(Name = "Id"), Required]
    public int DummyId { get; set; }

    [Display(Name = "Name", Description = "Name your dummy"), Required, MaxLength(50)]
    public string Name { get; set; }

    [Display(Name = "Enabled", Description = "Enable this dummy")]
    public bool Enabled { get; set; }

    [Display(Name = "Description"), MaxLength(1024)]
    public string Description { get; set; }

    [Required, Display(Name = "Type")]
    public string Type { get; set; }

    [MinLength(1, ErrorMessage = "You have to select at least one Flag"), Required, Display(Name = "Flags")]
    public List<string> Flags { get; set; } = new List<string>();

    [Display(Name = "Created")]
    public DateTime Created { get; set; }

    [Display(Name = "Last update")]
    public DateTime? LastUpdate { get; set; }

    public override string ToString()
    {
      return $"[{DummyId}] {Name} - {Created.ToString("dd.MM.yyyy HH:mm")}";
    }
  }
}
