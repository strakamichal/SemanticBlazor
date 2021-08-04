using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SemanticBlazor.Web.Data
{
  public class DummyDataService
  {
    private static IEnumerable<DummyData> Dummies = new List<DummyData>()
    {
      new DummyData() { DummyId= 1, Enabled=true, Name="Lorem", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit.", Created=new DateTime(2019, 8, 24, 19, 20, 30), Type="Dummy type 2", Flags = new List<string>() { "ABC", "XYZ" } },
      new DummyData() { DummyId= 2, Enabled=false, Name="Sed", Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem", Created=new DateTime(2019, 8, 25, 19, 20, 30) },
      new DummyData() { DummyId= 3, Enabled=false, Name="Nemo", Description="Nemo enim ipsam voluptatem quia voluptas", Created=new DateTime(2019, 8, 26, 19, 20, 30), Type="Dummy type 1" },
      new DummyData() { DummyId= 4, Enabled=true, Name="Neque", Description="Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet", Created=new DateTime(2019, 8, 27, 19, 20, 30) },
      new DummyData() { DummyId= 5, Enabled=true, Name="Ut enim", Description="Ut enim ad minima veniam, quis nostrum exercitationem ul", Created=new DateTime(2019, 8, 28, 19, 20, 30), Type="Dummy type 3" },
      new DummyData() { DummyId= 6, Enabled=false, Name="Quis", Description="Quis autem vel eum iure reprehenderit qui in ea ", Created=new DateTime(2019, 8, 29, 19, 20, 30), Type="Dummy type 2" },
      new DummyData() { DummyId= 7, Enabled=true, Name="At", Description="At vero eos et accusamus et iusto odio dignissimos", Created=new DateTime(2019, 8, 30, 19, 20, 30), Type="Dummy type 2" },
      new DummyData() { DummyId= 8, Enabled=true, Name="Nemo", Description="Nemo enim ipsam voluptatem quia voluptas", Created=new DateTime(2019, 8, 26, 19, 20, 30) },
      new DummyData() { DummyId= 9, Enabled=true, Name="Neque", Description="Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet", Created=new DateTime(2019, 8, 27, 19, 20, 30), Type="Dummy type 1" },
      new DummyData() { DummyId= 10, Enabled=false, Name="Ut enim", Description="Ut enim ad minima veniam, quis nostrum exercitationem ul", Created=new DateTime(2019, 8, 28, 19, 20, 30), Type="Dummy type 3" },
      new DummyData() { DummyId= 11, Enabled=true, Name="Quis", Description="Quis autem vel eum iure reprehenderit qui in ea ", Created=new DateTime(2019, 8, 29, 19, 20, 30), Type="Dummy type 3" },
      new DummyData() { DummyId= 12, Enabled=true, Name="At", Description="At vero eos et accusamus et iusto odio dignissimos", Created=new DateTime(2019, 8, 30, 19, 20, 30), Type="Dummy type 2" },
      new DummyData() { DummyId= 13, Enabled=true, Name="Nemo", Description="Nemo enim ipsam voluptatem quia voluptas", Created=new DateTime(2019, 8, 26, 19, 20, 30), Type="Dummy type 2" },
      new DummyData() { DummyId= 14, Enabled=false, Name="Neque", Description="Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet", Created=new DateTime(2019, 8, 27, 19, 20, 30) },
      new DummyData() { DummyId= 15, Enabled=true, Name="Ut enim", Description="Ut enim ad minima veniam, quis nostrum exercitationem ul", Created=new DateTime(2019, 8, 28, 19, 20, 30), Type="Dummy type 2" },
      new DummyData() { DummyId= 16, Enabled=true, Name="Quis", Description="Quis autem vel eum iure reprehenderit qui in ea ", Created=new DateTime(2019, 8, 29, 19, 20, 30) },
      new DummyData() { DummyId= 17, Enabled=false, Name="At", Description="At vero eos et accusamus et iusto odio dignissimos", Created=new DateTime(2019, 8, 30, 19, 20, 30) },
      new DummyData() { DummyId= 18, Enabled=true, Name="Nemo", Description="Nemo enim ipsam voluptatem quia voluptas", Created=new DateTime(2019, 8, 26, 19, 20, 30), Type="Dummy type 2" },
      new DummyData() { DummyId= 19, Enabled=true, Name="Neque", Description="Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet", Created=new DateTime(2019, 8, 27, 19, 20, 30) },
      new DummyData() { DummyId= 20, Enabled=false, Name="Ut enim", Description="Ut enim ad minima veniam, quis nostrum exercitationem ul", Created=new DateTime(2019, 8, 28, 19, 20, 30) },
      new DummyData() { DummyId= 21, Enabled=true, Name="Quis", Description="Quis autem vel eum iure reprehenderit qui in ea ", Created=new DateTime(2019, 8, 29, 19, 20, 30), Type="Dummy type 2" }
    };

    public async Task<DummyData> GetByIdAsync(int id)
    {
      return await Task.FromResult(Dummies.FirstOrDefault(d => d.DummyId == id));
    }

    public async Task<List<DummyData>> GetAllDataAsync()
    {
      await Task.Delay(1000);
      return Dummies.ToList();
    }

    public async Task<List<DummyData>> GetDataAsync(int startIndex, int pageSize, string search, string sortExpression = null, string sortDirection = null)
    {
      await Task.Delay(1000);
      var query = Dummies
        .Where(d => String.IsNullOrEmpty(search) || d.Name.Contains(search) || d.Description.Contains(search));

      if (sortExpression != null)
      {
        PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(DummyData)).Find(sortExpression, true);
        if (sortDirection != "DESC")
        {
          query = query.OrderBy(x => prop.GetValue(x));
        }
        else
        {
          query = query.OrderByDescending(x => prop.GetValue(x));
        }
      }

      return query
        .Skip(startIndex)
        .Take(pageSize)
        .ToList();
    }

    public async Task<int> GetCountAsync(string search)
    {
      await Task.Delay(100);
      return Dummies
        .Where(d => String.IsNullOrEmpty(search) || d.Name.Contains(search) || d.Description.Contains(search))
        .Count();
    }

    public void Delete(int id)
    {
      Dummies.ToList().Remove(Dummies.FirstOrDefault(d => d.DummyId == id));
    }
  }
}
