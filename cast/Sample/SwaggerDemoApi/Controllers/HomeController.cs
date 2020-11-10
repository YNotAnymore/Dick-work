using Microsoft.AspNetCore.Mvc;
using SwaggerDemoApi.Extension;
using SwaggerDemoApi.Menu;

namespace SwaggerDemoApi.Controllers
{
    /// <summary>
    /// Main api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="arg">
        ///     <para>1 - 测试</para>
        ///     <para>2 - 测试2</para>
        /// </param>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpGet("menu")]
        public string GetMenu(string arg, Level level)
        {
            return level.GetDescription();
        }

        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("menu")]
        public string GetMenu([FromBody] MenuReq req)
        {
            return req.Level.GetDescription();
        }
        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("menu2")]
        public NewLevel GetMenu([FromBody] NewMenuReq req)
        {
            return req.Level;
        }
        /// <summary>
        /// 获取枚举
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpPost("{level}")]
        public NewLevel GetMenu(NewLevel level)
        {
            return level;
        }

    }

    public class NewMenuReq
    {
        public NewLevel Level { get; set; }

        public string Arg { get; set; }
    }

    public class MenuReq
    {
        public Level Level { get; set; }

        public string Arg { get; set; }
    }

}
