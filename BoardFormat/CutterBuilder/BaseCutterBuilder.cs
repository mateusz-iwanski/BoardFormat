using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardFormat.CutterBuilder
{
    public abstract class BaseCutterBuilder
    {
        protected Settings settings = MauiProgram.Services.GetService<IConfiguration>()
             .GetRequiredSection("Settings").Get<Settings>();
    }
}
