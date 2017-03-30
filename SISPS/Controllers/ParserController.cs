using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ilf.pgn;
using System.IO;

namespace SISPS.Controllers
{
    public class ParserController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody] dynamic data)
        {
            var str = (string)data.d;
            byte[] dataBytes = Convert.FromBase64String(str);
            using (var ms = new MemoryStream(dataBytes))
            {
                var result = (new PgnReader()).ReadFromStream(ms);
                return new JsonResult(new { White = result.Games[0].WhitePlayer, Black = result.Games[0].BlackPlayer });
            }
        }
    }
}
