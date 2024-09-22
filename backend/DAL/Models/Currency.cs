using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Currency(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}
